using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Text;
using Trainworks.Builders;
using Trainworks.Constants;
using Trainworks.Managers;
using UnityEngine;

namespace SpiritClan
{
    class TestClan
    {
        public static readonly string ID = SpiritClan.GUID + "_TestClan";

        public static string RewardNodeID { get; private set; }
        public static string CharacterID { get; private set; }

        public static void BuildAndRegister()
        {
            new ClassDataBuilder
            {
                ClassID = ID,
                Name = "Test Clan",
                Description = "Test Clan Description",
                SubclassDescription = "Test Clan Sub Description",
                CardStyle = ClassCardStyle.Stygian,
                IconAssetPaths = new List<string>
            {
                "assets/testclan-small.png",  //It can be - or _ depending the name of the image you downloaded
                "assets/testclan-large.png",  //It can be - or _ depending the name of the image you downloaded
                "assets/testclan-large.png",  //It can be - or _ depending the name of the image you downloaded
                "assets/testclan-silhouette.png" //It can be - or _ depending the name of the image you downloaded
            },
                UiColor = new Color(0.1f, 0.8f, 0.8f, 1f),
                UiColorDark = new Color(0.05f, 0.5f, 0.5f, 1f),
            }.BuildAndRegister();



            CardPool cardPool = UnityEngine.ScriptableObject.CreateInstance<CardPool>();
            var cardDataList = (Malee.ReorderableArray<CardData>)AccessTools.Field(typeof(CardPool), "cardDataList").GetValue(cardPool);
            //cardDataList.Add(CustomCardManager.GetCardDataByID(BlueEyesWhiteDragon.ID));
            //cardDataList.Add(CustomCardManager.GetCardDataByID(DragonCostume.ID));



            new RewardNodeDataBuilder()
            {
                RewardNodeID = ID,
                MapNodePoolIDs = new List<string>
                {
                    VanillaMapNodePoolIDs.RandomChosenMainClassUnit,
                    VanillaMapNodePoolIDs.RandomChosenSubClassUnit
                },
                Name = "Test Clan Banner",
                Description = "Offers units from the illustrious Test Clan",
                RequiredClass = CustomClassManager.GetClassDataByID(TestClan.ID),
                FrozenSpritePath = "assets/TestClanBanner_Frozen.png",
                EnabledSpritePath = "assets/TestClanBanner_Enabled.png",
                DisabledSpritePath = "assets/TestClanBanner_Disabled.png",
                DisabledVisitedSpritePath = "assets/TestClanBanner_Disabled_Visited.png",
                GlowSpritePath = "assets/TestClanBanner_Glow.png",
                MapIconPath = "assets/TestClanBanner_Enabled.png",
                MinimapIconPath = "assets/TestClanBanner_Minimap.png",
                SkipCheckInBattleMode = true,
                OverrideTooltipTitleBody = false,
                NodeSelectedSfxCue = "Node_Banner",
                ControllerSelectedOutline = "assets/TestClanBanner_Glow.png", //Highlight banners if using a controller.
                RewardBuilders = new List<IRewardDataBuilder>
                {
                    new DraftRewardDataBuilder()
                    {
                        DraftRewardID = RewardNodeID,
                        _RewardSpritePath = "assets/TestClanBanner_Enabled.png",
                        _RewardTitleKey = "Test Clan Banner",
                        _RewardDescriptionKey = "Choose a card!",
                        Costs = new int[] { 100 },
                        _IsServiceMerchantReward = false,
                        DraftPool = cardPool,
                        ClassType = (RunState.ClassType)7,
                        DraftOptionsCount = 2,
                        RarityFloorOverride = CollectableRarity.Uncommon
                    }
                }
            }.BuildAndRegister();

            var championCharacterBuilder = new CharacterDataBuilder
            {
                CharacterID = CharacterID,
                Name = "K.Aqua",
                Size = 1,
                Health = 10,
                AttackDamage = 5,
                AssetPath = "assets/kaqua_character.png"
            };

            new ChampionCardDataBuilder()
            {
                Champion = championCharacterBuilder,
                ChampionIconPath = "assets/kaqua.png",
                StarterCardData = CustomCardManager.GetCardDataByID(VanillaCardIDs.Torch),
                CardID = ID,
                Name = "K.Aqua",
                ClanID = TestClan.ID,
                AssetPath = "assets/kaqua.png"
            }.BuildAndRegister();
        }
    }
}
