using System;
using System.Collections.Generic;
using UnityEngine;

namespace Kingmaker.Visual.Animation.Events
{
	public class AnimationClipEventTrack : ScriptableObject
	{
		public List<AnimationClipEvent> m_Events = new List<AnimationClipEvent>();
	}
}
