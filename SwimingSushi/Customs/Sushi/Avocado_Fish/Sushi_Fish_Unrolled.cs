using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using System.Collections.Generic;
using UnityEngine;
using SwimingSushi.Customs.Sushi.Base;
using Kitchen;
using KitchenLib.References;

namespace SwimingSushi.Customs.Sushi.Avocado_Fish
{
    public class Sushi_Fish_Unrolled : CustomItemGroup
    {
        public override string UniqueNameID => "Sushi_Fish_Unrolled";
        public override GameObject Prefab => Main.bundle.LoadAsset<GameObject>("Sushi Fish Unrolled");
        public override List<ItemGroup.ItemSet> Sets => new List<ItemGroup.ItemSet>()
        {
            new ItemGroup.ItemSet()
            {
                Max = 2,
                Min = 2,
                Items = new List<Item>()
                {
                    (Item)GDOUtils.GetCustomGameDataObject<PlainSushi_Unrolled>().GameDataObject,
                    (Item)GDOUtils.GetExistingGDO(ItemReferences.FishFillet)
                }
            }
        };
		public override string ColourBlindTag => "F";

		public override void OnRegister(GameDataObject gameDataObject)
        {
            Item item = (Item)gameDataObject;
            MaterialUtils.ApplyMaterial(item.Prefab, "Model/Nori", new Material[] { MaterialUtils.GetCustomMaterial("Nori") });
			MaterialUtils.ApplyMaterial(item.Prefab, "Model/Rice", new Material[] { MaterialUtils.GetCustomMaterial("NoriRice") });
			MaterialUtils.ApplyMaterial(item.Prefab, "Model/Fillet", new Material[] { MaterialUtils.GetExistingMaterial("Raw Fish Spiny") });
        }
    }
}
