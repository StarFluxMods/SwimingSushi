using KitchenLib.Customs;
using System.Collections.Generic;
using KitchenData;
using UnityEngine;
using KitchenLib.Utils;
using KitchenLib.References;

namespace SwimingSushi.Customs
{
	public class Onigiri_Plated : CustomItemGroup
	{
		public override string UniqueNameID => "Onigiri_Plated";
		public override GameObject Prefab => Main.bundle.LoadAsset<GameObject>("Onigiri_Plated");
		public override bool AutoCollapsing => false;
		public override Item DirtiesTo => (Item)GDOUtils.GetExistingGDO(ItemReferences.PlateDirty);
		public override Item DisposesTo => (Item)GDOUtils.GetExistingGDO(ItemReferences.Plate);
		public override bool CanContainSide => true;
		public override List<ItemGroup.ItemSet> Sets => new List<ItemGroup.ItemSet>()
		{
			new ItemGroup.ItemSet()
			{
				Max = 2,
				Min = 2,
				Items = new List<Item>()
				{
					(Item)GDOUtils.GetCustomGameDataObject<Onigiri>().GameDataObject,
					(Item)GDOUtils.GetExistingGDO(ItemReferences.Plate)
				},
				OrderingOnly = false,
				IsMandatory = true,
				RequiresUnlock = false
			}
		};
		public override ItemValue ItemValue => ItemValue.Small;
	}
}
