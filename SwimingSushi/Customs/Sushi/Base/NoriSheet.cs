using KitchenData;
using KitchenLib.Customs;
using KitchenLib.References;
using KitchenLib.Utils;
using System.Collections.Generic;
using UnityEngine;

namespace SwimingSushi.Customs
{
    public class NoriSheet : CustomItemGroup
    {
        public override string UniqueNameID => "norisheet";
        public override GameObject Prefab => Main.bundle.LoadAsset<GameObject>("Nori_Sheet");
        public override bool AutoCollapsing => true;
        public override List<ItemGroup.ItemSet> Sets => new List<ItemGroup.ItemSet>()
        {
            new ItemGroup.ItemSet()
            {
                Max = 2,
                Min = 2,
                Items = new List<Item>()
                {
                    (Item)GDOUtils.GetExistingGDO(ItemReferences.SeaweedCooked),
                    (Item)GDOUtils.GetExistingGDO(ItemReferences.SeaweedCooked)
                }
            },
        };
    }
}
