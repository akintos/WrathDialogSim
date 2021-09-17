using Kingmaker.Blueprints;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kingmaker.Designers
{
    public static class AbilitiesHelper
    {
        [Serializable]
        public class AbilityDescription
        {
            public override string ToString()
            {
                if (!AbilityFromList)
                {
                    return SpellDescriptor;
                }
                return string.Join(", ", from a in m_AllowedAbilities select a.ToString());
            }

            public bool AbilityFromList;

            public BlueprintReferenceBase[] m_AllowedAbilities;

            public string SpellDescriptor;
        }
    }
}
