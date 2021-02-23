using System;
using System.Collections.Generic;
using System.Text;
using Trainworks.Builders;
using Trainworks.Constants;
using static Trainworks.Constants.VanillaCardPoolIDs;

namespace SpiritClan
{
    class TestSpell
    {
        public static void Make()
        {
            CardDataBuilder card = new CardDataBuilder
            {
                CardType = CardType.Spell,

                CardID = SpiritClan.GUID + "_TestSpell0001",
                Name = "Not Horn Break",
                Description = "Deal [effect0.power] damage",
                Cost = 0,
                Rarity = CollectableRarity.Common,
                TargetsRoom = true,
                Targetless = false,
                ClanID = VanillaClanIDs.Stygian,
                AssetPath = "assets/nothornbreak.png",
                CardPoolIDs = new List<string> { VanillaCardPoolIDs.MegaPool },
                EffectBuilders = new List<CardEffectDataBuilder>
                {
                    new CardEffectDataBuilder
                    {
                        EffectStateType = VanillaCardEffectTypes.CardEffectDamage,
                        ParamInt = 5,
                        TargetMode = TargetMode.DropTargetCharacter
                    }
                },
                TraitBuilders = new List<CardTraitDataBuilder>
                {
                    new CardTraitDataBuilder
                    {
                        TraitStateType = VanillaCardTraitTypes.CardTraitIgnoreArmor
                    }
                }
            };

            card.BuildAndRegister();
        }
    }
}
