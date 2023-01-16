using Kitchen;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.References;
using KitchenLib.Utils;
using System.Collections.Generic;
using UnityEngine;

namespace SwimingSushi.Customs
{
	public class Sushi_Avocado_Fish_Split : CustomItem
	{
		public override string UniqueNameID => "Sushi_Avocado_Fish_Split";
		public override GameObject Prefab => Main.bundle.LoadAsset<GameObject>("SushiSplit");

		public override void OnRegister(GameDataObject gameDataObject)
		{
			Item item = (Item)gameDataObject;
			MaterialUtils.ApplyMaterial(item.Prefab, "SushiSplit/Sushi_Split", new Material[] {
				MaterialUtils.GetExistingMaterial("Raw Fish Spiny"),
				MaterialUtils.GetCustomMaterial("Nori"),
				MaterialUtils.GetExistingMaterial("Rice"),
				MaterialUtils.GetExistingMaterial("Lettuce")
			});
		}
	}
}
