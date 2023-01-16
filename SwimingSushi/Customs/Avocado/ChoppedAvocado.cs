using KitchenData;
using KitchenLib.Customs;
using KitchenLib.References;
using KitchenLib.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace SwimingSushi.Customs
{
	public class ChoppedAvocado : CustomItem
	{
		public override string UniqueNameID => "ChoppedAvocado";
		public override GameObject Prefab => Main.bundle.LoadAsset<GameObject>("Avocado_Chopped");

		public override void OnRegister(GameDataObject gameDataObject)
		{
			Item item = (Item)gameDataObject;
			MaterialUtils.ApplyMaterial(item.Prefab, "Avocado.Slices", new Material[] {
				MaterialUtils.GetExistingMaterial("Lettuce"),
				MaterialUtils.GetExistingMaterial("Lettuce"),
				MaterialUtils.GetExistingMaterial("Lettuce")
			});
		}
	}
}
