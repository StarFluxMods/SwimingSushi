using KitchenData;
using KitchenLib.Customs;
using KitchenLib.References;
using KitchenLib.Utils;
using UnityEngine;
using System.Collections.Generic;
using Kitchen;

namespace SwimingSushi.Customs
{
	public class Sushi_Avocado_Fish_Cut : CustomItem
	{
		public override string UniqueNameID => "Sushi_Avocado_Fish_Cut";
		public override GameObject Prefab => Main.bundle.LoadAsset<GameObject>("SushiCut");
		public override int SplitCount => 3;
		public override Item SplitSubItem => (Item)GDOUtils.GetCustomGameDataObject<Sushi_Avocado_Fish_Split>().GameDataObject;

		public override List<Item> SplitDepletedItems => new List<Item>
		{
			(Item)GDOUtils.GetCustomGameDataObject<Sushi_Avocado_Fish_Split>().GameDataObject
		};

		public override void OnRegister(GameDataObject gameDataObject)
		{
			Item item = (Item)gameDataObject;
			MaterialUtils.ApplyMaterial(item.Prefab, "SushiCut/Sushi_Cut", new Material[] {
				MaterialUtils.GetExistingMaterial("Raw Fish Spiny"),
				MaterialUtils.GetCustomMaterial("Nori"),
				MaterialUtils.GetExistingMaterial("Rice"),
				MaterialUtils.GetExistingMaterial("Lettuce")
			});
		}
	}
}
