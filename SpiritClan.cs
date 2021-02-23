using BepInEx;
using HarmonyLib;
using Trainworks;
using Trainworks.Interfaces;
using Trainworks.Managers;

namespace SpiritClan
{
    [BepInPlugin(GUID, NAME, VERSION)]
    [BepInProcess("MonsterTrain.exe")]
    [BepInProcess("MtLinkHandler.exe")]
    [BepInDependency("modding.train.monster")]
    public class SpiritClan : BaseUnityPlugin
    {
        public const string GUID = "com.tolbby.mods.spiritclan";
        public const string NAME = "Spirit Clan";
        public const string VERSION = "0.1.0";
        public void Initialize()
        {
            //Build the clan first!
        //    TestClan.BuildAndRegister();

            //Then everything else.
            /*TestClanChampion.BuildAndRegister();
            ModifyFrozenLance.Modify();
            NotHornBreak.BuildAndRegister();
            GiveEveryoneArmor.BuildAndRegister();
            PlayOtherCards.BuildAndRegister();
            SubtypeDragon.BuildAndRegister();
            BlueEyesWhiteDragon.BuildAndRegister();
            DragonCostume.BuildAndRegister();
            AppleMorsel.BuildAndRegister();
            Wimpcicle.BuildAndRegister();
            TestClanBanner.BuildAndRegister();*/
        }

        void Awake()
        {
            var harmony = new Harmony(GUID);
            harmony.PatchAll();
        }

        [HarmonyPatch(typeof(SaveManager), "SetupRun")]
        class AddCardToStartingDeckPatch
        {
            static void Postfix(ref SaveManager __instance)
            {
                var id = SpiritClan.GUID + "_TestSpell0001";
                __instance.AddCardToDeck(CustomCardManager.GetCardDataByID(id));
            }
        }
    }
}
