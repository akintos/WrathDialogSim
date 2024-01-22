using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kingmaker.Designers.EventConditionActionSystem.Conditions;
public class ItemFromCollectionCondition : Condition
{
    protected override string GetConditionCaption()
    {
        return $"ItemFromCollection({Items}, {(Any ? "ANY" : "ALL")}, Condition: {Condition})";
    }

    public ItemsCollectionEvaluator Items;

    public bool Any;

    public ConditionsChecker Condition;
}