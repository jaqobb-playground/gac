using System;
using System.Collections.Generic;
using GenshinArtifactCalculator.Util;

namespace GenshinArtifactCalculator.Artifact
{
    // https://genshin-impact.fandom.com/wiki/Artifacts
    public static class ArtifactStats
    {
        public static readonly ArtifactStat PercentageHealth = new(
            "HP",
            '%',
            new List<ArtifactStatRarity>
            {
                new(
                    1,
                    new ArtifactStatRarityData(3.1D, 4.3D, 5.5D, 6.7D, 7.9D),
                    new ArtifactStatRarityData(1.2D, 1.5D)
                ),
                new(
                    2,
                    new ArtifactStatRarityData(4.2D, 5.4D, 6.6D, 7.8D, 9.0D, 10.1D, 11.3D, 12.5D, 13.7D),
                    new ArtifactStatRarityData(1.6D, 2.0D, 2.3D)
                ),
                new(
                    3,
                    new ArtifactStatRarityData(5.2D, 6.7D, 8.2D, 9.7D, 11.2D, 12.7D, 14.2D, 15.6D, 17.1D, 18.6D, 20.1D, 21.6D, 23.1D),
                    new ArtifactStatRarityData(2.5D, 2.8D, 3.2D, 3.5D)
                ),
                new(
                    4,
                    new ArtifactStatRarityData(6.3D, 8.1D, 9.9D, 11.6D, 13.4D, 15.2D, 17.0D, 18.8D, 20.6D, 22.3D, 24.1D, 25.9D, 27.7D, 29.5D, 31.3D, 33.0D, 34.8D),
                    new ArtifactStatRarityData(3.3D, 3.7D, 4.2D, 4.7D)
                ),
                new(
                    5,
                    new ArtifactStatRarityData(7.0D, 9.0D, 11.0D, 12.9D, 14.9D, 16.9D, 18.9D, 20.9D, 22.8D, 24.8D, 26.8D, 28.8D, 30.8D, 32.8D, 34.7D, 36.7D, 38.7D, 40.7D, 42.7D, 44.6D, 46.6D),
                    new ArtifactStatRarityData(4.1D, 4.7D, 5.3D, 5.8D)
                )
            }
        );

        public static readonly ArtifactStat FlatHealth = new(
            "HP",
            null,
            new List<ArtifactStatRarity>
            {
                new(
                    1,
                    new ArtifactStatRarityData(129.0D, 178.0D, 227.0D, 275.0D, 324.0D),
                    new ArtifactStatRarityData(24.0D, 30.0D)
                ),
                new(
                    2,
                    new ArtifactStatRarityData(258.0D, 331.0D, 404.0D, 478.0D, 551.0D, 624.0D, 697.0D, 770.0D, 843.0D),
                    new ArtifactStatRarityData(50.0D, 61.0D, 72.0D)
                ),
                new(
                    3,
                    new ArtifactStatRarityData(430.0D, 552.0D, 674.0D, 796.0D, 918.0D, 1_040.0D, 1_162.0D, 1_283.0D, 1_405.0D, 1_527.0D, 1_649.0D, 1_771.0D, 1_893.0D),
                    new ArtifactStatRarityData(100.0D, 115.0D, 129.0D, 143.0D)
                ),
                new(
                    4,
                    new ArtifactStatRarityData(645.0D, 828.0D, 1_011.0D, 1_194.0D, 1_377.0D, 1_559.0D, 1_742.0D, 1_925.0D, 2_108.0D, 2_291.0D, 2_474.0D, 2_657.0D, 2_839.0D, 3_022.0D, 3_205.0D, 3_388.0D, 3_571.0D),
                    new ArtifactStatRarityData(167.0D, 191.0D, 215.0D, 239.0D)
                ),
                new(
                    5,
                    new ArtifactStatRarityData(717.0D, 920.0D, 1_123.0D, 1_326.0D, 1_530.0D, 1_733.0D, 1_936.0D, 2_139.0D, 2_342.0D, 2_545.0D, 2_749.0D, 2_952.0D, 3_155.0D, 3_358.0D, 3_561.0D, 3_764.0D, 3_967.0D, 4_171.0D, 4_374.0D, 4_577.0D, 4_780.0D),
                    new ArtifactStatRarityData(209.0D, 239.0D, 269.0D, 299.0D)
                )
            }
        );

