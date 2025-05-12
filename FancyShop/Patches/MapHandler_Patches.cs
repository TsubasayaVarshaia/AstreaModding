using UnityEngine;
using Astrea;
using HarmonyLib;
using System.Collections.Generic;
using Astrea.BattleActions;
using Astrea.RunModifiers.VirtuesPanel;
using System;
using Astrea.RunModifiers;

namespace FancyShop
    public class MapHandler_Patches {

        private static void nodePrint(NodeData node, string nodeInfo = "") {
            Debug.Log("#############\n" + nodeInfo + "\n#############");
            Debug.Log("Node reward: " + node.Reward);
            Debug.Log("Node Event: " + node.Event);
            Debug.Log("Node Enum: " + node.NodeEnum.ToString());
            Debug.Log("Node BattlePackage: " + node.BattlePackage);
        }

        [HarmonyPatch(typeof(MapHandler), nameof(MapHandler.PopulateMap))]
        public class MapHandler_PopulateMap {
            public static void Postfix(MapHandler __instance) {
                if(__instance.CurrentAreaIndex == 0) {
                    Map map = Traverse.Create(__instance).Field("map").GetValue() as Map;

                    List<NodeData> nodeDatas = map.MapLevels[0].NodeDatas;
                    NodeData extraNode = new NodeData();
                    extraNode.Reward = "EpicShopClearingReward";
                    extraNode.NodeEnum = NodeEnum.REWARD;
                    
                    MapLevel extraMapLevel = new MapLevel();
                    List<NodeData> extraNodeList = new List<NodeData>() {extraNode};
                    extraMapLevel.NodeDatas = extraNodeList;
                    List<MapLevel> mapLevels = map.MapLevels;
                    mapLevels.Insert(2, extraMapLevel);

                    //OnNewRuneOmenData maybe for the shop function

                    Traverse.Create(map).Field("NodeDatas").SetValue(nodeDatas);

                    // MapPlayerTracker mpt = Traverse.Create(__instance).Field("mapPlayerTracker").GetValue() as MapPlayerTracker;
                    // mpt.CurrentAreaLevelIndex = 5;
                    // Traverse.Create(__instance).Field("mapPlayerTracker").SetValue(mpt);

                    // Debug.Log("Testing if the call for randomvirtuespool itself works");
                    // RandomVirtuesPool rvp = (Astrea.RunModifiers.RandomVirtuesPool) RandomVirtuesPool.CreateInstance("RandomVirtuesPool");
                    // RandomVirtuesPoolCharacter[] rvpcs = rvp.RandomVirtuesPoolCharacter;
                    // foreach(RandomVirtuesPoolCharacter rvpc in rvpcs) {
                    //     Debug.Log(rvpc.Character.CharacterName);
                    // }
                    // Debug.Log("Call done");

                    // PlayerData pd = Traverse.Create(__instance).Field("playerData").GetValue() as PlayerData;
                    // CharacterRunes charRunes = pd.CurrentCharacter.CharacterRunes;

                    // RandomVirtuesPool pool = new RandomVirtuesPool();
                    // for(int i = 0; i < 10; i++) {
                    //     Debug.Log(pool.GetRandomVirtue(0));
                    // }
                }
            }
        }
    }
}