using System.Collections.Generic;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.References;
using KitchenLib.Utils;
using UnityEngine;

namespace SwimingSushi.Customs
{
	public class Nigiri : CustomItemGroup
	{
		public override string UniqueNameID => "Nigiri";
		public override GameObject Prefab => Main.bundle.LoadAsset<GameObject>("Nigiri");
		public override List<ItemGroup.ItemSet> Sets => new List<ItemGroup.ItemSet>()
		{
			new ItemGroup.ItemSet()
			{
				Max = 2,
				Min = 2,
				Items = new List<Item>()
				{
					(Item)GDOUtils.GetExistingGDO(ItemReferences.RiceContainerCooked),
					(Item)GDOUtils.GetExistingGDO(ItemReferences.FishFillet),
				},
				IsMandatory = true
			}
		};
		public override bool AutoCollapsing => true;
	}
}