        public static readonly ArtifactStat PercentageAttack = new(
            "ATK",
            '%',
            new List<ArtifactStatRarity>
            {
                new(
                    1,
                    new ArtifactStatRarityData(3.1D, 4.3D, 5.5D, 6.7D, 7.9D),
                    new ArtifactStatRarityData(1.2D, 1.5D)
                ),
                new(
                    2,
                    new ArtifactStatRarityData(4.2D, 5.4D, 6.6D, 7.8D, 9.0D, 10.1D, 11.3D, 12.5D, 13.7D),
                    new ArtifactStatRarityData(1.6D, 2.0D, 2.3D)
                ),
                new(
                    3,
                    new ArtifactStatRarityData(5.2D, 6.7D, 8.2D, 9.7D, 11.2D, 12.7D, 14.2D, 15.6D, 17.1D, 18.6D, 20.1D, 21.6D, 23.1D),
                    new ArtifactStatRarityData(2.5D, 2.8D, 3.2D, 3.5D)
                ),
                new(
                    4,
                    new ArtifactStatRarityData(6.3D, 8.1D, 9.9D, 11.6D, 13.4D, 15.2D, 17.0D, 18.8D, 20.6D, 22.3D, 24.1D, 25.9D, 27.7D, 29.5D, 31.3D, 33.0D, 34.8D),
                    new ArtifactStatRarityData(3.3D, 3.7D, 4.2D, 4.7D)
                ),
                new(
                    5,
                    new ArtifactStatRarityData(7.0D, 9.0D, 11.0D, 12.9D, 14.9D, 16.9D, 18.9D, 20.9D, 22.8D, 24.8D, 26.8D, 28.8D, 30.8D, 32.8D, 34.7D, 36.7D, 38.7D, 40.7D, 42.7D, 44.6D, 46.6D),
                    new ArtifactStatRarityData(4.1D, 4.7D, 5.3D, 5.8D)
                )
            }
        );

        public static readonly ArtifactStat FlatAttack = new(
            "ATK",
            null,
            new List<ArtifactStatRarity>
            {
                new(
                    1,
                    new ArtifactStatRarityData(8.0D, 12.0D, 15.0D, 18.8D, 21.0D),
                    new ArtifactStatRarityData(2.0D, 2.0D)
                ),
                new(
                    2,
                    new ArtifactStatRarityData(17.0D, 22.0D, 26.0D, 31.0D, 36.0D, 41.0D, 45.0D, 50.0D, 55.0D),
                    new ArtifactStatRarityData(3.0D, 4.0D, 5.0D)
                ),
                new(
                    3,
                    new ArtifactStatRarityData(28.0D, 36.0D, 44.0D, 52.0D, 60.0D, 68.0D, 76.0D, 84.0D, 91.0D, 99.0D, 107.0D, 115.0D, 123.0D),
                    new ArtifactStatRarityData(7.0D, 7.0D, 8.0D, 9.0D)
                ),
                new(
                    4,
                    new ArtifactStatRarityData(42.0D, 54.0D, 66.0D, 78.0D, 90.0D, 102.0D, 113.0D, 125.0D, 137.0D, 149.0D, 161.0D, 173.0D, 185.0D, 197.0D, 209.0D, 221.0D, 232.0D),
                    new ArtifactStatRarityData(11.0D, 12.0D, 14.0D, 16.0D)
                ),
                new(
                    5,
                    new ArtifactStatRarityData(47.0D, 60.0D, 73.0D, 86.0D, 100.0D, 113.0D, 126.0D, 139.0D, 152.0D, 166.0D, 179.0D, 192.0D, 205.0D, 219.0D, 232.0D, 245.0D, 258.0D, 272.0D, 285.0D, 298.0D, 311.0D),
                    new ArtifactStatRarityData(14.0D, 16.0D, 18.0D, 19.0D)
                )
            }
        );

