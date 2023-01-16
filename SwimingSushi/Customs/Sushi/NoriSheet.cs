using KitchenData;
using KitchenLib.Customs;
using KitchenLib.References;
using KitchenLib.Utils;
using UnityEngine;

namespace SwimingSushi.Customs
{
	public class NoriSheet : CustomItem
	{
		public override string UniqueNameID => "norisheet";
		public override GameObject Prefab => Main.bundle.LoadAsset<GameObject>("NoriSheet");

		public override void OnRegister(GameDataObject gameDataObject)
		{
			Item item = (Item)gameDataObject;
			MaterialUtils.ApplyMaterial(item.Prefab, "SushiUnrolled/Nori", new Material[] { MaterialUtils.GetCustomMaterial("Nori") });
			MaterialUtils.ApplyMaterial(item.Prefab, "SushiUnrolled/Rice", new Material[] { MaterialUtils.GetExistingMaterial("Rice") });


			((Item)GDOUtils.GetExistingGDO(ItemReferences.Flour)).DerivedProcesses.Add(new Item.ItemProcess
			{
				Duration = 1,
				IsBad = false,
				Process = (Process)GDOUtils.GetExistingGDO(ProcessReferences.Cook),
				Result = item
			});
		}
	}
}
