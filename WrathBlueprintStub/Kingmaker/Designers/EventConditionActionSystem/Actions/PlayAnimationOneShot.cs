using System;
using Kingmaker.ElementsSystem;
using Kingmaker.EntitySystem.Entities;
using Kingmaker.Visual.Animation;

namespace Kingmaker.Designers.EventConditionActionSystem.Actions
{
	public class PlayAnimationOneShot : GameAction
	{
		public override string GetCaption()
		{
			return $"PlayAnimationOneShot({Unit}, {m_ClipWrapper})";
		}

		public AnimationClipWrapper m_ClipWrapper;
		public UnitEvaluator Unit;

		public float TransitionIn = 0.25f;
		public float TransitionOut = 0.25f;
	}
}
