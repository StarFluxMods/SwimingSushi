using KitchenData;
using KitchenLib.Customs;
using UnityEngine;

namespace SwimingSushi.Customs
{
	public class Rice_Ball : CustomItem
	{
		public override string UniqueNameID => "Rice_Ball";
		public override GameObject Prefab => Main.bundle.LoadAsset<GameObject>("Rice_Ball");
		public override ItemStorage ItemStorageFlags => ItemStorage.StackableFood;
	}
}
