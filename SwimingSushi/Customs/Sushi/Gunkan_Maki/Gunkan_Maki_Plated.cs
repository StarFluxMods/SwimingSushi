using KitchenLib.Customs;
using System.Collections.Generic;
using KitchenData;
using UnityEngine;
using KitchenLib.Utils;
using KitchenLib.References;
using Kitchen;

namespace SwimingSushi.Customs
{
	public class Gunkan_Maki_Plated : CustomItemGroup
	{
		public override string UniqueNameID => "Gunkan_Maki_Plated";
		public override GameObject Prefab => Main.bundle.LoadAsset<GameObject>("Gunkan_Maki_Plated");
		public override bool AutoCollapsing => false;
		public override Item DirtiesTo => (Item)GDOUtils.GetExistingGDO(ItemReferences.PlateDirty);
		public override Item DisposesTo => (Item)GDOUtils.GetExistingGDO(ItemReferences.Plate);
		public override bool CanContainSide => true;
		public override List<ItemGroup.ItemSet> Sets => new List<ItemGroup.ItemSet>()
		{
			new ItemGroup.ItemSet()
			{
				Max = 3,
				Min = 3,
				Items = new List<Item>()
				{
					(Item)GDOUtils.GetExistingGDO(ItemReferences.Plate),
					(Item)GDOUtils.GetCustomGameDataObject<Rice_Cooked>().GameDataObject,
					(Item)GDOUtils.GetExistingGDO(ItemReferences.SeaweedCooked)
				},
				IsMandatory = true
			},
			new ItemGroup.ItemSet()
			{
				Max = 1,
				Min = 1,
				Items = new List<Item>()
				{
					(Item)GDOUtils.GetCustomGameDataObject<Roe>().GameDataObject,
				},
				IsMandatory = false
			}
		};
		public override ItemValue ItemValue => ItemValue.Medium;

		public override void OnRegister(GameDataObject gameDataObject)
		{
			ItemGroup item = (ItemGroup)gameDataObject;
			ItemGroupView view = item.Prefab.GetComponent<ItemGroupView>();

			view.ComponentGroups = new List<ItemGroupView.ComponentGroup>
			{
				new ItemGroupView.ComponentGroup
				{
					Item = (Item)GDOUtils.GetCustomGameDataObject<Roe>().GameDataObject,
					GameObject = GameObjectUtils.GetChildObject(item.Prefab, "Gunkan_Maki/Gunkan_Maki/Roe"),
					DrawAll = true
				}
			};
		}
	}
}
