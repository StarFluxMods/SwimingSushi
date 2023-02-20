using System.Collections.Generic;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.References;
using KitchenLib.Utils;
using SwimingSushi.Customs.Sushi.Mega_Nigiri;
using UnityEngine;

namespace SwimingSushi.Customs
{
	public class Mega_Nigiri_Plated : CustomItemGroup
	{
		public override string UniqueNameID => "Mega_Nigiri_Plated";
		public override GameObject Prefab => Main.bundle.LoadAsset<GameObject>("Mega_Nigiri_Plated");
		public override List<ItemGroup.ItemSet> Sets => new List<ItemGroup.ItemSet>()
		{
			new ItemGroup.ItemSet()
			{
				Max = 2,
				Min = 2,
				Items = new List<Item>()
				{
					(Item)GDOUtils.GetCustomGameDataObject<Mega_Nigiri>().GameDataObject,
					(Item)GDOUtils.GetExistingGDO(ItemReferences.Plate),
				},
				IsMandatory = true
			}
		};
		public override bool AutoCollapsing => true;
	}
}
