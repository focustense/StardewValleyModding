﻿using HarmonyLib;
using StardewModdingAPI;

namespace CheaperBeachBridgeRepair
{
    public class CheaperBeachBridgeRepair : Mod
    {
        public override void Entry(IModHelper helper)
        {
            var harmony = new Harmony(ModManifest.UniqueID);
            BeachPatches.Initialize(Helper.ReadConfig<ModConfig>(), Monitor);

            harmony.Patch(
               original: AccessTools.Method(typeof(StardewValley.Locations.Beach), nameof(StardewValley.Locations.Beach.answerDialogueAction)),
               prefix: new HarmonyMethod(typeof(BeachPatches), nameof(BeachPatches.AnswerDialogueAction_Prefix))
            );

            harmony.Patch(
               original: AccessTools.Method(typeof(StardewValley.Locations.Beach), nameof(StardewValley.Locations.Beach.checkAction)),
               prefix: new HarmonyMethod(typeof(BeachPatches), nameof(BeachPatches.checkAction_Prefix))
            );
        }
    }
}