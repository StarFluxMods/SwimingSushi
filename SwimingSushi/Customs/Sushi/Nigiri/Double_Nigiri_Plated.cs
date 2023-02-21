using KitchenLib.Customs;
using System.Collections.Generic;
using KitchenData;
using UnityEngine;
using KitchenLib.Utils;
using KitchenLib.References;

namespace SwimingSushi.Customs
{
	public class Double_Nigiri_Plated : CustomItemGroup
	{
		public override string UniqueNameID => "Double_Nigiri_Plated";
		public override GameObject Prefab => Main.bundle.LoadAsset<GameObject>("Double_Nigiri_Plated");
		public override bool AutoCollapsing => false;
		public override Item DirtiesTo => (Item)GDOUtils.GetExistingGDO(ItemReferences.PlateDirty);
		public override Item DisposesTo => (Item)GDOUtils.GetExistingGDO(ItemReferences.Plate);
		public override bool CanContainSide => true;
		public override List<ItemGroup.ItemSet> Sets => new List<ItemGroup.ItemSet>()
		{
			new ItemGroup.ItemSet()
			{
				Max = 1,
				Min = 1,
				Items = new List<Item>()
				{
					(Item)GDOUtils.GetExistingGDO(ItemReferences.Plate)
				},
				IsMandatory = true
			},
			new ItemGroup.ItemSet()
			{
				Max = 2,
				Min = 2,
				Items = new List<Item>()
				{
					(Item)GDOUtils.GetCustomGameDataObject<Nigiri>().GameDataObject,
					(Item)GDOUtils.GetCustomGameDataObject<Nigiri>().GameDataObject,
				},
				IsMandatory = false
			}
		};
		public override ItemValue ItemValue => ItemValue.Medium;
	}
}
