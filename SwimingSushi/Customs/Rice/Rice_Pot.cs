using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kitchen;
using KitchenData;
using KitchenLib;
using KitchenLib.Customs;
using KitchenLib.References;
using KitchenLib.Utils;
using UnityEngine;

namespace SwimingSushi.Customs.Rice
{
	public class Rice_Pot : CustomItemGroup
	{
		public override string UniqueNameID => "Rice_Pot";
		public override GameObject Prefab => Main.bundle.LoadAsset<GameObject>("Rice_Pot");
		public override bool AutoCollapsing => false;
		public override List<Item.ItemProcess> Processes => new List<Item.ItemProcess>
		{
			new Item.ItemProcess
			{
				Duration = 3,
				IsBad = false,
				Process = (Process)GDOUtils.GetExistingGDO(ProcessReferences.Cook),
				RequiresWrapper = false,
				Result = (Item)GDOUtils.GetCustomGameDataObject<Cooked_Rice_Pot>().GameDataObject
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
					(Item)GDOUtils.GetExistingGDO(ItemReferences.Pot)
				},
				IsMandatory = true
			},
			new ItemGroup.ItemSet()
			{
				Max = 2,
				Min = 2,
				Items = new List<Item>()
				{
					(Item)GDOUtils.GetExistingGDO(ItemReferences.Rice),
					(Item)GDOUtils.GetExistingGDO(ItemReferences.Water)
				}
			}
		};
		
		public override void OnRegister(GameDataObject gameDataObject)
		{
			ItemGroup item = (ItemGroup)gameDataObject;
			ItemGroupView view = item.Prefab.GetComponent<ItemGroupView>();

			view.ComponentGroups = new List<ItemGroupView.ComponentGroup>
			{
				new ItemGroupView.ComponentGroup
				{
					Item = (Item)GDOUtils.GetExistingGDO(ItemReferences.Rice),
					GameObject = GameObjectUtils.GetChildObject(item.Prefab, "Rice"),
					DrawAll = true
				},

				new ItemGroupView.ComponentGroup
				{
					Item = (Item)GDOUtils.GetExistingGDO(ItemReferences.Water),
					GameObject = GameObjectUtils.GetChildObject(item.Prefab, "Water"),
					DrawAll = true
				}
			};
		}
		
	}
}
