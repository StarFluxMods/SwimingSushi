using KitchenData;
using KitchenLib.Customs;
using KitchenLib.References;
using KitchenLib.Utils;
using System.Collections.Generic;
using UnityEngine;

namespace SwimingSushi.Customs.Sushi.Avocado_Fish
{
    public class Sushi_Avocado_Fish_Unrolled : CustomItemGroup
	{
		public override string UniqueNameID => "Sushi_Avocado_Fish_Unrolled";
		public override GameObject Prefab => Main.bundle.LoadAsset<GameObject>("Sushi Avocado Fish Unrolled");
		public override List<Item.ItemProcess> Processes => new List<Item.ItemProcess>
		{
			new Item.ItemProcess{
				Duration = 1f,
				IsBad = false,
				Process = (Process)GDOUtils.GetExistingGDO(ProcessReferences.Knead),
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
				},
				IsMandatory = true
			},
			new ItemGroup.ItemSet()
			{
				Max = 2,
				Min = 2,
				Items = new List<Item>()
				{
					(Item)GDOUtils.GetCustomGameDataObject<Sushi_Fish_Unrolled>().GameDataObject,
					(Item)GDOUtils.GetCustomGameDataObject<ChoppedAvocado>().GameDataObject
				},
				IsMandatory = true
			}
		};
		public override string ColourBlindTag => "AF";

		public override void OnRegister(GameDataObject gameDataObject)
		{
			ItemGroup item = (ItemGroup)gameDataObject;
			MaterialUtils.ApplyMaterial(item.Prefab, "Model/Nori", new Material[] { MaterialUtils.GetCustomMaterial("Nori") });
			MaterialUtils.ApplyMaterial(item.Prefab, "Model/Rice", new Material[] { MaterialUtils.GetCustomMaterial("NoriRice") });
			MaterialUtils.ApplyMaterial(item.Prefab, "Model/Avocado", new Material[] { MaterialUtils.GetExistingMaterial("Lettuce") });
			MaterialUtils.ApplyMaterial(item.Prefab, "Model/Fillet", new Material[] { MaterialUtils.GetExistingMaterial("Raw Fish Spiny") });
		}
	}
}
