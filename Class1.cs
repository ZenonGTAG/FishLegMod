using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using BepInEx;
using HarmonyLib;
using UnityEngine.XR;
using Utilla;
namespace FishLegMod
{
    [BepInPlugin("net.zenon.fishlegmod", "Fish Leg Mod", "1.0.0")]
    [ModdedGamemode]
    [BepInDependency("org.legoandmars.gorillatag.utilla", "1.6.7")]
    public class Class1 : BaseUnityPlugin
    {
        public bool inRoom = false;
        public void Awake() 
        {
            var harmony = new Harmony("net.zenon.fishlegmod");
            harmony.PatchAll(System.Reflection.Assembly.GetExecutingAssembly());
        }

        public void Update() 
        {
            if (inRoom) 
            {
                GorillaTagger.Instance.myVRRig.rightHand.rigTarget.transform.position = GorillaLocomotion.Player.Instance.leftHandTransform.position;
                GorillaTagger.Instance.myVRRig.leftHand.rigTarget.transform.position = GorillaLocomotion.Player.Instance.rightHandTransform.position;
            }

        }

        [ModdedGamemodeJoin]
        public void OnJoin(string gamemode)
        {

            inRoom = true;
        }

        [ModdedGamemodeLeave]
        public void OnLeave(string gamemode)
        {
            inRoom = false;
        }
    }
}