        public static readonly ArtifactStat PercentageDefense = new(
            "DEF",
            '%',
            new List<ArtifactStatRarity>
            {
                new(
                    1,
                    new ArtifactStatRarityData(3.9D, 5.4D, 6.9D, 8.4D, 9.9D),
                    new ArtifactStatRarityData(1.5D, 1.8D)
                ),
                new(
                    2,
                    new ArtifactStatRarityData(5.2D, 6.7D, 8.2D, 9.7D, 11.2D, 12.7D, 14.2D, 15.6D, 17.1D),
                    new ArtifactStatRarityData(2.0D, 2.5D, 2.9D)
                ),
                new(
                    3,
                    new ArtifactStatRarityData(6.6D, 8.4D, 10.3D, 12.1D, 14.0D, 15.8D, 17.7D, 19.6D, 21.4D, 23.3D, 25.1D, 27.0D, 28.8D),
                    new ArtifactStatRarityData(3.1D, 3.5D, 3.9D, 4.4D)
                ),
                new(
                    4,
                    new ArtifactStatRarityData(7.9D, 10.1D, 12.3D, 14.6D, 16.8D, 19.0D, 21.2D, 23.5D, 25.7D, 27.9D, 30.2D, 32.4D, 34.6D, 36.8D, 39.1D, 41.3D, 43.5D),
                    new ArtifactStatRarityData(4.1D, 4.7D, 5.3D, 5.8D)
                ),
                new(
                    5,
                    new ArtifactStatRarityData(8.7D, 11.2D, 13.7D, 16.2D, 18.6D, 21.1D, 23.6D, 26.1D, 28.6D, 31.0D, 33.5D, 36.0D, 38.5D, 40.9D, 43.4D, 45.9D, 48.4D, 50.8D, 53.3D, 55.8D, 58.3D),
                    new ArtifactStatRarityData(5.1D, 5.8D, 6.6D, 7.3D)
                )
            }
        );

        public static readonly ArtifactStat FlatDefense = new(
            "DEF",
            null,
            new List<ArtifactStatRarity>
            {
                new(
                    1,
                    null,
                    new ArtifactStatRarityData(2.0D, 2.0D)
                ),
                new(
                    2,
                    null,
                    new ArtifactStatRarityData(4.0D, 5.0D, 6.0D)
                ),
                new(
                    3,
                    null,
                    new ArtifactStatRarityData(8.0D, 9.0D, 10.0D, 11.0D)
                ),
                new(
                    4,
                    null,
                    new ArtifactStatRarityData(13.0D, 15.0D, 17.0D, 19.0D)
                ),
                new(
                    5,
                    null,
                    new ArtifactStatRarityData(16.0D, 19.0D, 21.0D, 23.0D)
                )
            }
        );

        public static readonly ArtifactStat ElementalMastery = new(
            "Elemental Mastery",
            null,
            new List<ArtifactStatRarity>
            {
                new(
                    1,
                    new ArtifactStatRarityData(13.0D, 17.0D, 22.0D, 27.0D, 32.0D),
                    new ArtifactStatRarityData(5.0D, 6.0D)
                ),
                new(
                    2,
                    new ArtifactStatRarityData(17.0D, 22.0D, 26.0D, 31.0D, 36.0D, 41.0D, 45.0D, 50.0D, 55.0D),
                    new ArtifactStatRarityData(7.0D, 8.0D, 9.0D)
                ),
                new(
                    3,
                    new ArtifactStatRarityData(21.0D, 27.0D, 33.0D, 39.0D, 45.0D, 51.0D, 57.0D, 63.0D, 69.0D, 75.0D, 80.0D, 86.0D, 92.0D),
                    new ArtifactStatRarityData(10.0D, 11.0D, 13.0D, 14.0D)
                ),
                new(
                    4,
                    new ArtifactStatRarityData(25.0D, 32.0D, 39.0D, 47.0D, 54.0D, 61.0D, 68.0D, 75.0D, 82.0D, 89.0D, 97.0D, 104.0D, 111.0D, 118.0D, 125.0D, 132.0D, 139.0D),
                    new ArtifactStatRarityData(13.0D, 15.0D, 17.0D, 19.0D)
                ),
                new(
                    5,
                    new ArtifactStatRarityData(28.0D, 36.0D, 44.0D, 52.0D, 60.0D, 68.0D, 76.0D, 84.0D, 91.0D, 99.0D, 107.0D, 115.0D, 123.0D, 131.0D, 139.0D, 147.0D, 155.0D, 163.0D, 171.0D, 179.0D, 187.0D),
                    new ArtifactStatRarityData(16.0D, 19.0D, 21.0D, 23.0D)
                )
            }
        );

