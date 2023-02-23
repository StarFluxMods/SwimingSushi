using System.Collections.Generic;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.References;
using KitchenLib.Utils;
using UnityEngine;

namespace SwimingSushi.Customs
{
    public class Cooked_Mega_Rice : CustomItem
    {
        public override string UniqueNameID => "Cooked_Mega_Rice";
        public override GameObject Prefab => Main.bundle.LoadAsset<GameObject>("Cooked_Mega_Rice");
		public override List<Item.ItemProcess> Processes => new List<Item.ItemProcess>
		{
			new Item.ItemProcess
			{
				Duration = 3,
				IsBad = true,
				Process = (Process)GDOUtils.GetExistingGDO(ProcessReferences.Cook),
				RequiresWrapper = false,
				Result = (Item)GDOUtils.GetExistingGDO(ItemReferences.BurnedFood)
			}
		};
	}
}
