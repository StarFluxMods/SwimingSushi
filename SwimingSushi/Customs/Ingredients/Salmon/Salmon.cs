using KitchenData;
using KitchenLib.Customs;
using KitchenLib.References;
using KitchenLib.Utils;
using System.Collections.Generic;
using UnityEngine;

namespace SwimingSushi.Customs
{
	public class Salmon : CustomItem
	{
		public override string UniqueNameID => "Salmon";
		public override GameObject Prefab => Main.bundle.LoadAsset<GameObject>("Salmon");
		public override Appliance DedicatedProvider => (Appliance)GDOUtils.GetCustomGameDataObject<SalmonProvider>().GameDataObject;
		public override List<Item.ItemProcess> Processes => new List<Item.ItemProcess>
		{
			new Item.ItemProcess
			{
				 Duration = 2,
				 IsBad = false,
				 Process = (Process)GDOUtils.GetExistingGDO(ProcessReferences.Chop),
				 RequiresWrapper = false,
				 Result = (Item)GDOUtils.GetCustomGameDataObject<Salmon_Sliced>().GameDataObject
			}
		};
	}
}
