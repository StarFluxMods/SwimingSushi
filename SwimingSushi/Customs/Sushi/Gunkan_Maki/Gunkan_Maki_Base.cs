using Kitchen;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.References;
using KitchenLib.Utils;
using System.Collections.Generic;
using UnityEngine;

namespace SwimingSushi.Customs
{
	public class Gunkan_Maki_Base : CustomItemGroup
	{
		public override string UniqueNameID => "Gunkan_Maki_Base";
		public override GameObject Prefab => Main.bundle.LoadAsset<GameObject>("Gunkan_Maki_Base");
		public override List<ItemGroup.ItemSet> Sets => new List<ItemGroup.ItemSet>()
		{
			new ItemGroup.ItemSet()
			{
				Max = 2,
				Min = 2,
				Items = new List<Item>()
				{
					(Item)GDOUtils.GetCustomGameDataObject<Rice_Cooked>().GameDataObject,
					(Item)GDOUtils.GetExistingGDO(ItemReferences.SeaweedCooked),
				},
				IsMandatory = true
			}
		};
	}
}