        public static readonly ArtifactStat EnergyRecharge = new(
            "Energy Recharge",
            '%',
            new List<ArtifactStatRarity>
            {
                new(
                    1,
                    new ArtifactStatRarityData(3.5D, 4.8D, 6.1D, 7.5D, 8.8D),
                    new ArtifactStatRarityData(1.3D, 1.6D)
                ),
                new(
                    2,
                    new ArtifactStatRarityData(4.7D, 6.0D, 7.3D, 8.6D, 9.9D, 11.3D, 12.6D, 13.9D, 15.2D),
                    new ArtifactStatRarityData(1.8D, 2.2D, 2.6D)
                ),
                new(
                    3,
                    new ArtifactStatRarityData(5.8D, 7.5D, 9.1D, 10.8D, 12.4D, 14.1D, 15.7D, 17.4D, 19.0D, 20.7D, 22.3D, 24.0D, 25.6D),
                    new ArtifactStatRarityData(2.7D, 3.1D, 3.5D, 3.9D)
                ),
                new(
                    4,
                    new ArtifactStatRarityData(7.0D, 9.0D, 11.0D, 12.9D, 14.9D, 16.9D, 18.9D, 20.9D, 22.8D, 24.8D, 26.8D, 28.8D, 30.8D, 32.8D, 34.7D, 36.7D, 38.7D),
                    new ArtifactStatRarityData(3.6D, 4.1D, 4.7D, 5.2D)
                ),
                new(
                    5,
                    new ArtifactStatRarityData(7.8D, 10.0D, 12.2D, 14.4D, 16.6D, 18.8D, 21.0D, 23.2D, 25.4D, 27.6D, 29.8D, 32.0D, 34.2D, 36.4D, 38.6D, 40.8D, 43.0D, 45.2D, 47.4D, 49.6D, 51.8D),
                    new ArtifactStatRarityData(4.5D, 5.2D, 5.8D, 6.5D)
                )
            }
        );

        public static readonly ArtifactStat PhysicalDamageBonus = new(
            "Physical DMG Bonus",
            '%',
            new List<ArtifactStatRarity>
            {
                new(
                    1,
                    new ArtifactStatRarityData(3.9D, 5.4D, 6.9D, 8.4D, 9.9D),
                    null
                ),
                new(
                    2,
                    new ArtifactStatRarityData(5.2D, 6.7D, 8.2D, 9.7D, 11.2D, 12.7D, 14.2D, 15.6D, 17.1D),
                    null
                ),
                new(
                    3,
                    new ArtifactStatRarityData(6.6D, 8.4D, 10.3D, 12.1D, 14.0D, 15.8D, 17.7D, 19.6D, 21.4D, 23.3D, 25.1D, 27.0D, 28.8D),
                    null
                ),
                new(
                    4,
                    new ArtifactStatRarityData(7.9D, 10.1D, 12.3D, 14.6D, 16.8D, 19.0D, 21.2D, 23.5D, 25.7D, 27.9D, 30.2D, 32.4D, 34.6D, 36.8D, 39.1D, 41.3D, 43.5D),
                    null
                ),
                new(
                    5,
                    new ArtifactStatRarityData(8.7D, 11.2D, 13.7D, 16.2D, 18.6D, 21.1D, 23.6D, 26.1D, 28.6D, 31.0D, 33.5D, 36.0D, 38.5D, 40.9D, 43.4D, 45.9D, 48.4D, 50.8D, 53.3D, 55.8D, 58.3D),
                    null
                )
            }
        );

