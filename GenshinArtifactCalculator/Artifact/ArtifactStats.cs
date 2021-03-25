using GenshinArtifactCalculator.Util;
using System;

namespace GenshinArtifactCalculator.Artifact
{
    public static class ArtifactStats
    {
        public static readonly ArtifactStat FlatHealth       = new ArtifactStat("HP");
        public static readonly ArtifactStat PercentageHealth = new ArtifactStat("HP", '%');

        public static readonly ArtifactStat FlatAttack       = new ArtifactStat("ATK");
        public static readonly ArtifactStat PercentageAttack = new ArtifactStat("ATK", '%');

        public static readonly ArtifactStat FlatDefense       = new ArtifactStat("DEF");
        public static readonly ArtifactStat PercentageDefense = new ArtifactStat("DEF", '%');

        public static readonly ArtifactStat ElementalMastery = new ArtifactStat("Elemental Mastery");

        public static readonly ArtifactStat EnergyRecharge = new ArtifactStat("Energy Recharge", '%');

        public static readonly ArtifactStat PhysicalDamageBonus = new ArtifactStat("Physical DMG Bonus", '%');
        public static readonly ArtifactStat PyroDamageBonus     = new ArtifactStat("Anemo DMG Bonus", '%');
        public static readonly ArtifactStat HydroDamageBonus    = new ArtifactStat("Hydro DMG Bonus", '%');
        public static readonly ArtifactStat AnemoDamageBonus    = new ArtifactStat("Anemo DMG Bonus", '%');
        public static readonly ArtifactStat ElectroDamageBonus  = new ArtifactStat("Electro DMG Bonus", '%');
        public static readonly ArtifactStat DendroDamageBonus   = new ArtifactStat("Dendro DMG Bonus", '%');
        public static readonly ArtifactStat CryoDamageBonus     = new ArtifactStat("Cryo DMG Bonus", '%');
        public static readonly ArtifactStat GeoDamageBonus      = new ArtifactStat("Geo DMG Bonus", '%');

        public static readonly ArtifactStat CriticalRate   = new ArtifactStat("CRIT Rate", '%');
        public static readonly ArtifactStat CriticalDamage = new ArtifactStat("CRIT DMG", '%');

        public static readonly ArtifactStat HealingBonus = new ArtifactStat("Healing Bonus", '%');

        private static readonly ArtifactStat[] Values = {PercentageHealth, FlatHealth, PercentageAttack, FlatAttack, PercentageDefense, FlatDefense, ElementalMastery, EnergyRecharge, PhysicalDamageBonus, PyroDamageBonus, HydroDamageBonus, AnemoDamageBonus, ElectroDamageBonus, DendroDamageBonus, CryoDamageBonus, GeoDamageBonus, CriticalRate, CriticalDamage, HealingBonus};

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
