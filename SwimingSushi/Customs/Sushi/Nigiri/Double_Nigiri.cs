using System.Collections.Generic;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.References;
using KitchenLib.Utils;
using UnityEngine;

namespace SwimingSushi.Customs
{
	public class Double_Nigiri : CustomItemGroup
	{
		public override string UniqueNameID => "Double_Nigiri";
		public override GameObject Prefab => Main.bundle.LoadAsset<GameObject>("Double_Nigiri");
		public override List<ItemGroup.ItemSet> Sets => new List<ItemGroup.ItemSet>()
		{
			new ItemGroup.ItemSet()
			{
				Max = 2,
				Min = 2,
				Items = new List<Item>()
				{
					(Item)GDOUtils.GetCustomGameDataObject<Nigiri>().GameDataObject,
					(Item)GDOUtils.GetCustomGameDataObject<Nigiri>().GameDataObject
				},
				IsMandatory = true
			}
		};
		public override bool AutoCollapsing => true;
	}
}