        public static readonly ArtifactStat PyroDamageBonus = new(
            "Pyro DMG Bonus",
            '%',
            new List<ArtifactStatRarity>
            {
                new(
                    1,
                    new ArtifactStatRarityData(3.1D, 4.3D, 5.5D, 6.7D, 7.9D),
                    null
                ),
                new(
                    2,
                    new ArtifactStatRarityData(4.2D, 5.4D, 6.6D, 7.8D, 9.0D, 10.1D, 11.3D, 12.5D, 13.7D),
                    null
                ),
                new(
                    3,
                    new ArtifactStatRarityData(5.2D, 6.7D, 8.2D, 9.7D, 11.2D, 12.7D, 14.2D, 15.6D, 17.1D, 18.6D, 20.1D, 21.6D, 23.1D),
                    null
                ),
                new(
                    4,
                    new ArtifactStatRarityData(6.3D, 8.1D, 9.9D, 11.6D, 13.4D, 15.2D, 17.0D, 18.8D, 20.6D, 22.3D, 24.1D, 25.9D, 27.7D, 29.5D, 31.3D, 33.0D, 34.8D),
                    null
                ),
                new(
                    5,
                    new ArtifactStatRarityData(7.0D, 9.0D, 11.0D, 12.9D, 14.9D, 16.9D, 18.9D, 20.9D, 22.8D, 24.8D, 26.8D, 28.8D, 30.8D, 32.8D, 34.7D, 36.7D, 38.7D, 40.7D, 42.7D, 44.6D, 46.6D),
                    null
                )
            }
        );

        public static readonly ArtifactStat HydroDamageBonus = new(
            "Hydro DMG Bonus",
            '%',
            new List<ArtifactStatRarity>
            {
                new(
                    1,
                    new ArtifactStatRarityData(3.1D, 4.3D, 5.5D, 6.7D, 7.9D),
                    null
                ),
                new(
                    2,
                    new ArtifactStatRarityData(4.2D, 5.4D, 6.6D, 7.8D, 9.0D, 10.1D, 11.3D, 12.5D, 13.7D),
                    null
                ),
                new(
                    3,
                    new ArtifactStatRarityData(5.2D, 6.7D, 8.2D, 9.7D, 11.2D, 12.7D, 14.2D, 15.6D, 17.1D, 18.6D, 20.1D, 21.6D, 23.1D),
                    null
                ),
                new(
                    4,
                    new ArtifactStatRarityData(6.3D, 8.1D, 9.9D, 11.6D, 13.4D, 15.2D, 17.0D, 18.8D, 20.6D, 22.3D, 24.1D, 25.9D, 27.7D, 29.5D, 31.3D, 33.0D, 34.8D),
                    null
                ),
                new(
                    5,
                    new ArtifactStatRarityData(7.0D, 9.0D, 11.0D, 12.9D, 14.9D, 16.9D, 18.9D, 20.9D, 22.8D, 24.8D, 26.8D, 28.8D, 30.8D, 32.8D, 34.7D, 36.7D, 38.7D, 40.7D, 42.7D, 44.6D, 46.6D),
                    null
                )
            }
        );

        public static readonly ArtifactStat AnemoDamageBonus = new(
            "Anemo DMG Bonus",
            '%',
            new List<ArtifactStatRarity>
            {
                new(
                    1,
                    new ArtifactStatRarityData(3.1D, 4.3D, 5.5D, 6.7D, 7.9D),
                    null
                ),
                new(
                    2,
                    new ArtifactStatRarityData(4.2D, 5.4D, 6.6D, 7.8D, 9.0D, 10.1D, 11.3D, 12.5D, 13.7D),
                    null
                ),
                new(
                    3,
                    new ArtifactStatRarityData(5.2D, 6.7D, 8.2D, 9.7D, 11.2D, 12.7D, 14.2D, 15.6D, 17.1D, 18.6D, 20.1D, 21.6D, 23.1D),
                    null
                ),
                new(
                    4,
                    new ArtifactStatRarityData(6.3D, 8.1D, 9.9D, 11.6D, 13.4D, 15.2D, 17.0D, 18.8D, 20.6D, 22.3D, 24.1D, 25.9D, 27.7D, 29.5D, 31.3D, 33.0D, 34.8D),
                    null
                ),
                new(
                    5,
                    new ArtifactStatRarityData(7.0D, 9.0D, 11.0D, 12.9D, 14.9D, 16.9D, 18.9D, 20.9D, 22.8D, 24.8D, 26.8D, 28.8D, 30.8D, 32.8D, 34.7D, 36.7D, 38.7D, 40.7D, 42.7D, 44.6D, 46.6D),
                    null
                )
            }
        );

