using System;
using Newtonsoft.Json;

namespace Kingmaker.RuleSystem
{
	[Serializable]
	public struct DiceFormula
	{
		public int Rolls
		{
			get
			{
				if (this.m_Dice != DiceType.Zero)
				{
					return this.m_Rolls;
				}
				return 0;
			}
		}

		public DiceType Dice
		{
			get
			{
				return this.m_Dice;
			}
		}

		public DiceFormula(int rollsCount, DiceType diceType)
		{
			this.m_Rolls = Math.Max(0, rollsCount);
			this.m_Dice = diceType;
		}

		public override string ToString()
		{
			if (!(this == DiceFormula.Zero) && !(this == DiceFormula.One))
			{
				return string.Format("{0}d{1}", this.m_Rolls, (int)this.m_Dice);
			}
			return this.Rolls.ToString();
		}

		public string ToNumString(int bonus, bool halfDamage = false)
		{
			if (!(this == DiceFormula.Zero) && !(this == DiceFormula.One))
			{
				return string.Format("{0}-{1}", this.MinValue(bonus, halfDamage), this.MaxValue(bonus, halfDamage));
			}
			return this.Rolls.ToString();
		}

		public int MinValue(int bonus, bool halfDamage = false)
		{
			int num = (this == DiceFormula.Zero || this == DiceFormula.One) ? this.m_Rolls : Math.Max(this.m_Rolls + bonus, 1);
			if (!halfDamage)
			{
				return num;
			}
			return num / 2;
		}

		public int MaxValue(int bonus, bool halfDamage = false)
		{
			int num = (this == Zero || this == One) ? this.m_Rolls : Math.Max((int)Dice * this.Rolls + bonus, 1);
			if (!halfDamage)
			{
				return num;
			}
			return num / 2;
		}

		public bool Equals(DiceFormula other)
		{
			return m_Rolls == other.m_Rolls && this.m_Dice == other.m_Dice;
		}

		public override bool Equals(object obj)
		{
			return obj != null && obj is DiceFormula formula && Equals(formula);
		}

		public override int GetHashCode()
		{
			return Rolls * 397 ^ (int)this.Dice;
		}

		public static bool operator ==(DiceFormula f1, DiceFormula f2)
		{
			return f1.Equals(f2);
		}

		public static bool operator !=(DiceFormula f1, DiceFormula f2)
		{
			return !(f1 == f2);
		}

		[JsonProperty]
		public int m_Rolls;

		[JsonProperty]
		public DiceType m_Dice;

		public static readonly DiceFormula Zero = new DiceFormula(0, DiceType.Zero);

		public static readonly DiceFormula One = new DiceFormula(1, DiceType.One);
	}
}
