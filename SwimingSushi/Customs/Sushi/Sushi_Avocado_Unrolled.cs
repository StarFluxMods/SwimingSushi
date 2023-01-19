using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using System.Collections.Generic;
using UnityEngine;

namespace SwimingSushi.Customs
{
	public class Sushi_Avocado_Unrolled : CustomItemGroup
	{
		public override string UniqueNameID => "Sushi_Avocado_Unrolled";
		public override GameObject Prefab => Main.bundle.LoadAsset<GameObject>("Sushi_Avocado_Unrolled");
		public override List<ItemGroup.ItemSet> Sets => new List<ItemGroup.ItemSet>()
		{
			new ItemGroup.ItemSet()
			{
				Max = 2,
				Min = 2,
				Items = new List<Item>()
				{
					(Item)GDOUtils.GetCustomGameDataObject<PlainSushi_Unrolled>().GameDataObject,
					(Item)GDOUtils.GetCustomGameDataObject<ChoppedAvocado>().GameDataObject
				}
			}
		};

		public override void OnRegister(GameDataObject gameDataObject)
		{
			Item item = (Item)gameDataObject;
			MaterialUtils.ApplyMaterial(item.Prefab, "SushiUnrolled/Nori", new Material[] { MaterialUtils.GetCustomMaterial("Nori") });
			MaterialUtils.ApplyMaterial(item.Prefab, "SushiUnrolled/Rice", new Material[] { MaterialUtils.GetExistingMaterial("Rice") });
			MaterialUtils.ApplyMaterial(item.Prefab, "SushiUnrolled/Avocado", new Material[] { MaterialUtils.GetExistingMaterial("Lettuce") });
		}
	}
}
