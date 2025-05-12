using UnityEngine;
using Astrea;
using HarmonyLib;

namespace AchievementEnabler.Patches {
    public class AchievementData_Patches {
        [HarmonyPatch(typeof(AchievementData), nameof(AchievementData.Unlock))]
        public class AchievementData_Unlock {
            public static void Prefix(AchievementData __instance, bool saveAndStoreCache = true) {
                GameController gc = Traverse.Create(__instance).Field("gameController").GetValue() as GameController;
                Traverse.Create(gc).Field("isModEnabled").SetValue(false);
            }
        }
    }
}