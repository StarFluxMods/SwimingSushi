using Kitchen;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.References;
using KitchenLib.Utils;
using System.Collections.Generic;
using UnityEngine;

namespace SwimingSushi.Customs
{
	public class Sushi_Crab_Mayo_Unrolled : CustomItemGroup
	{
		public override string UniqueNameID => "Sushi_Crab_Mayo_Unrolled";
		public override GameObject Prefab => Main.bundle.LoadAsset<GameObject>("Crab_Mayo_Unrolled");
		public override List<Item.ItemProcess> Processes => new List<Item.ItemProcess>
		{
			new Item.ItemProcess{
				Duration = 1f,
				IsBad = false,
				Process = (Process)GDOUtils.GetExistingGDO(ProcessReferences.Knead),
				Result = (Item)GDOUtils.GetCustomGameDataObject<Sushi_Crab_Mayo_Rolled>().GameDataObject
			}
		};
		public override List<ItemGroup.ItemSet> Sets => new List<ItemGroup.ItemSet>()
		{
			new ItemGroup.ItemSet()
			{
				Max = 1,
				Min = 1,
				Items = new List<Item>()
				{
					(ItemGroup)GDOUtils.GetCustomGameDataObject<PlainSushi_Unrolled>().GameDataObject
				},
				IsMandatory = true
			},
			new ItemGroup.ItemSet()
			{
				Max = 2,
				Min = 2,
				Items = new List<Item>()
				{
					(Item)GDOUtils.GetExistingGDO(ItemReferences.CrabChopped),
					(Item)GDOUtils.GetExistingGDO(ItemReferences.Mayonnaise)
				}
			}
		};
		public override string ColourBlindTag => "CM";

		public override void OnRegister(GameDataObject gameDataObject)
		{
			ItemGroup item = (ItemGroup)gameDataObject;
			ItemGroupView view = item.Prefab.GetComponent<ItemGroupView>();

			view.ComponentGroups = new List<ItemGroupView.ComponentGroup>
			{
				new ItemGroupView.ComponentGroup
				{
					Item = (Item)GDOUtils.GetExistingGDO(ItemReferences.CrabChopped),
					GameObject = GameObjectUtils.GetChildObject(item.Prefab, "Crab"),
					DrawAll = true
				},

				new ItemGroupView.ComponentGroup
				{
					Item = (Item)GDOUtils.GetExistingGDO(ItemReferences.Mayonnaise),
					GameObject = GameObjectUtils.GetChildObject(item.Prefab, "Mayo"),
					DrawAll = true
				}
			};
		}
	}
}
