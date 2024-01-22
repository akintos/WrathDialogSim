using System;
using System.Text;
using Kingmaker.Blueprints;
using Kingmaker.ElementsSystem;
using Kingmaker.EntitySystem.Stats;

namespace Kingmaker.DialogSystem.Blueprints
{
    public class BlueprintCheck : BlueprintCueBase
    {
        public StatType Type;

        public int DC;

        public bool Hidden;

        public DCModifier[] DCModifiers = new DCModifier[0];

        public BlueprintCueBaseReference m_Success;

        public BlueprintCueBaseReference m_Fail;

        public UnitEvaluator m_UnitEvaluator;

        public DialogExperience Experience = DialogExperience.NormalExperience;

        public string GetDCModifierText()
        {
            if (DCModifiers.Length == 0)
                return "";

            var sb = new StringBuilder();
            sb.Append("DC Modifiers = \n");
            foreach (var mod in DCModifiers)
            {
                sb.Append($"    {mod.Conditions} : {mod.Mod:+0;-#}\n");
            }
            return sb.ToString();
        }
    }
}
