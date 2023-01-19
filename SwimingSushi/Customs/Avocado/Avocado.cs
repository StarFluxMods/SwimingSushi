using KitchenData;
using KitchenLib.Customs;
using KitchenLib.References;
using KitchenLib.Utils;
using System.Collections.Generic;
using UnityEngine;

namespace SwimingSushi.Customs
{
	public class Avocado : CustomItem
	{
		public override string UniqueNameID => "Avocado";
		public override GameObject Prefab => Main.bundle.LoadAsset<GameObject>("Avocado");

		public override Appliance DedicatedProvider => (Appliance)GDOUtils.GetCustomGameDataObject<AvocadoProvider>().GameDataObject;

		public override List<Item.ItemProcess> Processes => new List<Item.ItemProcess>
		{
			new Item.ItemProcess{
				Duration = 1f,
				IsBad = false,
				Process = (Process)GDOUtils.GetExistingGDO(ProcessReferences.Chop),
				Result = (Item)GDOUtils.GetCustomGameDataObject<ChoppedAvocado>().GameDataObject
			}
		};

		public override void OnRegister(GameDataObject gameDataObject)
		{
			Item item = (Item)gameDataObject;
			MaterialUtils.ApplyMaterial(item.Prefab, "Avocado", new Material[] {
				MaterialUtils.GetExistingMaterial("Tree Dark"),
				MaterialUtils.GetExistingMaterial("Baked Apple")
			});
		}
	}
}
