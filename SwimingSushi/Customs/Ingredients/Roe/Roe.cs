using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using UnityEngine;

namespace SwimingSushi.Customs
{
    public class Roe : CustomItem
	{
		public override string UniqueNameID => "Roe";
		public override GameObject Prefab => Main.bundle.LoadAsset<GameObject>("Roe");
		public override Appliance DedicatedProvider => (Appliance)GDOUtils.GetCustomGameDataObject<Roe_Provider>().GameDataObject;
	}
}
