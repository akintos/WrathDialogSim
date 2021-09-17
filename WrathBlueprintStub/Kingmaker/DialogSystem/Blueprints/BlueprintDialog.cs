using System;
using System.Collections.Generic;
using Kingmaker.Blueprints;
using Kingmaker.ElementsSystem;

namespace Kingmaker.DialogSystem.Blueprints
{
    public sealed class BlueprintDialog : SimpleBlueprint
    {
        public CueSelection FirstCue;

        // public PositionEvaluator StartPosition;

        public ConditionsChecker Conditions = new ConditionsChecker();

        public ActionList StartActions = new ActionList();

        public ActionList FinishActions = new ActionList();

        public ActionList ReplaceActions = new ActionList();

        public bool TurnPlayer = true;

        public bool TurnFirstSpeaker = true;

        public bool IsLockCameraRotationButtons;

        public DialogType Type;

        public IntEvaluator m_OverrideAreaCR;
    }

    public enum DialogType
    {
        Common,
        Book,
        Interchapter,
        Epilogue
    }
}
