using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
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
				MaterialUtils.GetExistingMaterial("Tree Dark"),
				MaterialUtils.GetExistingMaterial("Lettuce"),
				MaterialUtils.GetExistingMaterial("Baked Apple")
			});
		}
	}
}
