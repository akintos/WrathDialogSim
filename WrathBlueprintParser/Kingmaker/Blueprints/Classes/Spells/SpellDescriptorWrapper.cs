using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kingmaker.Blueprints.Classes.Spells
{
    public class SpellDescriptorWrapper
    {
        public override string ToString()
        {
            return ((SpellDescriptor)m_IntValue).ToString();
        }

        public long m_IntValue;
    }
}
