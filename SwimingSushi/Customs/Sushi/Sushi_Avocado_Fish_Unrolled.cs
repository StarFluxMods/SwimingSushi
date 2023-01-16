using KitchenData;
using KitchenLib.Customs;
using KitchenLib.References;
using KitchenLib.Utils;
using System.Collections.Generic;
using UnityEngine;

namespace SwimingSushi.Customs
{
	public class Sushi_Avocado_Fish_Unrolled : CustomItemGroup
	{
		public override string UniqueNameID => "Sushi_Avocado_Fish_Unrolled";
		public override GameObject Prefab => Main.bundle.LoadAsset<GameObject>("Sushi_Avocado_Fish_Unrolled");
		public override List<Item.ItemProcess> Processes => new List<Item.ItemProcess>
		{
			new Item.ItemProcess{
				Duration = 1f,
				IsBad = false,
				Process = (Process)GDOUtils.GetExistingGDO(ProcessReferences.Chop),
				Result = (Item)GDOUtils.GetCustomGameDataObject<Sushi_Avocado_Fish_Rolled>().GameDataObject
			}
		};
		public override bool AutoCollapsing => true;
		public override List<ItemGroup.ItemSet> Sets => new List<ItemGroup.ItemSet>()
		{
			new ItemGroup.ItemSet()
			{
				Max = 2,
				Min = 2,
				Items = new List<Item>()
				{
					(Item)GDOUtils.GetCustomGameDataObject<Sushi_Avocado_Unrolled>().GameDataObject,
					(Item)GDOUtils.GetExistingGDO(ItemReferences.FishFillet)
				}
			},
			new ItemGroup.ItemSet()
			{
				Max = 2,
				Min = 2,
				Items = new List<Item>()
				{
					(Item)GDOUtils.GetCustomGameDataObject<Sushi_Fish_Unrolled>().GameDataObject,
					(Item)GDOUtils.GetCustomGameDataObject<ChoppedAvocado>().GameDataObject
				}
			}
		};

		public override void OnRegister(GameDataObject gameDataObject)
		{
			ItemGroup item = (ItemGroup)gameDataObject;
			MaterialUtils.ApplyMaterial(item.Prefab, "SushiUnrolled/Nori", new Material[] { MaterialUtils.GetCustomMaterial("Nori") });
			MaterialUtils.ApplyMaterial(item.Prefab, "SushiUnrolled/Rice", new Material[] { MaterialUtils.GetExistingMaterial("Rice") });
			MaterialUtils.ApplyMaterial(item.Prefab, "SushiUnrolled/Avocado", new Material[] { MaterialUtils.GetExistingMaterial("Lettuce") });
			MaterialUtils.ApplyMaterial(item.Prefab, "SushiUnrolled/Fillet", new Material[] { MaterialUtils.GetExistingMaterial("Raw Fish Spiny") });
		}
	}
}
