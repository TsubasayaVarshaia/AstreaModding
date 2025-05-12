using HarmonyLib;
using Astrea;

namespace StarShardMetaProgression.Patches {

    public class VictoryDefeatScorePanel_Patches {
        [HarmonyPatch(typeof(VictoryDefeatScorePanel), nameof(VictoryDefeatScorePanel.SendEndOfTheRunAnalytics))]
        public class VictoryDefeatScorePanel_SendEndOfTheRunAnalytics {
            public static void Prefix(VictoryDefeatScorePanel __instance, 
            bool victory, int runScoreXP, int characterBeforeScoreLevel, int characterLevel, bool isStartingNewRun = false) {

                PlayerData pd = Traverse.Create(__instance).Field("playerData").GetValue() as PlayerData;
                string character = pd.CurrentCharacter.CharacterName;
                int percent = StarShardMetaProgressionUtils.getStartingShards("metaProgressionPercent");
                int metaMoney = runScoreXP*percent/100;
                StarShardMetaProgressionUtils.updateStartingShards(character, metaMoney);
            }
        }
    }
}