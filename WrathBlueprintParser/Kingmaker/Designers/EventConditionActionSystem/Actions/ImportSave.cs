namespace Kingmaker.Designers.EventConditionActionSystem.Actions;

public class ImportSave : GameAction
{
    public override string GetCaption()
    {
        return $"ImportSave({m_Campaign})";
    }

    //public override void RunAction()
    //{
    //    SaveImportSettings importSettings = Game.Instance.Player.Campaign.GetImportSettings(this.Campaign, false);
    //    if (importSettings == null)
    //    {
    //        PFLog.Default.Error(string.Format("There are no import settings to import {0} campaign into the ongoing {1} one.", this.Campaign, Game.Instance.Player.Campaign), Array.Empty<object>());
    //    }
    //    if (Game.Instance.Player.ImportedCampaigns.Contains(this.Campaign))
    //    {
    //        return;
    //    }
    //    Game.Instance.Player.CampaignsToOfferImport[this.Campaign] = new Player.CampaignImportSettings
    //    {
    //        AutoImportIfOnlyOneSave = this.m_AutoImportIfOnlyOneSave,
    //        LetPlayerChooseSave = this.m_LetPlayerChooseSave
    //    };
    //    if (!importSettings.Condition.Check())
    //    {
    //        return;
    //    }
    //    List<SaveInfo> saves = DlcSaveImporter.GetSavesForImport(this.Campaign);
    //    if (saves != null && saves.Count > 0)
    //    {
    //        if (this.m_LetPlayerChooseSave && (!this.m_AutoImportIfOnlyOneSave || saves.Count > 1))
    //        {
    //            EventBus.RaiseEvent<ICampaignImportHandler>(delegate (ICampaignImportHandler h)
    //            {
    //                h.HandleSaveImport(this.Campaign, saves);
    //            }, true);
    //            return;
    //        }
    //        importSettings.DoImport(saves[saves.Count - 1]);
    //    }
    //}

    public BlueprintReferenceBase m_Campaign;

    /// <summary>
    /// Display a prompt asking to choose a save from a list, if any.Otherwise the save will be chosen automatically and silently imported.
    /// </summary>
    public bool m_LetPlayerChooseSave;

    /// <summary>
    /// Import automatically if only one appropriate save file is presented.
    /// </summary>
    public bool m_AutoImportIfOnlyOneSave;
}