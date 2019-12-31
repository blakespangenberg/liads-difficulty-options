using System;
using System.Reflection;

using UnityEngine;
using Harmony;
using UnityModManagerNet;

namespace DifficultyOptions
{
    static class Main
    {
        public static UnityModManager.ModEntry mod;

        static bool Load(UnityModManager.ModEntry modEntry)
        {
            var harmony = HarmonyInstance.Create(modEntry.Info.Id);
            harmony.PatchAll(Assembly.GetExecutingAssembly());

            mod = modEntry;
            // HarmonyInstance.DEBUG = true;

            return true;
        }
    }
}