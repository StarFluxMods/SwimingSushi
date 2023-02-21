using System.Collections.Generic;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.References;
using KitchenLib.Utils;
using SwimingSushi.Customs.Rice;
using UnityEngine;

namespace SwimingSushi.Customs
{
	public class Nigiri : CustomItemGroup
	{
		public override string UniqueNameID => "Nigiri";
		public override GameObject Prefab => Main.bundle.LoadAsset<GameObject>("Nigiri");
		public override ItemStorage ItemStorageFlags => ItemStorage.StackableFood;
		public override List<ItemGroup.ItemSet> Sets => new List<ItemGroup.ItemSet>()
		{
			new ItemGroup.ItemSet()
			{
				Max = 2,
				Min = 2,
				Items = new List<Item>()
				{
					(Item)GDOUtils.GetCustomGameDataObject<Rice_Cooked>().GameDataObject,
					(Item)GDOUtils.GetExistingGDO(ItemReferences.FishFillet),
				},
				IsMandatory = true
			}
		};
		public override bool AutoCollapsing => true;
	}
}