        public static readonly ArtifactStat ElectroDamageBonus = new(
            "Electro DMG Bonus",
            '%',
            new List<ArtifactStatRarity>
            {
                new(
                    1,
                    new ArtifactStatRarityData(3.1D, 4.3D, 5.5D, 6.7D, 7.9D),
                    null
                ),
                new(
                    2,
                    new ArtifactStatRarityData(4.2D, 5.4D, 6.6D, 7.8D, 9.0D, 10.1D, 11.3D, 12.5D, 13.7D),
                    null
                ),
                new(
                    3,
                    new ArtifactStatRarityData(5.2D, 6.7D, 8.2D, 9.7D, 11.2D, 12.7D, 14.2D, 15.6D, 17.1D, 18.6D, 20.1D, 21.6D, 23.1D),
                    null
                ),
                new(
                    4,
                    new ArtifactStatRarityData(6.3D, 8.1D, 9.9D, 11.6D, 13.4D, 15.2D, 17.0D, 18.8D, 20.6D, 22.3D, 24.1D, 25.9D, 27.7D, 29.5D, 31.3D, 33.0D, 34.8D),
                    null
                ),
                new(
                    5,
                    new ArtifactStatRarityData(7.0D, 9.0D, 11.0D, 12.9D, 14.9D, 16.9D, 18.9D, 20.9D, 22.8D, 24.8D, 26.8D, 28.8D, 30.8D, 32.8D, 34.7D, 36.7D, 38.7D, 40.7D, 42.7D, 44.6D, 46.6D),
                    null
                )
            }
        );

        public static readonly ArtifactStat DendroDamageBonus = new(
            "Dendro DMG Bonus",
            '%',
            new List<ArtifactStatRarity>
            {
                new(
                    1,
                    new ArtifactStatRarityData(3.1D, 4.3D, 5.5D, 6.7D, 7.9D),
                    null
                ),
                new(
                    2,
                    new ArtifactStatRarityData(4.2D, 5.4D, 6.6D, 7.8D, 9.0D, 10.1D, 11.3D, 12.5D, 13.7D),
                    null
                ),
                new(
                    3,
                    new ArtifactStatRarityData(5.2D, 6.7D, 8.2D, 9.7D, 11.2D, 12.7D, 14.2D, 15.6D, 17.1D, 18.6D, 20.1D, 21.6D, 23.1D),
                    null
                ),
                new(
                    4,
                    new ArtifactStatRarityData(6.3D, 8.1D, 9.9D, 11.6D, 13.4D, 15.2D, 17.0D, 18.8D, 20.6D, 22.3D, 24.1D, 25.9D, 27.7D, 29.5D, 31.3D, 33.0D, 34.8D),
                    null
                ),
                new(
                    5,
                    new ArtifactStatRarityData(7.0D, 9.0D, 11.0D, 12.9D, 14.9D, 16.9D, 18.9D, 20.9D, 22.8D, 24.8D, 26.8D, 28.8D, 30.8D, 32.8D, 34.7D, 36.7D, 38.7D, 40.7D, 42.7D, 44.6D, 46.6D),
                    null
                )
            }
        );

        public static readonly ArtifactStat CryoDamageBonus = new(
            "Cryo DMG Bonus",
            '%',
            new List<ArtifactStatRarity>
            {
                new(
                    1,
                    new ArtifactStatRarityData(3.1D, 4.3D, 5.5D, 6.7D, 7.9D),
                    null
                ),
                new(
                    2,
                    new ArtifactStatRarityData(4.2D, 5.4D, 6.6D, 7.8D, 9.0D, 10.1D, 11.3D, 12.5D, 13.7D),
                    null
                ),
                new(
                    3,
                    new ArtifactStatRarityData(5.2D, 6.7D, 8.2D, 9.7D, 11.2D, 12.7D, 14.2D, 15.6D, 17.1D, 18.6D, 20.1D, 21.6D, 23.1D),
                    null
                ),
                new(
                    4,
                    new ArtifactStatRarityData(6.3D, 8.1D, 9.9D, 11.6D, 13.4D, 15.2D, 17.0D, 18.8D, 20.6D, 22.3D, 24.1D, 25.9D, 27.7D, 29.5D, 31.3D, 33.0D, 34.8D),
                    null
                ),
                new(
                    5,
                    new ArtifactStatRarityData(7.0D, 9.0D, 11.0D, 12.9D, 14.9D, 16.9D, 18.9D, 20.9D, 22.8D, 24.8D, 26.8D, 28.8D, 30.8D, 32.8D, 34.7D, 36.7D, 38.7D, 40.7D, 42.7D, 44.6D, 46.6D),
                    null
                )
            }
        );

