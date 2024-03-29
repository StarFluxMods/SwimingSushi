﻿using System.Collections.Generic;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.References;
using KitchenLib.Utils;
using UnityEngine;

namespace SwimingSushi.Customs
{
    public class Mega_Rice_Tier1 : CustomItemGroup
    {
        public override string UniqueNameID => "Mega_Rice_Tier1";
        public override GameObject Prefab => Main.bundle.LoadAsset<GameObject>("Mega_Rice_Tier1");
        public override List<ItemGroup.ItemSet> Sets => new List<ItemGroup.ItemSet>()
        {
            new ItemGroup.ItemSet()
            {
                Max = 2,
                Min = 2,
                Items = new List<Item>()
                {
					(Item)GDOUtils.GetExistingGDO(ItemReferences.Rice),
					(Item)GDOUtils.GetExistingGDO(ItemReferences.Rice),
				},
                IsMandatory = true
            }
        };
        public override bool AutoCollapsing => true;
    }
}
