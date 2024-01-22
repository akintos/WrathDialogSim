using System;
using System.Collections.Generic;
using System.Linq;
using Kingmaker.Blueprints;
using Kingmaker.ElementsSystem;

namespace Kingmaker.Designers.EventConditionActionSystem.Conditions
{
    public class PlayerTopClassIs : Condition
    {
        protected override string GetConditionCaption()
        {
            if (!CheckGroup)
            {
                return string.Format("PlayerTopClassIs({0})", m_CharacterClass);
            }
            return string.Format("PlayerTopClassIs({0})", m_CharacterClassGroup);
        }

        public bool CheckGroup;

        public BlueprintReferenceBase m_CharacterClass;

        public BlueprintReferenceBase m_CharacterClassGroup;
    }
}
