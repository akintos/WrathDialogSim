using System;

namespace Kingmaker.UnitLogic.Alignments
{
	[Flags]
	public enum AlignmentMaskType
	{
		LawfulGood = 1,
		NeutralGood = 2,
		ChaoticGood = 4,
		LawfulNeutral = 8,
		TrueNeutral = 16,
		ChaoticNeutral = 32,
		LawfulEvil = 64,
		NeutralEvil = 128,
		ChaoticEvil = 256,
		Good = 7,
		Evil = 448,
		Lawful = 73,
		Chaotic = 292,
		Any = 511,
		None = 0
	}
}
