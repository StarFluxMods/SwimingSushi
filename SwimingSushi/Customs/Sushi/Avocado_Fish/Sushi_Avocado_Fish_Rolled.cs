using KitchenData;
using KitchenLib.Customs;
using KitchenLib.References;
using KitchenLib.Utils;
using System.Collections.Generic;
using UnityEngine;

namespace SwimingSushi.Customs
{
    public class Sushi_Avocado_Fish_Rolled : CustomItem
	{
		public override string UniqueNameID => "Sushi_Avocado_Fish_Rolled";
		public override GameObject Prefab => Main.bundle.LoadAsset<GameObject>("Fish_Avocado_Rolled");
		public override List<Item.ItemProcess> Processes => new List<Item.ItemProcess>
		{
			new Item.ItemProcess{
				Duration = 2f,
				IsBad = false,
				Process = (Process)GDOUtils.GetExistingGDO(ProcessReferences.Chop),
				Result = (Item)GDOUtils.GetCustomGameDataObject<Sushi_Avocado_Fish_Cut>().GameDataObject
			}
		};

		public override string ColourBlindTag => "AF";
	}
}
