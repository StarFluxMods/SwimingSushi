using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using System.Collections.Generic;
using UnityEngine;
using SwimingSushi.Customs.Sushi.Base;
using KitchenLib.References;
	
namespace SwimingSushi.Customs.Sushi.Crab_Mayo
{
    public class Sushi_Mayo_Unrolled : CustomItemGroup
    {
        public override string UniqueNameID => "Sushi_Mayo_Unrolled";
        public override GameObject Prefab => Main.bundle.LoadAsset<GameObject>("Sushi Mayo Unrolled");
        public override List<ItemGroup.ItemSet> Sets => new List<ItemGroup.ItemSet>()
        {
            new ItemGroup.ItemSet()
            {
                Max = 2,
                Min = 2,
                Items = new List<Item>()
                {
                    (Item)GDOUtils.GetCustomGameDataObject<PlainSushi_Unrolled>().GameDataObject,
                    (Item)GDOUtils.GetExistingGDO(ItemReferences.Mayonnaise)
                }
            }
        };
		public override string ColourBlindTag => "M";

		public override void OnRegister(GameDataObject gameDataObject)
        {
            Item item = (Item)gameDataObject;
            MaterialUtils.ApplyMaterial(item.Prefab, "Model/Nori", new Material[] { MaterialUtils.GetCustomMaterial("Nori") });
			MaterialUtils.ApplyMaterial(item.Prefab, "Model/Rice", new Material[] { MaterialUtils.GetCustomMaterial("NoriRice") });
			MaterialUtils.ApplyMaterial(item.Prefab, "Model/Mayo", new Material[] { MaterialUtils.GetExistingMaterial("Mayonnaise") });
        }
    }
}
