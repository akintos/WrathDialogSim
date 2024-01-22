using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kingmaker.Designers.EventConditionActionSystem.Conditions;
public class IsCampaign : Condition
{
    protected override string GetConditionCaption()
    {
        return $"IsCampaign({m_BlueprintCampaign})";
    }

    public BlueprintReferenceBase m_BlueprintCampaign;
}