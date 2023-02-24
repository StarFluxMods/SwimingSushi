using KitchenData;
using KitchenLib.Customs;
using KitchenLib.References;
using KitchenLib.Utils;
using System.Collections.Generic;
using UnityEngine;

namespace SwimingSushi.Customs
{
    public class PlainSushi_Unrolled : CustomItemGroup
    {
        public override string UniqueNameID => "PlainSushi_Unrolled";
        public override GameObject Prefab => Main.bundle.LoadAsset<GameObject>("Plain_Sushi_Unrolled");
        public override List<ItemGroup.ItemSet> Sets => new List<ItemGroup.ItemSet>()
        {
            new ItemGroup.ItemSet()
            {
                Max = 2,
                Min = 2,
                Items = new List<Item>()
                {
                    (Item)GDOUtils.GetCustomGameDataObject<NoriSheet>().GameDataObject,
					(Item)GDOUtils.GetCustomGameDataObject<Rice_Cooked>().GameDataObject
				},
				IsMandatory = true
            }
        };
    }
}
