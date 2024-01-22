using System;
using Kingmaker.Blueprints;

namespace Kingmaker.ElementsSystem;

	public class Dialog : BlueprintEvaluator
{
    public override string GetCaption()
    {
        return $"Dialog({m_Value.Name}";
    }

    public BlueprintDialogReference m_Value;
}
