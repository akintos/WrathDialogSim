using System;
using Kingmaker.ElementsSystem;

namespace Kingmaker.Designers.EventConditionActionSystem.Conditions
{
    public class CurrentChapter : Condition
    {
        protected override string GetConditionCaption()
        {
            return $"CurrentChapterIs({Chapter})";
        }

        public int Chapter;
    }
}
