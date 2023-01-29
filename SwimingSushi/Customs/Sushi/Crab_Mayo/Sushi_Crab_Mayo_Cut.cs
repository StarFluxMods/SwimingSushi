using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using UnityEngine;
using System.Collections.Generic;

namespace SwimingSushi.Customs.Sushi.Crab_Mayo
{
    public class Sushi_Crab_Mayo_Cut : CustomItem
    {
        public override string UniqueNameID => "Sushi_Crab_Mayo_Cut";
        public override GameObject Prefab => Main.bundle.LoadAsset<GameObject>("Sushi Crab Mayo Cut");
        public override int SplitCount => 1;
        public override Item SplitSubItem => (Item)GDOUtils.GetCustomGameDataObject<Sushi_Crab_Mayo_Split>().GameDataObject;

        public override List<Item> SplitDepletedItems => new List<Item>
        {
            (Item)GDOUtils.GetCustomGameDataObject<Sushi_Crab_Mayo_Split>().GameDataObject
        };
		public override string ColourBlindTag => "CM";

		public override void OnRegister(GameDataObject gameDataObject)
        {
            Item item = (Item)gameDataObject;
			MaterialUtils.ApplyMaterial(item.Prefab, "Model/Sushi_Cut", new Material[] {
				MaterialUtils.GetExistingMaterial("Crab - Raw Shell"),
				MaterialUtils.GetCustomMaterial("Nori"),
				MaterialUtils.GetExistingMaterial("Rice")
			});
		}
    }
}
