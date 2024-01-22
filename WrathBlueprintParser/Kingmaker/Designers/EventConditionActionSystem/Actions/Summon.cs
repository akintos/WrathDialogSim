using System;
using System.Linq;
using Kingmaker.Blueprints;
using Kingmaker.ElementsSystem;
using Kingmaker.EntitySystem;
using Kingmaker.EntitySystem.Entities;
using UnityEngine;

namespace Kingmaker.Designers.EventConditionActionSystem.Actions
{
	public class Summon : GameAction
	{
		public override string GetCaption()
		{
			return $"Summon({m_Unit}, {m_SummonPool}, OnSummon: {OnSummmon.LambdaFormat()})";
		}

		public BlueprintUnitReference m_Unit;

		public BlueprintReferenceBase m_SummonPool;

		public bool GroupBySummonPool;

		public ActionList OnSummmon;
	}
}
