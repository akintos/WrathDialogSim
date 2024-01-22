namespace Kingmaker.Blueprints.Items;

public class BlueprintItem : SimpleBlueprint
{
	public LocalizedString m_DisplayNameText;

	public LocalizedString m_DescriptionText;

	public LocalizedString m_FlavorText;

	public LocalizedString m_NonIdentifiedNameText;

	public LocalizedString m_NonIdentifiedDescriptionText;

	public int m_Cost = 10;

	public float m_Weight;

	public bool m_IsNotable;

	public bool m_ForceStackable;

	public bool m_Destructible;

	public BlueprintItemReference m_ShardItem;

	public BlueprintItem.MiscellaneousItemType m_MiscellaneousType;

	public string m_InventoryPutSound;

	public string m_InventoryTakeSound;

	public bool NeedSkinningForCollect;

	public enum MiscellaneousItemType
	{
		None,
		Jewellery,
		Gems,
		AnimalParts
	}
}
