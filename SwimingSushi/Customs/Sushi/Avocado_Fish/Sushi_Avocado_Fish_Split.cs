using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using UnityEngine;

namespace SwimingSushi.Customs.Sushi.Avocado_Fish
{
    public class Sushi_Avocado_Fish_Split : CustomItem
    {
        public override string UniqueNameID => "Sushi_Avocado_Fish_Split";
        public override GameObject Prefab => Main.bundle.LoadAsset<GameObject>("Sushi Avocado Fish Split");
		public override ItemStorage ItemStorageFlags => ItemStorage.StackableFood;
		public override string ColourBlindTag => "AF";

		public override void OnRegister(GameDataObject gameDataObject)
        {
            Item item = (Item)gameDataObject;
            MaterialUtils.ApplyMaterial(item.Prefab, "Model/Sushi_Split", new Material[] {
                MaterialUtils.GetExistingMaterial("Raw Fish Spiny"),
                MaterialUtils.GetCustomMaterial("Nori"),
                MaterialUtils.GetExistingMaterial("Rice"),
                MaterialUtils.GetExistingMaterial("Lettuce")
            });
        }
    }
}
