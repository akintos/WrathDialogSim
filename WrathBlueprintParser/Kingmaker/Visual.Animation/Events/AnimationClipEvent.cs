using System;
using UnityEngine;

namespace Kingmaker.Visual.Animation.Events
{
	[Serializable]
	public class AnimationClipEvent
	{
		public override string ToString()
		{
			string type = "Normal";
			if (m_IsLooped)
				type = "Looped";
			if (m_IsIstant)
				type = "Instant";
			return string.Format("AnimationClipEvent({0}, {1})", type, this.m_Time);
		}

		public float m_Time;
		public bool m_IsLooped;
		public bool m_IsIstant;
	}
}
