using KitchenData;
using KitchenLib.Customs;
using KitchenLib.References;
using KitchenLib.Utils;
using System.Collections.Generic;
using UnityEngine;

namespace SwimingSushi.Customs.Sushi.Base
{
    public class PlainSushi_Unrolled : CustomItemGroup
    {
        public override string UniqueNameID => "PlainSushi_Unrolled";
        public override GameObject Prefab => Main.bundle.LoadAsset<GameObject>("PlainSushi_Unrolled");
        public override List<ItemGroup.ItemSet> Sets => new List<ItemGroup.ItemSet>()
        {
            new ItemGroup.ItemSet()
            {
                Max = 2,
                Min = 2,
                Items = new List<Item>()
                {
                    (Item)GDOUtils.GetCustomGameDataObject<NoriSheet>().GameDataObject,
                    (Item)GDOUtils.GetExistingGDO(ItemReferences.RiceContainerCooked)
                }
            }
        };
        public override void OnRegister(GameDataObject gameDataObject)
        {
            Item item = (Item)gameDataObject;
            MaterialUtils.ApplyMaterial(item.Prefab, "SushiUnrolled/Nori", new Material[] { MaterialUtils.GetCustomMaterial("Nori") });
            MaterialUtils.ApplyMaterial(item.Prefab, "SushiUnrolled/Rice", new Material[] { MaterialUtils.GetCustomMaterial("NoriRice") });
        }
    }
}
