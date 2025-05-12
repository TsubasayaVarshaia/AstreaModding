using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Astrea.RunModifiers;
using UnityEngine;
using HarmonyLib;
using Astrea.BattleActions;
using System.Reflection;

namespace FancyShop
    public class RandomVirtuesPool_Patches {

        [HarmonyPatch(typeof(RandomVirtuesPool), nameof(RandomVirtuesPool.SetupVirtues))]
        public class RandomVirtuesPool_SetupVirtues {
            public static void Postfix(RandomVirtuesPool __instance) {
                Debug.Log("##########");
                Debug.Log("Inside the random virtues pool patch!");
                Debug.Log("##########");

                // Debug.Log("Random Rune List:");
                // Rune[] runes = __instance.GetRandomVirtues();
                // foreach(Rune rune in runes) {
                //     Debug.Log(rune.FaceName);
                // }

                // MethodInfo methodInfo = typeof(RandomVirtuesPool).GetMethod("GetRandomVirtuesPoolCharacter", BindingFlags.NonPublic | BindingFlags.Instance);
                // var parameters = new object[] {"Moonie"};
                // Astrea.RunModifiers.RandomVirtuesPoolCharacter __result = (Astrea.RunModifiers.RandomVirtuesPoolCharacter) methodInfo.Invoke(null,parameters);
                // Debug.Log("Result from own call:");
                // Debug.Log(__result);

                // Astrea.RunModifiers.RandomVirtuesPoolCharacter rvpc = Traverse.Create(__instance).Field("randomVirtuesPoolCharacter").GetValue() as Astrea.RunModifiers.RandomVirtuesPoolCharacter;
                // Debug.Log("Result from attribute");
                // Debug.Log(rvpc);
            }
        }
    }
}