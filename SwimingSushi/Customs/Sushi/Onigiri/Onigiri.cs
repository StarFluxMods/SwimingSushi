using KitchenData;
using KitchenLib.Customs;
using KitchenLib.References;
using KitchenLib.Utils;
using System.Collections.Generic;
using UnityEngine;

namespace SwimingSushi.Customs
{
	public class Onigiri : CustomItemGroup
	{
		public override string UniqueNameID => "Onigiri";
		public override GameObject Prefab => Main.bundle.LoadAsset<GameObject>("Onigiri");
		public override ItemStorage ItemStorageFlags => ItemStorage.StackableFood;
		public override List<ItemGroup.ItemSet> Sets => new List<ItemGroup.ItemSet>()
		{
			new ItemGroup.ItemSet()
			{
				Max = 2,
				Min = 2,
				Items = new List<Item>()
				{
					(Item)GDOUtils.GetCustomGameDataObject<Rice_Ball>().GameDataObject,
					(Item)GDOUtils.GetExistingGDO(ItemReferences.SeaweedCooked),
				},
				IsMandatory = true
			}
		};
		public override bool AutoCollapsing => false;
	}
}
