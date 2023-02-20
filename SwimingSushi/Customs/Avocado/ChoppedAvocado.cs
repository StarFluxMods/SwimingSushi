using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using UnityEngine;

namespace SwimingSushi.Customs
{
	public class ChoppedAvocado : CustomItem
	{
		public override string UniqueNameID => "ChoppedAvocado";
		public override GameObject Prefab => Main.bundle.LoadAsset<GameObject>("Avocado_Chopped");
	}
}
