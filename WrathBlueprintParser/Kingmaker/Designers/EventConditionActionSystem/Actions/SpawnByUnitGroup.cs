

namespace Kingmaker.Designers.EventConditionActionSystem.Actions
{
	public class SpawnByUnitGroup : GameAction
	{
		public override string GetCaption()
		{
			return $"SpawnByUnitGroup({Group}, ActionsOnSpawn: {ActionsOnSpawn.LambdaFormat()})";
		}

		public EntityReference Group;

		public ActionList ActionsOnSpawn;
	}
}
