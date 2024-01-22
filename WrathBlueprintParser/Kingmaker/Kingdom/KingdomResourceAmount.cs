using System;
using System.Text;
using Kingmaker.Kingdom.Blueprints;
using Newtonsoft.Json;

namespace Kingmaker.Kingdom
{
	[Serializable]
	public struct KingdomResourcesAmount
	{
		public int Finances
		{
			get
			{
				return this.m_Finances;
			}
		}

		public int Materials
		{
			get
			{
				return this.m_Materials;
			}
		}

		public int Favors
		{
			get
			{
				return this.m_Favors;
			}
		}

		public bool IsPositive
		{
			get
			{
				return this.Any() && this.m_Finances >= 0 && this.m_Materials >= 0 && this.m_Favors >= 0;
			}
		}

		public float Scalar
		{
			get
			{
				return (float)this.m_Finances / 100f + (float)this.m_Materials / 10f + (float)this.m_Favors;
			}
		}

		public static KingdomResourcesAmount FromFinances(int amount)
		{
			return new KingdomResourcesAmount
			{
				m_Finances = amount
			};
		}

		public static KingdomResourcesAmount FromMaterials(int amount)
		{
			return new KingdomResourcesAmount
			{
				m_Materials = amount
			};
		}

		public static KingdomResourcesAmount FromFavors(int amount)
		{
			return new KingdomResourcesAmount
			{
				m_Favors = amount
			};
		}

		public bool IsGreaterOrEqual(KingdomResourcesAmount amount)
		{
			return this.m_Finances >= amount.m_Finances && this.m_Materials >= amount.m_Materials && this.m_Favors >= amount.m_Favors;
		}

		public bool Any()
		{
			return this.m_Finances != 0 || this.m_Materials != 0 || this.m_Favors != 0;
		}

		public int Get(KingdomResource type)
		{
			switch (type)
			{
				case KingdomResource.None:
					return 0;
				case KingdomResource.Finances:
					return this.m_Finances;
				case KingdomResource.Materials:
					return this.m_Materials;
				case KingdomResource.Favors:
					return this.m_Favors;
				default:
					throw new ArgumentOutOfRangeException(nameof(type), type, null);
			}
		}

		public override string ToString()
		{
			if (!Any()) return "none";

			StringBuilder sb = new(100);

			if (m_Finances != default)
			{
				sb.Append($"finance: {m_Finances}");
			}

			if (m_Materials != default)
            {
				if (sb.Length > 0)
					sb.Append(", ");
				sb.Append($"materials: {m_Materials}");
            }

            if (m_Favors != default)
            {
                if (sb.Length > 0)
                    sb.Append(", ");
                sb.Append($"favors: {m_Favors}");
            }

			return sb.ToString();
        }

		public static readonly KingdomResourcesAmount Zero = default(KingdomResourcesAmount);

		[JsonProperty]
		private int m_Finances;

		[JsonProperty]
		private int m_Materials;

		[JsonProperty]
		private int m_Favors;
	}
}
