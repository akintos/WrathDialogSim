using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kingmaker.Designers.EventConditionActionSystem.Conditions;

public class IsCampaignImported : Condition
{
    protected override string GetConditionCaption()
    {
        return $"IsCampaignImported({m_BlueprintCampaign})";
    }

    //protected override bool CheckCondition()
    //{
    //    return Game.Instance.Player.ImportedCampaigns.Contains(this.BlueprintCampaign);
    //}

    public BlueprintReferenceBase m_BlueprintCampaign;
}