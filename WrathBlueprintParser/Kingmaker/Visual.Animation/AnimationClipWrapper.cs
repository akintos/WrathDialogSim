using Kingmaker.Visual.Animation.Events;
using System;
using System.Collections.Generic;

using UnityEngine;

namespace Kingmaker.Visual.Animation
{
	[Serializable]
	public class AnimationClipWrapper
	{
		public AnimationClip m_AnimationClip;

        public override string ToString()
        {
			return m_AnimationClip.name;
        }

        private enum RecognizedEventNames
		{
			PostEvent,
			PostEventMapped,
			PostMainWeaponWhooshEvent,
			PostOffWeaponWhooshEvent,
			PostMainWeaponEquipEvent,
			PostOffWeaponEquipEvent,
			PostMainWeaponUnequipEvent,
			PostOffWeaponUnequipEvent,
			PostArmorFoleyEvent,
			PostEventWithSurface,
			AnimateWeaponTrail,
			PostCommandActEvent,
			PostEventWithPrefix,
			PostDecoratorObject,
			PlayFootstep,
			PlayBodyfall,
			FxAnimatorToggleAction,
			HideTorchEvent,
			UnhideTorchEvent
		}
	}
}
