

namespace Kingmaker.Designers.EventConditionActionSystem.Actions
{
	public class Unrecruit : GameAction
	{
		public override string GetCaption()
		{
			return $"Unrecruit({m_CompanionBlueprint}, OnUnrecruit: {OnUnrecruit.LambdaFormat()})";
		}

		public BlueprintUnitReference m_CompanionBlueprint;

		public ActionList OnUnrecruit;
	}
}
