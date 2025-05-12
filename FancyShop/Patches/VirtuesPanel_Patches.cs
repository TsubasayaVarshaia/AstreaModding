using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Astrea.BattleActions;
using Astrea.RunModifiers;
using Astrea.RunModifiers.VirtuesPanel;
using HarmonyLib;
using UnityEngine;

namespace FancyShop
    public class VirtuesPanel_Patches {
        
        [HarmonyPatch(typeof(VirtuesPanel), nameof(VirtuesPanel.SelectVirtueOnCorruptionMeter))]
        public class VirtuesPanel_SelectVirtueOnCorruptionMeter {
            public static void Prefix(VirtuesPanel __instance) {
                Debug.Log("##########");
                Debug.Log("Inside VirtuesPanel:SelectOnCorruptionMeter");
                Debug.Log("##########");

                RandomVirtuesPool randomVirtuesPool = Traverse.Create(__instance).Field("randomVirtuesPool").GetValue() as RandomVirtuesPool;
                foreach(RandomVirtuesPoolCharacter virtuesPoolCharacter in randomVirtuesPool.RandomVirtuesPoolCharacter) {
                    if(virtuesPoolCharacter.Character.CharacterName == "Moonie" || virtuesPoolCharacter.Character.CharacterName == "any") {
                        List<RandomVirtuesRune> randomVirtuesRunes = virtuesPoolCharacter.DailyRunVirtuesPoolSlotIndexes[1].RandomVirtuesRunes;
                        for(int i = 0; i < randomVirtuesRunes.Count; ++i) {
                            Rune rune = randomVirtuesRunes[i].Rune;
                            Debug.Log(rune.FaceName);
                        }
                    }
                }
            }
        }
    }
}