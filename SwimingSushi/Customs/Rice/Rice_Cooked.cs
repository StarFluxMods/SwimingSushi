using KitchenData;
using KitchenLib.Customs;
using KitchenLib.References;
using KitchenLib.Utils;
using System.Collections.Generic;
using UnityEngine;

namespace SwimingSushi.Customs
{
	public class Rice_Cooked : CustomItem
	{
		public override string UniqueNameID => "Rice_Cooked";
		public override GameObject Prefab => Main.bundle.LoadAsset<GameObject>("Rice_Cooked");
		public override ItemStorage ItemStorageFlags => ItemStorage.StackableFood;
		public override List<Item.ItemProcess> Processes => new List<Item.ItemProcess>
		{
			new Item.ItemProcess
			{
				Duration = 1,
				IsBad = false,
				Process = (Process)GDOUtils.GetExistingGDO(ProcessReferences.Knead),
				RequiresWrapper = false,
				Result = (Item)GDOUtils.GetCustomGameDataObject<Rice_Ball>().GameDataObject
			}
		};
	}
}
