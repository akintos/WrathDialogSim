using Kingmaker.DialogSystem.Blueprints;

namespace WrathBlueprintParser;

internal class DialogTreeSearch
{
    private readonly HashSet<BlueprintReferenceBase> Visited = new();

    private readonly Queue<BlueprintReferenceBase> ToVisit = new();

    private List<BlueprintReferenceBase> leafNodes;

    public DialogTreeSearch()
    {

    }

    private void Enqueue(BlueprintReferenceBase bpref)
    {
        if (!Visited.Contains(bpref))
            ToVisit.Enqueue(bpref);
    }

    private void Enqueue(IEnumerable<BlueprintReferenceBase> references)
    {
        foreach (var bpref in references)
        {
            Enqueue(bpref);
        }
    }
    
    public List<BlueprintReferenceBase> GetLeafNodes(BlueprintReferenceBase startNode)
    {
        leafNodes = new List<BlueprintReferenceBase>();

        ToVisit.Enqueue(startNode);

        while (ToVisit.Count > 0)
        {
            var bpRef = ToVisit.Dequeue();
            if (Visited.Contains(bpRef))
                continue;

            var bp = KingmakerResourceManager.Instance.GetBlueprint(bpRef);
            Visited.Add(bpRef);

            if (bp is BlueprintAnswer answer)
            {
                VisitNode(answer);
            }
            else if (bp is BlueprintAnswersList answersList)
            {
                VisitNode(answersList);
            }
            else if (bp is BlueprintBookPage bookPage)
            {
                VisitNode(bookPage);
            }
            else if (bp is BlueprintCheck check)
            {
                VisitNode(check);
            }
            else if (bp is BlueprintCue cue)
            {
                VisitNode(cue);
            }
            else if (bp is BlueprintCueSequence cueSequence)
            {
                VisitNode(cueSequence);
            }
            else if (bp is BlueprintDialog dialog)
            {
                VisitNode(dialog);
            }
            else if (bp is BlueprintSequenceExit sequenceExit)
            {
                VisitNode(sequenceExit);
            }
        }

        return leafNodes;
    }

    private void VisitNode(BlueprintAnswer answer)
    {

        if (answer.NextCue.Cues.Count == 0)
        {
            leafNodes.Add(answer);
        }
        else
        {
            Enqueue(answer.NextCue.Cues);
        }
    }

    private void VisitNode(BlueprintAnswersList answersList)
    {
        if (answersList.Answers.Count == 0)
        {
            leafNodes.Add(answersList);
        }
        else
        {
            Enqueue(answersList.Answers);
        }
    }

    private void VisitNode(BlueprintBookPage bookPage)
    {
        Enqueue(bookPage.Answers);

        if (bookPage.Answers.Count == 0)
        {
            leafNodes.Add(bookPage);
        }
    }

    private void VisitNode(BlueprintCheck check)
    {
        Enqueue(check.m_Success);
        Enqueue(check.m_Fail);
    }

    private void VisitNode(BlueprintCue cue)
    {
        Enqueue(cue.Continue.Cues);
        Enqueue(cue.Answers);

        if (cue.Continue.Cues.Count == 0 && cue.Answers.Count == 0)
        {
            leafNodes.Add(cue);
        }
    }

    private void VisitNode(BlueprintCueSequence cueSequence)
    {
        Enqueue(cueSequence.m_Exit);
    }

    private void VisitNode(BlueprintDialog dialog)
    {
        Enqueue(dialog.FirstCue.Cues);

        if (dialog.FirstCue.Cues.Count == 0)
        {
            leafNodes.Add(dialog);
        }
    }

    private void VisitNode(BlueprintSequenceExit sequenceExit)
    {
        Enqueue(sequenceExit.Continue.Cues);
        Enqueue(sequenceExit.Answers);

        if (sequenceExit.Continue.Cues.Count == 0 && sequenceExit.Answers.Count == 0)
        {
            leafNodes.Add(sequenceExit);
        }
    }
}
