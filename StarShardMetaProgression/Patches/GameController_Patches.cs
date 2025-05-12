using HarmonyLib;
using Astrea;
using UnityEngine;

namespace StarShardMetaProgression.Patches {

    public class GameController_Patches {
        [HarmonyPatch(typeof(GameController), nameof(GameController.NewGame))]
        public class GameController_NewGame {
            public static void Postfix(GameController __instance) {
                PlayerData pd = Traverse.Create(__instance).Field("playerData").GetValue() as PlayerData;
                string character = pd.CurrentCharacter.CharacterName;
                int shards = StarShardMetaProgressionUtils.getStartingShards(character);
                Traverse.Create(pd).Field("startingGold").SetValue(100 + shards);
            }
        }
    }
}
