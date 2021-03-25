using GenshinArtifactCalculator.Util;
using System;
using System.Collections.Generic;

namespace GenshinArtifactCalculator.Artifact
{
    public static class ArtifactStats
    {
        public static readonly ArtifactStat FlatHealth = new ArtifactStat(
            "HP",
            null,
            new List<ArtifactStatRarity>
            {
                new ArtifactStatRarity(1, new ArtifactMainStatRarityData(129.0D, 324.0D, 4), new ArtifactSubStatRarityData(24.0D, 30.0D)),
                new ArtifactStatRarity(2, new ArtifactMainStatRarityData(258.0D, 843.0D, 8), new ArtifactSubStatRarityData(50.0D, 61.0D, 72.0D)),
                new ArtifactStatRarity(3, new ArtifactMainStatRarityData(430.0D, 1_893.0D, 12), new ArtifactSubStatRarityData(100.0D, 115.0D, 129.0D, 143.0D)),
                new ArtifactStatRarity(4, new ArtifactMainStatRarityData(645.0D, 3_571.0D, 16), new ArtifactSubStatRarityData(167.0D, 191.0D, 215.0D, 239.0D)),
                new ArtifactStatRarity(5, new ArtifactMainStatRarityData(717.0D, 4_780.0D, 20), new ArtifactSubStatRarityData(209.0D, 239.0D, 269.0D, 299.0D))
            }
        );
        // public static readonly ArtifactStat PercentageHealth = new ArtifactStat("HP", '%');
        //
        // public static readonly ArtifactStat FlatAttack       = new ArtifactStat("ATK", null);
        // public static readonly ArtifactStat PercentageAttack = new ArtifactStat("ATK", '%');
        //
        // public static readonly ArtifactStat FlatDefense       = new ArtifactStat("DEF", null);
        // public static readonly ArtifactStat PercentageDefense = new ArtifactStat("DEF", '%');
        //
        // public static readonly ArtifactStat ElementalMastery = new ArtifactStat("Elemental Mastery", null);
        //
        // public static readonly ArtifactStat EnergyRecharge = new ArtifactStat("Energy Recharge", '%');
        //
        // public static readonly ArtifactStat PhysicalDamageBonus = new ArtifactStat("Physical DMG Bonus", '%');
        // public static readonly ArtifactStat PyroDamageBonus     = new ArtifactStat("Anemo DMG Bonus", '%');
        // public static readonly ArtifactStat HydroDamageBonus    = new ArtifactStat("Hydro DMG Bonus", '%');
        // public static readonly ArtifactStat AnemoDamageBonus    = new ArtifactStat("Anemo DMG Bonus", '%');
        // public static readonly ArtifactStat ElectroDamageBonus  = new ArtifactStat("Electro DMG Bonus", '%');
        // public static readonly ArtifactStat DendroDamageBonus   = new ArtifactStat("Dendro DMG Bonus", '%');
        // public static readonly ArtifactStat CryoDamageBonus     = new ArtifactStat("Cryo DMG Bonus", '%');
        // public static readonly ArtifactStat GeoDamageBonus      = new ArtifactStat("Geo DMG Bonus", '%');
        //
        // public static readonly ArtifactStat CriticalRate   = new ArtifactStat("CRIT Rate", '%');
        // public static readonly ArtifactStat CriticalDamage = new ArtifactStat("CRIT DMG", '%');
        //
        // public static readonly ArtifactStat HealingBonus = new ArtifactStat("Healing Bonus", '%');

        private static readonly ArtifactStat[] Values = {/*PercentageHealth, */FlatHealth/*, PercentageAttack, FlatAttack, PercentageDefense, FlatDefense, ElementalMastery, EnergyRecharge, PhysicalDamageBonus, PyroDamageBonus, HydroDamageBonus, AnemoDamageBonus, ElectroDamageBonus, DendroDamageBonus, CryoDamageBonus, GeoDamageBonus, CriticalRate, CriticalDamage, HealingBonus*/};

        public static ArtifactStat? Parse(string? name)
        {
            if (name == null)
            {
                return null;
            }
            foreach (ArtifactStat value in Values)
            {
                if (name.StartsWith(value.Name, StringComparison.OrdinalIgnoreCase) && (value.SpecialCharacter == null || name.Contains(value.SpecialCharacter.Value)))
                {
                    return value;
                }
                int levenshteinDistance = Utils.ComputeLevenshteinDistance(name, value.Name);
                if (levenshteinDistance <= 1)
                {
                    return value;
                }
            }
            return null;
        }
    }
}
