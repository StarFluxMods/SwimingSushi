using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using UnityEngine;

namespace SwimingSushi.Customs
{
    public class Sushi_Avocado_Fish_Split : CustomItem
    {
        public override string UniqueNameID => "Sushi_Avocado_Fish_Split";
        public override GameObject Prefab => Main.bundle.LoadAsset<GameObject>("Fish_Avocado_Split");
		public override ItemStorage ItemStorageFlags => ItemStorage.StackableFood;
		public override string ColourBlindTag => "AF";
    }
}
