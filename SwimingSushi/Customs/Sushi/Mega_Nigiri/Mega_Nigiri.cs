﻿using System.Collections.Generic;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.References;
using KitchenLib.Utils;
using UnityEngine;

namespace SwimingSushi.Customs
{
	public class Mega_Nigiri : CustomItemGroup
	{
		public override string UniqueNameID => "Mega_Nigiri";
		public override GameObject Prefab => Main.bundle.LoadAsset<GameObject>("Mega_Nigiri");
		public override List<ItemGroup.ItemSet> Sets => new List<ItemGroup.ItemSet>()
		{
			new ItemGroup.ItemSet()
			{
				Max = 2,
				Min = 2,
				Items = new List<Item>()
				{
					(Item)GDOUtils.GetCustomGameDataObject<Cooked_Mega_Rice>().GameDataObject,
					(Item)GDOUtils.GetCustomGameDataObject<Salmon_Sliced>().GameDataObject,
				},
				IsMandatory = true
			}
		};
		public override bool AutoCollapsing => true;
	}
}
