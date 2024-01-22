using Kingmaker.UnitLogic.Alignments;

namespace Kingmaker.DialogSystem.Blueprints;

public class BlueprintCue : BlueprintCueBase
{
    public LocalizedString Text;

    public DialogExperience Experience;
    public DialogAnimation Animation;

    public DialogSpeaker Speaker;
    public bool TurnSpeaker = true;

    public BlueprintUnitReference m_Listener;

    public ActionList OnShow;
    public ActionList OnStop;

    public AlignmentShift AlignmentShift = new AlignmentShift();

    public List<BlueprintAnswerBaseReference> Answers = new List<BlueprintAnswerBaseReference>();

    public CueSelection Continue;

    public List<BlueprintAnswerReference> GetAnswers()
    {
        var result = new List<BlueprintAnswerReference>();

        foreach (var item in Answers)
        {
            var bp = item.Get();
            if (bp is BlueprintAnswersList bal)
            {
                result.AddRange(bal.Answers.Select(x => new BlueprintAnswerReference() { Guid = x.Guid }));
            }
            else if (bp is BlueprintAnswer ba)
            {
                result.Add(new BlueprintAnswerReference() { Guid = item.Guid });
            }
        }

        return result;
    }
}
