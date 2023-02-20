using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using UnityEngine;
using System.Collections.Generic;

namespace SwimingSushi.Customs
{
    public class Sushi_Crab_Mayo_Cut : CustomItem
    {
        public override string UniqueNameID => "Sushi_Crab_Mayo_Cut";
        public override GameObject Prefab => Main.bundle.LoadAsset<GameObject>("Crab_Mayo_Cut");
        public override int SplitCount => 1;
        public override Item SplitSubItem => (Item)GDOUtils.GetCustomGameDataObject<Sushi_Crab_Mayo_Split>().GameDataObject;

        public override List<Item> SplitDepletedItems => new List<Item>
        {
            (Item)GDOUtils.GetCustomGameDataObject<Sushi_Crab_Mayo_Split>().GameDataObject
        };
		public override string ColourBlindTag => "CM";
    }
}
