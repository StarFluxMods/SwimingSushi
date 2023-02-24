using KitchenLib.Customs;
using System.Collections.Generic;
using KitchenData;
using UnityEngine;
using KitchenLib.Utils;
using KitchenLib.References;
using Kitchen;

namespace SwimingSushi.Customs
{
	public class Onigiri_Plated : CustomItemGroup
	{
		public override string UniqueNameID => "Onigiri_Plated";
		public override GameObject Prefab => Main.bundle.LoadAsset<GameObject>("Onigiri_Plated");
		public override bool AutoCollapsing => false;
		public override Item DirtiesTo => (Item)GDOUtils.GetExistingGDO(ItemReferences.PlateDirty);
		public override Item DisposesTo => (Item)GDOUtils.GetExistingGDO(ItemReferences.Plate);
		public override bool CanContainSide => true;
		public override List<ItemGroup.ItemSet> Sets => new List<ItemGroup.ItemSet>()
		{
			new ItemGroup.ItemSet()
			{
				Max = 1,
				Min = 1,
				Items = new List<Item>()
				{
					(Item)GDOUtils.GetExistingGDO(ItemReferences.Plate)
				},
				IsMandatory = true
			},
			new ItemGroup.ItemSet()
			{
				Max = 2,
				Min = 2,
				Items = new List<Item>()
				{
					(Item)GDOUtils.GetCustomGameDataObject<Rice_Ball>().GameDataObject,
					(Item)GDOUtils.GetExistingGDO(ItemReferences.SeaweedCooked),
				},
				IsMandatory = false
			}
		};
		public override ItemValue ItemValue => ItemValue.Small;

		public override void OnRegister(GameDataObject gameDataObject)
		{
			ItemGroup item = (ItemGroup)gameDataObject;
			ItemGroupView view = item.Prefab.GetComponent<ItemGroupView>();

			view.ComponentGroups = new List<ItemGroupView.ComponentGroup>
			{
				new ItemGroupView.ComponentGroup
				{
					Item = (Item)GDOUtils.GetCustomGameDataObject<Rice_Ball>().GameDataObject,
					GameObject = GameObjectUtils.GetChildObject(item.Prefab, "Onigiri/Onigiri/Cube"),
					DrawAll = true
				},

				new ItemGroupView.ComponentGroup
				{
					Item = (Item)GDOUtils.GetExistingGDO(ItemReferences.SeaweedCooked),
					GameObject = GameObjectUtils.GetChildObject(item.Prefab, "Onigiri/Onigiri/Cube.001"),
					DrawAll = true
				}
			};
		}
	}
}
