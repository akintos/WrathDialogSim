

namespace Kingmaker.Designers.EventConditionActionSystem.Actions
{
	public class SummonPoolUnits : GameAction
	{
		public override string GetCaption()
		{
			return $"SummonPoolUnits({m_SummonPool}, Conditions: {Conditions}, Actions: {Actions.LambdaFormat()})";
		}

		public BlueprintReferenceBase m_SummonPool;

		public ConditionsChecker Conditions;

		public ActionList Actions;
	}
}
