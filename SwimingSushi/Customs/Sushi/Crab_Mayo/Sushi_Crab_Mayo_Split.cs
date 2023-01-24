using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using UnityEngine;

namespace SwimingSushi.Customs.Sushi.Crab_Mayo
{
    public class Sushi_Crab_Mayo_Split : CustomItem
    {
        public override string UniqueNameID => "Sushi_Crab_Mayo_Split";
        public override GameObject Prefab => Main.bundle.LoadAsset<GameObject>("Sushi_Crab_Mayo_Split");
		public override ItemStorage ItemStorageFlags => ItemStorage.StackableFood;
		public override string ColourBlindTag => "CM";

		public override void OnRegister(GameDataObject gameDataObject)
        {
            Item item = (Item)gameDataObject;
            MaterialUtils.ApplyMaterial(item.Prefab, "Sushi_Crab_Mayo_Split/Sushi_Split", new Material[] {
                MaterialUtils.GetExistingMaterial("Crab - Raw Shell"),
                MaterialUtils.GetCustomMaterial("Nori"),
                MaterialUtils.GetExistingMaterial("Rice")
            });
        }
    }
}
