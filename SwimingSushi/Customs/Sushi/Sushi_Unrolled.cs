using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using KitchenLib.References;
using System.Collections.Generic;
using Kitchen;
using SwimingSushi.Customs.Sushi.Base;
using UnityEngine;
using System.Security.Policy;
using System;

namespace SwimingSushi.Customs.Sushi
{
	public class Sushi_Unrolled : CustomItemGroup<SushiView>
	{
		public override string UniqueNameID => "Sushi_Unrolled";
		//CustomItem
		public override GameObject Prefab => Main.bundle.LoadAsset<GameObject>("Sushi_Unrolled");
		public override float ExtraTimeGranted => 0;
		public override ItemValue ItemValue => ItemValue.Small;
		public override int Reward => 3;
		public override int MaxOrderSharers => 0;
		public override int SplitCount => 0;
		public override float SplitSpeed => 1;
		public override bool AllowSplitMerging => false;
		public override bool PreventExplicitSplit => false;
		public override bool SplitByComponents => false;
		public override bool SplitByCopying => false;
		public override bool IsIndisposable => false;
		public override ItemCategory ItemCategory => ItemCategory.Generic;
		public override ItemStorage ItemStorageFlags => ItemStorage.None;
		public override ToolAttachPoint HoldPose => ToolAttachPoint.Generic;
		public override bool IsMergeableSide => false;
		public override List<Item.ItemProcess> Processes => new List<Item.ItemProcess>
		{
			new Item.ItemProcess{
				Process = (Process)GDOUtils.GetExistingGDO(ProcessReferences.Cook),
				Result = null,
				Duration = 8,
				IsBad = false,
				RequiresWrapper = false
			}
		};
		public override List<IItemProperty> Properties => new List<IItemProperty>
		{
			new CPreventItemMerge()
		};
		//CustomItemGroup
		public override bool CanContainSide => false;
		public override bool ApplyProcessesToComponents => false;
		public override bool AutoCollapsing => false;
		public override List<ItemGroup.ItemSet> Sets => new List<ItemGroup.ItemSet>
		{
			new ItemGroup.ItemSet
			{
				Items = new List<Item>
				{
					(Item)GDOUtils.GetCustomGameDataObject<NoriSheet>().GameDataObject,
					(Item)GDOUtils.GetExistingGDO(ItemReferences.RiceContainerCooked)
				},
				Min = 2,
				Max = 2,
				IsMandatory = true,
				RequiresUnlock = false,
				OrderingOnly = false
			},
			new ItemGroup.ItemSet
			{
				Items = new List<Item>
				{
					(Item)GDOUtils.GetCustomGameDataObject<ChoppedAvocado>().GameDataObject,
					(Item)GDOUtils.GetExistingGDO(ItemReferences.FishFillet),
					(Item)GDOUtils.GetExistingGDO(ItemReferences.CrabChopped),
					(Item)GDOUtils.GetExistingGDO(ItemReferences.Mayonnaise)
				},
				Min = 0,
				Max = 2,
				IsMandatory = false,
				RequiresUnlock = false,
				OrderingOnly = false
			}
		};

		public override void OnRegister(GameDataObject gameDataObject)
		{

			ItemGroup itemGroup = (ItemGroup)gameDataObject;
			MaterialUtils.ApplyMaterial(itemGroup.Prefab, "Model/Nori", new Material[] { MaterialUtils.GetCustomMaterial("Nori") });
			MaterialUtils.ApplyMaterial(itemGroup.Prefab, "Model/Rice", new Material[] { MaterialUtils.GetCustomMaterial("NoriRice") });

			MaterialUtils.ApplyMaterial(itemGroup.Prefab, "Model/Avocado", new Material[] { MaterialUtils.GetExistingMaterial("Lettuce") });
			MaterialUtils.ApplyMaterial(itemGroup.Prefab, "Model/Fillet", new Material[] { MaterialUtils.GetExistingMaterial("Raw Fish Spiny") });
			MaterialUtils.ApplyMaterial(itemGroup.Prefab, "Model/Crab", new Material[] { MaterialUtils.GetExistingMaterial("Crab - Raw Shell") });
			MaterialUtils.ApplyMaterial(itemGroup.Prefab, "Model/Mayo", new Material[] { MaterialUtils.GetExistingMaterial("Mayonnaise") });
		}
	}

	public class SushiView : ItemGroupView
	{
		void Start()
		{
			this.ComponentGroups = new List<ComponentGroup>
			{
				new ComponentGroup
				{
					Item = (Item)GDOUtils.GetCustomGameDataObject<ChoppedAvocado>().GameDataObject,
					GameObject = GameObjectUtils.GetChildObject(this.gameObject, "Model/Avocado"),
					DrawAll = true
				},
				new ComponentGroup
				{
					Item = (Item)GDOUtils.GetExistingGDO(ItemReferences.FishFillet),
					GameObject = GameObjectUtils.GetChildObject(this.gameObject, "Model/Fillet"),
					DrawAll = true
				},
				new ComponentGroup
				{
					Item = (Item)GDOUtils.GetExistingGDO(ItemReferences.CrabChopped),
					GameObject = GameObjectUtils.GetChildObject(this.gameObject, "Model/Crab"),
					DrawAll = true
				},
				new ComponentGroup
				{
					Item = (Item)GDOUtils.GetExistingGDO(ItemReferences.Mayonnaise),
					GameObject = GameObjectUtils.GetChildObject(this.gameObject, "Model/Mayo"),
					DrawAll = true
				}
			};
		}
	}
}
