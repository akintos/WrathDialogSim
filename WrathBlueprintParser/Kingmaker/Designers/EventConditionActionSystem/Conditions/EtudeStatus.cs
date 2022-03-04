using System;
using Kingmaker.Blueprints;
using Kingmaker.ElementsSystem;

namespace Kingmaker.Designers.EventConditionActionSystem.Conditions
{
    public class EtudeStatus : Condition
    {
        protected override string GetConditionCaption()
        {
            return string.Format("EtudeStatus({0}{1}{2}{3}{4}{5})", new object[]
            {
                this.m_Etude,
                this.NotStarted ? ", NotStarted" : "",
                this.Started ? ", Started" : "",
                this.Playing ? ", Playing" : "",
                this.CompletionInProgress ? ", CompletionInProgress" : "",
                this.Completed ? ", Completed" : ""
            });
        }

        public BlueprintReferenceBase m_Etude;

        public bool NotStarted;
        public bool Started;
        public bool Playing;
        public bool CompletionInProgress;
        public bool Completed;

    }
}
