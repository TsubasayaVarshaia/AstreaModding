using System;
using System.Collections.Generic;
using System.Reflection;
using Astrea;
using Astrea.BattleActions;
using Astrea.RunModifiers;
using Astrea.RunModifiers.VirtuesPanel;
using HarmonyLib;
using UnityEngine;

namespace FancyShop

[HarmonyPatch(typeof(VirtuesPanel), "Awake")]
public class VirtuesPanelPatch
{ 
    // Get some variables in a awake of VirtuesPanel :P
    public static void Postfix (VirtuesPanel __instance)
    {
        // Any Character
        FieldInfo privateFieldInfo = typeof(VirtuesPanel).GetField("anyCharacter", BindingFlags.NonPublic | BindingFlags.Instance);
        VirtuesPanelHelper.anyCharacter = (Character)privateFieldInfo.GetValue(__instance);

        // RandomVirtuesPool
        privateFieldInfo = typeof(VirtuesPanel).GetField("randomVirtuesPool", BindingFlags.NonPublic | BindingFlags.Instance);
        RandomVirtuesPool randomVirtuesPool = (RandomVirtuesPool)privateFieldInfo.GetValue(__instance);

        VirtuesPanelHelper.randomVirtuesPoolCharacter = randomVirtuesPool.RandomVirtuesPoolCharacter;

        
        Debug.Log("VIRTUES PANEL PATCHED");

        // Ignore orignal code, if you want the original code just return true
        // return true;
    }

    // Maybe you need to create another class to use this...
    public static class VirtuesPanelHelper
    {
        public static RandomVirtuesPoolCharacter[] randomVirtuesPoolCharacter;
        public static Character anyCharacter;

        public static Rune GetRandomVirtue(int slotIndex, string characterName)
        {
            List<RandomVirtuesRune> allVirtuesRunesPool = new List<RandomVirtuesRune>();
            foreach (RandomVirtuesPoolCharacter randomVirtuesPoolCharacter2 in randomVirtuesPoolCharacter)
            {
                // I think the CharacterName is in english.... I don't remember
                if (randomVirtuesPoolCharacter2.Character.CharacterName == characterName || randomVirtuesPoolCharacter2.Character == anyCharacter)
                {
                    List<RandomVirtuesRune> randomVirtuesRunes = randomVirtuesPoolCharacter2.DailyRunVirtuesPoolSlotIndexes[slotIndex].RandomVirtuesRunes;
                    
                    // Add the current Character and Any
                    allVirtuesRunesPool.AddRange(randomVirtuesRunes);
                }
            }

            // foreach(RandomVirtuesRune virtue in allVirtuesRunesPool) {
            //     Debug.Log(virtue.Rune.FaceName);
            // }

            RandomVirtuesRune randomVirtuesRune = allVirtuesRunesPool.PickRandom();
            Rune rune = randomVirtuesRune.Rune;
            rune.index = slotIndex;

            return rune;
        }
    }
}
}