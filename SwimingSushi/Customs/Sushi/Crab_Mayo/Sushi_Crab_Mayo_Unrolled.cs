﻿using KitchenData;
using KitchenLib.Customs;
using KitchenLib.References;
using KitchenLib.Utils;
using System.Collections.Generic;
using UnityEngine;

namespace SwimingSushi.Customs.Sushi.Crab_Mayo
{
	public class Sushi_Crab_Mayo_Unrolled : CustomItemGroup
	{
		public override string UniqueNameID => "Sushi_Crab_Mayo_Unrolled";
		public override GameObject Prefab => Main.bundle.LoadAsset<GameObject>("Sushi_Crab_Mayo_Unrolled");
		public override List<Item.ItemProcess> Processes => new List<Item.ItemProcess>
		{
			new Item.ItemProcess{
				Duration = 1f,
				IsBad = false,
				Process = (Process)GDOUtils.GetExistingGDO(ProcessReferences.Knead),
				Result = (Item)GDOUtils.GetCustomGameDataObject<Sushi_Crab_Mayo_Rolled>().GameDataObject
			}
		};
		public override bool AutoCollapsing => true;
		public override List<ItemGroup.ItemSet> Sets => new List<ItemGroup.ItemSet>()
		{
			new ItemGroup.ItemSet()
			{
				Max = 2,
				Min = 2,
				Items = new List<Item>()
				{
					(Item)GDOUtils.GetCustomGameDataObject<Sushi_Crab_Unrolled>().GameDataObject,
					(Item)GDOUtils.GetExistingGDO(ItemReferences.Mayonnaise)
				}
			}
		};

		public override void OnRegister(GameDataObject gameDataObject)
		{
			ItemGroup item = (ItemGroup)gameDataObject;
			MaterialUtils.ApplyMaterial(item.Prefab, "Sushi_Crab_Mayo_Unrolled/Nori", new Material[] { MaterialUtils.GetCustomMaterial("Nori") });
			MaterialUtils.ApplyMaterial(item.Prefab, "Sushi_Crab_Mayo_Unrolled/Rice", new Material[] { MaterialUtils.GetExistingMaterial("Rice") });
			MaterialUtils.ApplyMaterial(item.Prefab, "Sushi_Crab_Mayo_Unrolled/Crab", new Material[] { MaterialUtils.GetExistingMaterial("Crab - Raw Shell") });
			MaterialUtils.ApplyMaterial(item.Prefab, "Sushi_Crab_Mayo_Unrolled/Mayo", new Material[] { MaterialUtils.GetExistingMaterial("Mayonnaise") });
		}
	}
}