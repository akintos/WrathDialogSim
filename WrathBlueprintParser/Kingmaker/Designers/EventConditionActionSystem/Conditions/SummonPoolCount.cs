using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kingmaker.Designers.EventConditionActionSystem.Conditions;
public class SummonPoolCount : Condition
{
    private string GetOperationText()
    {
        return this.m_Operation switch
        {
            SummonPoolCount.Operation.Equal => "=",
            SummonPoolCount.Operation.MoreOrEqual => ">=",
            SummonPoolCount.Operation.LessOrEqual => "<=",
            _ => "",
        };
    }

    protected override string GetConditionCaption()
    {
        return $"SummonPoolCount({m_SummonPoll}, {GetOperationText()} {m_Count})";
    }

    public BlueprintReferenceBase m_SummonPoll;

    public Operation m_Operation;

    public int m_Count;

    public bool m_AliveOnly = true;

    public enum Operation
    {
        Equal,
        MoreOrEqual,
        LessOrEqual
    }
}