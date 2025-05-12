using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Astrea;
using Astrea.BattleActions;
using HarmonyLib;
using UnityEngine;

namespace FancyShop
    public class EpicShopPanel_Patches {
        [HarmonyPatch(typeof(EpicShopPanel), nameof(EpicShopPanel.Initialize))]
        public class EpicShopPanel_Initialize {
            public static void Postfix(EpicShopPanel __instance) {
                EpicShop epicShop = Traverse.Create(__instance).Field("epicShop").GetValue() as EpicShop;
                

                PlayerData pd = (Traverse.Create(__instance).Field("mapHandler").GetValue() as MapHandler).PlayerData;
                Character character = pd.CurrentCharacter;

                Rune rune = VirtuesPanelPatch.VirtuesPanelHelper.GetRandomVirtue(1, character.CharacterName);
                Traverse.Create(epicShop).Field("OmenShopItem").SetValue(rune);
                Traverse.Create(__instance).Field("epicShop").SetValue(epicShop);
            }
        }
    }
}