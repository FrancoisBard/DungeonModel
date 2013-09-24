using System;
using System.Collections.Generic;
using System.Linq;

namespace DungeonModel
{
    [Flags]
    public enum AlignmentGoodAxis
    {
        None = 0,
        Good = 1,
        Neutral = 2,
        Evil = 4,
        All = 7
    }

    [Flags]
    public enum AlignmentLawAxis
    {
        None = 0,
        Lawful = 1,
        Neutral = 2,
        Chaotic = 4,
        All = 7
    }

    [Flags]
    public enum Alignment
    {
        None = 0,
        LawfulGood = 1,
        NeutralGood = 2,
        ChaoticGood = 4,
        LawfulNeutral = 8,
        Neutral = 16,
        ChaoticNeutral = 32,
        LawfulEvil = 64,
        NeutralEvil = 128,
        ChaoticEvil = 256,

        Good = LawfulGood | NeutralGood | ChaoticGood,
        NeutralGoodAxis = LawfulNeutral | Neutral | ChaoticNeutral,
        Evil = LawfulEvil | NeutralEvil | ChaoticEvil,

        NonGood = NeutralGoodAxis | Evil,
        NonNeutralGoodAxis = Good | Evil,
        NonEvil = NeutralGoodAxis | Good,

        Lawful = LawfulGood | LawfulNeutral | LawfulEvil,
        NeutralLawAxis = NeutralGood | Neutral | NeutralEvil,
        Chaotic = ChaoticGood | ChaoticNeutral | ChaoticEvil,

        NonLawful = NeutralLawAxis | Chaotic,
        NonNeutralLawAxis = Lawful | Chaotic,
        NonChaotic = NeutralLawAxis | Lawful,

        All = Good | NonGood,
    }
    
    public static class AlignmentTools
    {    
        public struct AlignmentInfos
        {
            public AlignmentLawAxis Law;
            public AlignmentGoodAxis Good;
            public string Name;

            public AlignmentInfos(AlignmentLawAxis law, AlignmentGoodAxis good, string name)
            {
                Law = law;
                Good = good;
                Name = name;
            }
        }

        public static readonly Dictionary<Alignment, AlignmentInfos> AlignmentMap = new Dictionary<Alignment, AlignmentInfos>
            {
                {Alignment.LawfulGood, new AlignmentInfos(AlignmentLawAxis.Lawful, AlignmentGoodAxis.Good, "Lawful Good")},
                {Alignment.NeutralGood, new AlignmentInfos(AlignmentLawAxis.Neutral, AlignmentGoodAxis.Neutral, "Neutral Good")},
                {Alignment.ChaoticGood, new AlignmentInfos(AlignmentLawAxis.Chaotic, AlignmentGoodAxis.Evil, "Chaotic Good")},
                {Alignment.LawfulNeutral, new AlignmentInfos(AlignmentLawAxis.Lawful, AlignmentGoodAxis.Good, "Lawful Neutral")},
                {Alignment.Neutral, new AlignmentInfos(AlignmentLawAxis.Neutral, AlignmentGoodAxis.Neutral, "Neutral")},
                {Alignment.ChaoticNeutral, new AlignmentInfos(AlignmentLawAxis.Chaotic, AlignmentGoodAxis.Evil, "Chaotic Neutral")},
                {Alignment.LawfulEvil, new AlignmentInfos(AlignmentLawAxis.Lawful, AlignmentGoodAxis.Good, "lawful Evil")},
                {Alignment.NeutralEvil, new AlignmentInfos(AlignmentLawAxis.Neutral, AlignmentGoodAxis.Neutral, "Neutral Evil")},
                {Alignment.ChaoticEvil, new AlignmentInfos(AlignmentLawAxis.Chaotic, AlignmentGoodAxis.Evil, "Chaotic Evil")},
            };

        public static readonly Dictionary<AlignmentGoodAxis, string> AlignmentGoodAxisNames = new Dictionary<AlignmentGoodAxis, string>
            {
                {AlignmentGoodAxis.Good, "Good"},
                {AlignmentGoodAxis.Neutral, "Neutral"},
                {AlignmentGoodAxis.Evil, "Evil"},
            };

        public static readonly Dictionary<AlignmentLawAxis, string> AlignmentLawAxisNames = new Dictionary<AlignmentLawAxis, string>
            {
                {AlignmentLawAxis.Lawful, "Lawful"},
                {AlignmentLawAxis.Neutral, "Neutral"},
                {AlignmentLawAxis.Chaotic, "Chaotic"},
            };

        public static Alignment FromAxes(AlignmentLawAxis lawAxis, AlignmentGoodAxis goodAxis)
        {
            return AlignmentMap.First(kvp => (kvp.Value.Law == lawAxis) && (kvp.Value.Good == goodAxis)).Key;
        }

        public static AlignmentGoodAxis GoodAxis(this Alignment alignment)
        {
            return AlignmentMap[alignment].Good;
        }

        public static AlignmentLawAxis LawAxis(this Alignment alignment)
        {
            return AlignmentMap[alignment].Law;
        }

        //ToString won't do because the ToString() from the enum class will be called before the extension method...
        public static string ToLocalizedString(this Alignment alignment)
        {
            return AlignmentMap[alignment].Name;
        }

        //ToString won't do because the ToString() from the enum class will be called before the extension method...
        public static string ToLocalizedString(this AlignmentGoodAxis alignmentGoodAxis)
        {
            return AlignmentGoodAxisNames[alignmentGoodAxis];
        }

        //ToString won't do because the ToString() from the enum class will be called before the extension method...
        public static string ToLocalizedString(this AlignmentLawAxis alignmentLawAxis)
        {
            return AlignmentLawAxisNames[alignmentLawAxis];
        }
    }
}
