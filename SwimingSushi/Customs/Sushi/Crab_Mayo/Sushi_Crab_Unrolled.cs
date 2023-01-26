using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using System.Collections.Generic;
using UnityEngine;
using SwimingSushi.Customs.Sushi.Base;
using KitchenLib.References;
	
namespace SwimingSushi.Customs.Sushi.Crab_Mayo
{
    public class Sushi_Crab_Unrolled : CustomItemGroup
    {
        public override string UniqueNameID => "Sushi_Crab_Unrolled";
        public override GameObject Prefab => Main.bundle.LoadAsset<GameObject>("Sushi_Crab_Unrolled");
        public override List<ItemGroup.ItemSet> Sets => new List<ItemGroup.ItemSet>()
        {
            new ItemGroup.ItemSet()
            {
                Max = 2,
                Min = 2,
                Items = new List<Item>()
                {
                    (Item)GDOUtils.GetCustomGameDataObject<PlainSushi_Unrolled>().GameDataObject,
                    (Item)GDOUtils.GetExistingGDO(ItemReferences.CrabChopped)
                }
            }
        };
		public override string ColourBlindTag => "C";

		public override void OnRegister(GameDataObject gameDataObject)
        {
            Item item = (Item)gameDataObject;
            MaterialUtils.ApplyMaterial(item.Prefab, "Sushi_Crab_Unrolled/Nori", new Material[] { MaterialUtils.GetCustomMaterial("Nori") });
			MaterialUtils.ApplyMaterial(item.Prefab, "SushiUnrolled/Rice", new Material[] { MaterialUtils.GetCustomMaterial("NoriRice") });
			MaterialUtils.ApplyMaterial(item.Prefab, "Sushi_Crab_Unrolled/Crab", new Material[] { MaterialUtils.GetExistingMaterial("Crab - Raw Shell") });
        }
    }
}
