using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace StarShardMetaProgression.Patches {
    internal class StarShardMetaProgressionUtils {

        internal const string FILEPATH = "StarShardMetaProgression.json";
        internal static readonly string[] CHAR_NAMES = {"Moonie", "Cellarius", "Hevelius", "Austra", "Sothis", "Orion"};

        static internal bool checkForProgressionFile() {
            return File.Exists(FILEPATH);
        }

        static private void createFileIfNotExist() {
            if(!checkForProgressionFile()) {
                int l = CHAR_NAMES.Length;
                var allCharacters = new Dictionary<string, int>();
                for(int i = 0; i < l; i++) {
                    allCharacters[CHAR_NAMES[i]] = 0;
                }
                allCharacters["metaProgressionPercent"] = 2; //abuse the file to also save the percentage
                writeJson(allCharacters);
            }
        }

        static private Dictionary<string, int> getJson() {
            createFileIfNotExist();
            string json = File.ReadAllText(FILEPATH);
            return JsonConvert.DeserializeObject<Dictionary<string, int>>(json);
        }

        static private void writeJson(Dictionary<string, int> jsonObj) {
            string output = JsonConvert.SerializeObject(jsonObj, Formatting.Indented);
            File.WriteAllText(FILEPATH, output);
        }

        static internal int getStartingShards(string character) {
            Dictionary<string, int> jsonObj = getJson();
            return jsonObj[character];
        }

        static internal void updateStartingShards(string character, int amount) {
            Dictionary<string, int> jsonObj = getJson();
            jsonObj[character] += amount;
            writeJson(jsonObj);
        }
    }
}
