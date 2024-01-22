using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kingmaker.Designers.EventConditionActionSystem.NamedParameters;

[Serializable]
public class NamedParameterUnit : UnitEvaluator
{
    //protected override UnitEntityData GetValueInternal()
    //{
    //    NamedParametersContext.ContextData contextData = ContextData<NamedParametersContext.ContextData>.Current;
    //    if (contextData == null)
    //    {
    //        return null;
    //    }
    //    object obj;
    //    if (!contextData.Context.Params.TryGetValue(this.Parameter, out obj) && BuildModeUtility.IsDevelopment)
    //    {
    //        LogChannel @default = PFLog.Default;
    //        string text = "Cannot find unit ";
    //        string parameter = this.Parameter;
    //        string text2 = " in context parameters. Cutscene: ";
    //        CutscenePlayerData cutscene = contextData.Context.Cutscene;
    //        @default.ErrorWithReport(text + parameter + text2 + (((cutscene != null) ? cutscene.Cutscene.ToString() : null) ?? "none"), new object[] { this });
    //    }
    //    string text3 = obj as string;
    //    if (text3 != null)
    //    {
    //        UnitReference unitReference = new UnitReference(text3);
    //        contextData.Context.Params[this.Parameter] = unitReference;
    //        return unitReference;
    //    }
    //    UnitReference? unitReference2 = obj as UnitReference?;
    //    if (unitReference2 == null)
    //    {
    //        return null;
    //    }
    //    return unitReference2.GetValueOrDefault();
    //}

    public override string GetCaption()
    {
        return "P:" + this.Parameter;
    }

    public string Parameter;
}