using Kingmaker.EntitySystem.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kingmaker.Designers.EventConditionActionSystem.Evaluators;
public class ConditionalMapObjectEvaluator : MapObjectEvaluator
{
    public override string GetCaption()
    {
        return $"ConditionalMapObjectEvaluator({m_MapObjects.ToCommaSeparatedString()}, Default={m_Default ?? "none"})";
    }

    public ConditionalPair[] m_MapObjects;

    public MapObjectEvaluator m_Default;

    [Serializable]
    public class ConditionalPair
    {
        public ConditionsChecker Condition;
        
        public MapObjectEvaluator MapObject;

        public override string ToString()
        {
            return $"({Condition}, {MapObject})";
        }
    }
}
