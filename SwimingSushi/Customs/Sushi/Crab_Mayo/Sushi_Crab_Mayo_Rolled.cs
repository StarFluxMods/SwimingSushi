using KitchenData;
using KitchenLib.Customs;
using KitchenLib.References;
using KitchenLib.Utils;
using System.Collections.Generic;
using UnityEngine;

namespace SwimingSushi.Customs.Sushi.Crab_Mayo
{
    public class Sushi_Crab_Mayo_Rolled : CustomItem
    {
        public override string UniqueNameID => "Sushi_Crab_Mayo_Rolled";
        public override GameObject Prefab => Main.bundle.LoadAsset<GameObject>("Sushi Crab Mayo Rolled");
        public override List<Item.ItemProcess> Processes => new List<Item.ItemProcess>
        {
            new Item.ItemProcess{
                Duration = 2f,
                IsBad = false,
                Process = (Process)GDOUtils.GetExistingGDO(ProcessReferences.Chop),
                Result = (Item)GDOUtils.GetCustomGameDataObject<Sushi_Crab_Mayo_Cut>().GameDataObject
            }
        };
		public override string ColourBlindTag => "CM";

		public override void OnRegister(GameDataObject gameDataObject)
        {
            Item item = (Item)gameDataObject;
            MaterialUtils.ApplyMaterial(item.Prefab, "Model/Sushi_Rolled", new Material[] {
                MaterialUtils.GetExistingMaterial("Crab - Raw Shell"),
                MaterialUtils.GetCustomMaterial("Nori"),
                MaterialUtils.GetExistingMaterial("Rice")
            });
        }
    }
}
