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
            mod.OnUpdate = OnUpdate;

           // HarmonyInstance.DEBUG = true;
            return true;
        }

        static void OnUpdate(UnityModManager.ModEntry modEntry, float dt)
        {
            if(Input.GetKeyDown(KeyCode.F1))
            {
                FileLog.Log("F1 Press");
                HealthAndDamageNew component = GameObject.FindWithTag("Ship").GetComponent<HealthAndDamageNew>();
                component.health = component.initialHealth;
            }
        }
    }

    /*
    [HarmonyPatch(typeof(WindowStack))] // Class
    [HarmonyPatch("Add")]               // Method
    static class Patch01
    {
        static void Prefix(Window window)
        {

        }
    }
    */
}