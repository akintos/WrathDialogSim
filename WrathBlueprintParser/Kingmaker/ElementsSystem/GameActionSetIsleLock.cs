using System;
using UnityEngine;

namespace Kingmaker.ElementsSystem
{
	public class GameActionSetIsleLock : GameAction
	{
		public override string GetCaption()
		{
			return $"IsleLock({m_Isle}, Lock: {m_IsLock})";
		}

		public IsleEvaluator m_Isle;

		public bool m_IsLock;
	}
}
