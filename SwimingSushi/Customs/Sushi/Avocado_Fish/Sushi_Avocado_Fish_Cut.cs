using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using UnityEngine;
using System.Collections.Generic;

namespace SwimingSushi.Customs
{
    public class Sushi_Avocado_Fish_Cut : CustomItem
	{
		public override string UniqueNameID => "Sushi_Avocado_Fish_Cut";
		public override GameObject Prefab => Main.bundle.LoadAsset<GameObject>("Fish_Avocado_Cut");
		public override int SplitCount => 3;
		public override Item SplitSubItem => (Item)GDOUtils.GetCustomGameDataObject<Sushi_Avocado_Fish_Split>().GameDataObject;

		public override List<Item> SplitDepletedItems => new List<Item>
		{
			(Item)GDOUtils.GetCustomGameDataObject<Sushi_Avocado_Fish_Split>().GameDataObject
		};

		public override string ColourBlindTag => "AF";
	}
}
