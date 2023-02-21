using KitchenLib.Customs;
using System.Collections.Generic;
using KitchenData;
using UnityEngine;
using KitchenLib.Utils;
using KitchenLib.References;
using System.Reflection;

namespace SwimingSushi.Customs
{
	public class Sushi_Avocado_Fish_Plated : CustomItemGroup
	{
		public override string UniqueNameID => "Sushi_Avocado_Fish_Plated";
		public override GameObject Prefab => Main.bundle.LoadAsset<GameObject>("Fish_Avocado_Plated");
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
					(Item)GDOUtils.GetCustomGameDataObject<Sushi_Avocado_Fish_Split>().GameDataObject,
					(Item)GDOUtils.GetExistingGDO(ItemReferences.Plate)
				},
				OrderingOnly = false,
				IsMandatory = true,
				RequiresUnlock = false
			}
		};
		public override ItemValue ItemValue => ItemValue.Large;
		public override string ColourBlindTag => "AF";
	}
}