        public static readonly ArtifactStat GeoDamageBonus = new(
            "Geo DMG Bonus",
            '%',
            new List<ArtifactStatRarity>
            {
                new(
                    1,
                    new ArtifactStatRarityData(3.1D, 4.3D, 5.5D, 6.7D, 7.9D),
                    null
                ),
                new(
                    2,
                    new ArtifactStatRarityData(4.2D, 5.4D, 6.6D, 7.8D, 9.0D, 10.1D, 11.3D, 12.5D, 13.7D),
                    null
                ),
                new(
                    3,
                    new ArtifactStatRarityData(5.2D, 6.7D, 8.2D, 9.7D, 11.2D, 12.7D, 14.2D, 15.6D, 17.1D, 18.6D, 20.1D, 21.6D, 23.1D),
                    null
                ),
                new(
                    4,
                    new ArtifactStatRarityData(6.3D, 8.1D, 9.9D, 11.6D, 13.4D, 15.2D, 17.0D, 18.8D, 20.6D, 22.3D, 24.1D, 25.9D, 27.7D, 29.5D, 31.3D, 33.0D, 34.8D),
                    null
                ),
                new(
                    5,
                    new ArtifactStatRarityData(7.0D, 9.0D, 11.0D, 12.9D, 14.9D, 16.9D, 18.9D, 20.9D, 22.8D, 24.8D, 26.8D, 28.8D, 30.8D, 32.8D, 34.7D, 36.7D, 38.7D, 40.7D, 42.7D, 44.6D, 46.6D),
                    null
                )
            }
        );

        public static readonly ArtifactStat CriticalRate = new(
            "CRIT Rate",
            '%',
            new List<ArtifactStatRarity>
            {
                new(
                    1,
                    new ArtifactStatRarityData(2.1D, 2.9D, 3.7D, 4.5D, 5.3D),
                    new ArtifactStatRarityData(0.8D, 1.0D)
                ),
                new(
                    2,
                    new ArtifactStatRarityData(2.8D, 3.6D, 4.4D, 5.2D, 6.0D, 6.8D, 7.6D, 8.3D, 9.1D),
                    new ArtifactStatRarityData(1.1D, 1.3D, 1.6D)
                ),
                new(
                    3,
                    new ArtifactStatRarityData(3.5D, 4.5D, 5.5D, 6.5D, 7.5D, 8.4D, 9.4D, 10.4D, 11.4D, 12.4D, 13.4D, 14.4D, 15.4D),
                    new ArtifactStatRarityData(1.6D, 1.9D, 2.1D, 2.3D)
                ),
                new(
                    4,
                    new ArtifactStatRarityData(4.2D, 5.4D, 6.6D, 7.8D, 9.0D, 10.1D, 11.3D, 12.5D, 13.7D, 14.9D, 16.1D, 17.3D, 18.5D, 19.7D, 20.8D, 22.0D, 23.2D),
                    new ArtifactStatRarityData(2.2D, 2.5D, 2.8D, 3.1D)
                ),
                new(
                    5,
                    new ArtifactStatRarityData(4.7D, 6.0D, 7.4D, 8.7D, 10.0D, 11.4D, 12.7D, 14.0D, 15.4D, 16.7D, 18.0D, 19.3D, 20.7D, 22.0D, 23.3D, 24.7D, 26.0D, 27.3D, 28.7D, 30.0D, 31.1D),
                    new ArtifactStatRarityData(2.7D, 3.1D, 3.5D, 3.9D)
                )
            }
        );

