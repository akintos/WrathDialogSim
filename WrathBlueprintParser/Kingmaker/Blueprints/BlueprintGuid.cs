using System;

namespace Kingmaker.Blueprints
{
	public struct BlueprintGuid : IComparable, IComparable<BlueprintGuid>, IEquatable<BlueprintGuid>
	{
		public BlueprintGuid(Guid guid)
		{
			this.m_Guid = guid;
		}

		public BlueprintGuid(byte[] buf)
		{
			this.m_Guid = new Guid(buf);
		}

		public override string ToString()
		{
			if (!(this.m_Guid == Guid.Empty))
			{
				return this.m_Guid.ToString("N");
			}
			return "";
		}

		public static BlueprintGuid Parse(string str)
		{
			if (string.IsNullOrEmpty(str))
			{
				return BlueprintGuid.Empty;
			}
            if (!Guid.TryParse(str, out Guid guid))
            {
				throw new ArgumentException("Failed to parse blueprint GUID: " + str);
            }
            return new BlueprintGuid(guid);
		}

		public static BlueprintGuid NewGuid()
		{
			return new BlueprintGuid(Guid.NewGuid());
		}

		public int CompareTo(object obj)
		{
			return this.m_Guid.CompareTo(obj);
		}

		public int CompareTo(BlueprintGuid other)
		{
			return this.m_Guid.CompareTo(other.m_Guid);
		}

		public bool Equals(BlueprintGuid other)
		{
			return this.m_Guid == other.m_Guid;
		}

		public static bool operator ==(BlueprintGuid a, BlueprintGuid b)
		{
			return a.Equals(b);
		}

		public static bool operator ==(BlueprintGuid a, string b)
		{
			if (!string.IsNullOrEmpty(b))
			{
				return a.m_Guid == Guid.Parse(b);
			}
			return a.m_Guid == Guid.Empty;
		}

		public static bool operator !=(BlueprintGuid a, BlueprintGuid b)
		{
			return !a.Equals(b);
		}

		public static bool operator !=(BlueprintGuid a, string b)
		{
			return !(a == b);
		}

		public byte[] ToByteArray()
		{
			return this.m_Guid.ToByteArray();
		}

		public override bool Equals(object other)
		{
			return this.m_Guid.Equals(other);
		}

		public override int GetHashCode()
		{
			return this.m_Guid.GetHashCode();
		}

		private readonly Guid m_Guid;

		public static readonly BlueprintGuid Empty = new BlueprintGuid(Guid.Empty);

		public const int BinaryLength = 16;
	}
}
