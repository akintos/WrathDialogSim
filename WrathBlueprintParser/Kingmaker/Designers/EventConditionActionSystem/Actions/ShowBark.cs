using System;
using Kingmaker.Blueprints;

using Kingmaker.ElementsSystem;
using Kingmaker.EntitySystem;
using Kingmaker.Localization;
using UnityEngine;

namespace Kingmaker.Designers.EventConditionActionSystem.Actions
{
	public class ShowBark : GameAction
	{
		public override string GetCaption()
		{
			Element arg;
			if (TargetUnit is null)
				arg = TargetMapObject;
			else
				arg = TargetUnit;
			return $"ShowBark({arg}, {WhatToBark.Key})";
		}

		public LocalizedString WhatToBark;

		public UnitEvaluator TargetUnit;
		public MapObjectEvaluator TargetMapObject;
	}
}
