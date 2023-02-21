using KitchenLib.Customs;
using UnityEngine;

namespace SwimingSushi.Customs.Rice
{
	public class Rice_Cooked : CustomItem
	{
		public override string UniqueNameID => "Rice_Cooked";
		public override GameObject Prefab => Main.bundle.LoadAsset<GameObject>("Rice_Cooked");
	}
}
