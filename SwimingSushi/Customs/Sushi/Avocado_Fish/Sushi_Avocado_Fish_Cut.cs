using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using UnityEngine;
using System.Collections.Generic;

namespace SwimingSushi.Customs.Sushi.Avocado_Fish
{
    public class Sushi_Avocado_Fish_Cut : CustomItem
	{
		public override string UniqueNameID => "Sushi_Avocado_Fish_Cut";
		public override GameObject Prefab => Main.bundle.LoadAsset<GameObject>("Sushi Avocado Fish Cut");
		public override int SplitCount => 3;
		public override Item SplitSubItem => (Item)GDOUtils.GetCustomGameDataObject<Sushi_Avocado_Fish_Split>().GameDataObject;

		public override List<Item> SplitDepletedItems => new List<Item>
		{
			(Item)GDOUtils.GetCustomGameDataObject<Sushi_Avocado_Fish_Split>().GameDataObject
		};

		public override string ColourBlindTag => "AF";
		public override void OnRegister(GameDataObject gameDataObject)
		{
			Item item = (Item)gameDataObject;
			MaterialUtils.ApplyMaterial(item.Prefab, "Model/Sushi_Cut", new Material[] {
				MaterialUtils.GetExistingMaterial("Raw Fish Spiny"),
				MaterialUtils.GetCustomMaterial("Nori"),
				MaterialUtils.GetExistingMaterial("Rice"),
				MaterialUtils.GetExistingMaterial("Lettuce")
			});
			
		}
	}
}
