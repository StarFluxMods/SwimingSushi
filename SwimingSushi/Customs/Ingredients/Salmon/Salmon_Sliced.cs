using KitchenData;
using KitchenLib.Customs;
using KitchenLib.References;
using KitchenLib.Utils;
using System.Collections.Generic;
using UnityEngine;

namespace SwimingSushi.Customs
{
	public class Salmon_Sliced : CustomItem
	{
		public override string UniqueNameID => "Salmon_Sliced";
		public override GameObject Prefab => Main.bundle.LoadAsset<GameObject>("Salmon_Sliced");
	}
}
