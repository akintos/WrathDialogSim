using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kingmaker.Kingdom.Blueprints;
using Newtonsoft.Json;

namespace Kingmaker.Kingdom
{
	[JsonObject]
	[Serializable]
	public class KingdomStats : IEnumerable<KingdomStats.Stat>, IEnumerable
	{
		public static T[] FixArray<T>(T[] array)
		{
			if (array.Length > 4 && KingdomStats.FromTool)
			{
				T[] array2 = array;
				array = new T[4];
				int num = 0;
				int num2 = 0;
				while (num2 < array2.Length && num2 < 5)
				{
					if (num2 != 2)
					{
						array[num] = array2[num2];
						num++;
					}
					num2++;
				}
				KingdomStats.WasFixed = true;
			}
			return array;
		}

		public KingdomStats()
		{
			this.m_Stats = (from KingdomStats.Type t in Enum.GetValues(typeof(KingdomStats.Type))
							select new KingdomStats.Stat(t)).ToArray<KingdomStats.Stat>();
		}

		public KingdomStats.Stat this[KingdomStats.Type t]
		{
			get
			{
				if (t < KingdomStats.Type.Leadership)
				{
					return null;
				}
				return this.m_Stats[(int)t];
			}
		}

		public IEnumerator<KingdomStats.Stat> GetEnumerator()
		{
			return this.m_Stats.Cast<KingdomStats.Stat>().GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.GetEnumerator();
		}

		public void Fix()
		{
			this.m_Stats = KingdomStats.FixArray<KingdomStats.Stat>(this.m_Stats);
		}

		public const int Count = 4;

		public static bool FromTool;

		public static bool WasFixed;

		[JsonProperty]
		private KingdomStats.Stat[] m_Stats;

		public enum Type
		{
			Leadership,
			Strategy,
			Diplomacy,
			Military
		}

		public class Stat
		{
			public Stat(KingdomStats.Type type)
			{
				this.Type = type;
			}

			[JsonProperty]
			public readonly KingdomStats.Type Type;

			[JsonProperty]
			public int Rank;

			[JsonProperty]
			public int Value;
		}

		[Serializable]
		public class Changes
		{
			public bool IsEmpty
			{
				get
				{
					if (this.ResourcesPerTurn.Any())
					{
						return false;
					}
					if (this.ResourcesOneTime.Any())
					{
						return false;
					}
					for (int i = 0; i < this.m_Changes.Length; i++)
					{
						if (this.m_Changes[i] != 0)
						{
							return false;
						}
					}
					return true;
				}
			}

			public string ToStringWithPrefix(string prefix)
			{
				StringBuilder stringBuilder = new StringBuilder();
				for (int i = 0; i < this.m_Changes.Length; i++)
				{
					if (this.m_Changes[i] != 0)
					{
						stringBuilder.Append(prefix).AppendFormat("{1} {0:'+'0;'-'0;0}", this.m_Changes[i], (KingdomStats.Type)i);
					}
				}
				if (this.ResourcesPerTurn.Any())
				{
					stringBuilder.Append(prefix).AppendFormat("{0:'+'0;'-'0;0} BP each turn", this.ResourcesPerTurn);
				}
				if (this.ResourcesOneTime.Any())
				{
					stringBuilder.Append(prefix).AppendFormat("{1} {0:0;0;0} BP", this.ResourcesOneTime, this.ResourcesOneTime.IsPositive ? "Gained" : "Lost");
				}
				return ((stringBuilder != null) ? stringBuilder.ToString() : null) ?? "";
			}


			private int[] m_Changes = new int[4];

			public KingdomResourcesAmount ResourcesPerTurn;

			public KingdomResourcesAmount ResourcesOneTime;
		}
	}
}