        public static readonly ArtifactStat CriticalDamage = new(
            "CRIT DMG",
            '%',
            new List<ArtifactStatRarity>
            {
                new(
                    1,
                    new ArtifactStatRarityData(4.2D, 5.8D, 7.4D, 9.0D, 10.5D),
                    new ArtifactStatRarityData(1.6D, 1.9D)
                ),
                new(
                    2,
                    new ArtifactStatRarityData(5.6D, 7.2D, 8.8D, 10.4D, 11.9D, 13.5D, 15.1D, 16.7D, 18.3D),
                    new ArtifactStatRarityData(2.2D, 2.6D, 3.1D)
                ),
                new(
                    3,
                    new ArtifactStatRarityData(7.0D, 9.0D, 11.0D, 12.9D, 14.9D, 16.9D, 18.9D, 20.9D, 22.8D, 24.8D, 26.8D, 28.8D, 30.8D),
                    new ArtifactStatRarityData(3.3D, 3.7D, 4.2D, 4.7D)
                ),
                new(
                    4,
                    new ArtifactStatRarityData(8.4D, 10.8D, 13.1D, 15.5D, 17.9D, 20.3D, 22.7D, 25.0D, 27.4D, 29.8D, 32.2D, 34.5D, 36.9D, 39.3D, 41.7D, 44.1D, 46.4D),
                    new ArtifactStatRarityData(4.4D, 5.0D, 5.6D, 6.2D)
                ),
                new(
                    5,
                    new ArtifactStatRarityData(9.3D, 11.9D, 14.6D, 17.2D, 19.9D, 22.5D, 25.2D, 27.8D, 30.5D, 33.1D, 35.8D, 38.4D, 41.1D, 43.7D, 46.3D, 49.0D, 51.6D, 54.3D, 56.9D, 59.6D, 62.2D),
                    new ArtifactStatRarityData(5.4D, 6.2D, 7.0D, 7.8D)
                )
            }
        );

        public static readonly ArtifactStat HealingBonus = new(
            "Healing Bonus",
            '%',
            new List<ArtifactStatRarity>
            {
                new(
                    1,
                    new ArtifactStatRarityData(2.4D, 3.3D, 4.3D, 5.2D, 6.1D),
                    null
                ),
                new(
                    2,
                    new ArtifactStatRarityData(3.2D, 4.1D, 5.1D, 6.0D, 6.9D, 7.8D, 8.7D, 9.6D, 10.5D),
                    null
                ),
                new(
                    3,
                    new ArtifactStatRarityData(4.0D, 5.2D, 6.3D, 7.5D, 8.6D, 9.8D, 10.9D, 12.0D, 13.2D, 14.3D, 15.5D, 16.6D, 17.8D),
                    null
                ),
                new(
                    4,
                    new ArtifactStatRarityData(4.8D, 6.2D, 7.6D, 9.0D, 10.3D, 11.7D, 13.1D, 14.4D, 15.8D, 17.2D, 18.6D, 19.9D, 21.3D, 22.7D, 24.0D, 25.4D, 26.8D),
                    null
                ),
                new(
                    5,
                    new ArtifactStatRarityData(5.4D, 6.9D, 8.4D, 10.0D, 13.0D, 14.5D, 16.1D, 17.6D, 19.1D, 20.6D, 22.2D, 23.7D, 25.2D, 26.7D, 28.3D, 29.8D, 31.3D, 32.8D, 34.4D, 35.9D),
                    null
                )
            }
        );

        private static readonly ArtifactStat[] Values =
        {
            PercentageHealth,
            FlatHealth,
            PercentageAttack,
            FlatAttack,
            PercentageDefense,
            FlatDefense,
            ElementalMastery,
            EnergyRecharge,
            PhysicalDamageBonus,
            PyroDamageBonus,
            HydroDamageBonus,
            AnemoDamageBonus,
            ElectroDamageBonus,
            DendroDamageBonus,
            CryoDamageBonus,
            GeoDamageBonus,
            CriticalRate,
            CriticalDamage,
            HealingBonus
        };

        public static ArtifactStat? Parse(string? name)
        {
            if (name == null)
            {
                return null;
            }
            foreach (ArtifactStat stat in Values)
            {
                if (name.StartsWith(stat.Name, StringComparison.OrdinalIgnoreCase) && (stat.Symbol == null || name.Contains(stat.Symbol.Value)))
                {
                    return stat;
                }
                int levenshteinDistance = Utils.ComputeLevenshteinDistance(name, stat.Name);
                if (levenshteinDistance <= 1)
                {
                    return stat;
                }
            }
            return null;
        }

        public static ArtifactStat? ParseExact(string? name)
        {
            if (name == null)
            {
                return null;
            }
            foreach (ArtifactStat value in Values)
            {
                string valueName = value.Name;
                if (value.Symbol != null)
                {
                    valueName += value.Symbol;
                }
                if (name.Equals(valueName, StringComparison.OrdinalIgnoreCase))
                {
                    return value;
                }
            }
            return null;
        }
    }
}
