using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using UnityEngine;

namespace SwimingSushi.Customs
{
    public class Sushi_Crab_Mayo_Split : CustomItem
    {
        public override string UniqueNameID => "Sushi_Crab_Mayo_Split";
        public override GameObject Prefab => Main.bundle.LoadAsset<GameObject>("Crab_Mayo_Split");
		public override ItemStorage ItemStorageFlags => ItemStorage.StackableFood;
		public override string ColourBlindTag => "CM";
    }
}
