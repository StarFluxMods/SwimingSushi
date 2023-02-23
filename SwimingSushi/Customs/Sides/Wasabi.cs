using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using UnityEngine;

namespace SwimingSushi.Customs
{
	public class Wasabi : CustomItem
	{
		public override string UniqueNameID => "Wasabi";
		public override GameObject Prefab => Main.bundle.LoadAsset<GameObject>("Wasabi");

		public override Appliance DedicatedProvider => (Appliance)GDOUtils.GetCustomGameDataObject<Wasabi_Provider>().GameDataObject;
		public override bool IsMergeableSide => true;
		public override ItemValue ItemValue => ItemValue.SideSmall;
	}
}
