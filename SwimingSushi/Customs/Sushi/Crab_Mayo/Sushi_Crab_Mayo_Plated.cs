using KitchenLib.Customs;
using System.Collections.Generic;
using KitchenData;
using UnityEngine;
using KitchenLib.Utils;
using KitchenLib.References;
using System.Reflection;
using SwimingSushi.Customs.Sushi.Avocado_Fish;

namespace SwimingSushi.Customs.Sushi.Crab_Mayo
{
    public class Sushi_Crab_Mayo_Plated : CustomItemGroup
    {
        public override string UniqueNameID => "Sushi_Crab_Mayo_Plated";
        public override GameObject Prefab => Main.bundle.LoadAsset<GameObject>("Sushi Crab Mayo Plated");
        public override bool AutoCollapsing => false;
        public override Item DirtiesTo => (Item)GDOUtils.GetExistingGDO(ItemReferences.PlateDirty);
		public override Item DisposesTo => (Item)GDOUtils.GetExistingGDO(ItemReferences.Plate);
		public override bool CanContainSide => true;
		public override List<ItemGroup.ItemSet> Sets => new List<ItemGroup.ItemSet>()
        {
            new ItemGroup.ItemSet()
            {
                Max = 2,
                Min = 2,
                Items = new List<Item>()
                {
                    (Item)GDOUtils.GetCustomGameDataObject<Sushi_Crab_Mayo_Split>().GameDataObject,
                    (Item)GDOUtils.GetExistingGDO(ItemReferences.Plate)
                },
				OrderingOnly = false,
				IsMandatory = true,
				RequiresUnlock = false
			}
        };
		public override ItemValue ItemValue => ItemValue.Large;

		public override void OnRegister(GameDataObject gameDataObject)
        {
            ItemGroup item = (ItemGroup)gameDataObject;
            MaterialUtils.ApplyMaterial(item.Prefab, "Plate", new Material[]
            {
                MaterialUtils.GetExistingMaterial("Plate"),
                MaterialUtils.GetExistingMaterial("Plate - Ring")
            });
			MaterialUtils.ApplyMaterial(item.Prefab, "Sushi", new Material[] {
				MaterialUtils.GetExistingMaterial("Crab - Raw Shell"),
				MaterialUtils.GetCustomMaterial("Nori"),
				MaterialUtils.GetExistingMaterial("Rice")
			});
		}
		public override string ColourBlindTag => "CM";
	}
	public class Sushi_Crab_Mayo_Plated_Dish : CustomDish
	{
		//CustomGameDataObject
		public override string UniqueNameID => "Sushi_Crab_Mayo_Plated_Dish";
		public override int BaseGameDataObjectID => DishReferences.BurgerBase;
		
		//CustomUnlock
		public override Unlock.RewardLevel ExpReward => Unlock.RewardLevel.Medium;
		public override bool IsUnlockable => true;
		public override UnlockGroup UnlockGroup => UnlockGroup.Dish;
		public override CardType CardType => CardType.Default;
		public override int MinimumFranchiseTier => 0;
		public override bool IsSpecificFranchiseTier => false;
		public override DishCustomerChange CustomerMultiplier => DishCustomerChange.SmallDecrease;
		public override float SelectionBias => 0;
		public override List<Unlock> HardcodedRequirements => new List<Unlock> { (Unlock)GDOUtils.GetCustomGameDataObject<Sushi_Avocado_Fish_Plated_Dish>().GameDataObject };
		public override List<Unlock> HardcodedBlockers => new List<Unlock> { };

		//CustomDish
		public override string AchievementName => "";
		public override DishType Type => DishType.Main;
		public override HashSet<Item> MinimumIngredients => new HashSet<Item>()
		{
			(Item)GDOUtils.GetExistingGDO(ItemReferences.Seaweed),
			(Item)GDOUtils.GetExistingGDO(ItemReferences.Wok),
			(Item)GDOUtils.GetExistingGDO(ItemReferences.Rice),
			(Item)GDOUtils.GetExistingGDO(ItemReferences.CrabRaw),
			(Item)GDOUtils.GetExistingGDO(ItemReferences.Egg),
			(Item)GDOUtils.GetExistingGDO(ItemReferences.Oil)
		};

		
		public override HashSet<Process> RequiredProcesses => new HashSet<Process>
		{
			(Process)GDOUtils.GetExistingGDO(ProcessReferences.Cook),
			(Process)GDOUtils.GetExistingGDO(ProcessReferences.Chop),
			(Process)GDOUtils.GetExistingGDO(ProcessReferences.Knead),
		};

		public override List<Dish.MenuItem> ResultingMenuItems => new List<Dish.MenuItem>
		{
			new Dish.MenuItem
			{
				Item = (Item)GDOUtils.GetCustomGameDataObject<Sushi_Crab_Mayo_Plated>().GameDataObject,
				Phase = MenuPhase.Main,
				Weight = 1,
				DynamicMenuType = DynamicMenuType.Static,
				DynamicMenuIngredient = null
			}
		};
		public override HashSet<Dish.IngredientUnlock> IngredientsUnlocks => new HashSet<Dish.IngredientUnlock>
		{
			new Dish.IngredientUnlock
			{
				MenuItem = (ItemGroup)GDOUtils.GetCustomGameDataObject<Sushi_Crab_Mayo_Plated>().GameDataObject,
				Ingredient = (Item)GDOUtils.GetExistingGDO(ItemReferences.CrabRaw)
			}
		};
		public override Dictionary<Locale, string> Recipe => new Dictionary<Locale, string>
		{
			{ Locale.English, "Combine 2 Cooked Seaweed to make Nori, add some Rice, Chopped Crab, then Mayonnaise and roll for serving!" }
		};

		public override void OnRegister(GameDataObject gameDataObject)
		{
			Dish dish = (Dish)gameDataObject;
			LocalisationObject<UnlockInfo> info = new LocalisationObject<UnlockInfo>();
			FieldInfo dictionary = ReflectionUtils.GetField<LocalisationObject<UnlockInfo>>("Dictionary");
			Dictionary<Locale, UnlockInfo> dict = new Dictionary<Locale, UnlockInfo>();
			dict.Add(Locale.English, new UnlockInfo
			{
				Name = "Crab Roll",
				Description = "Adds Crab Rolls as a Main"
			});
			dictionary.SetValue(info, dict);
			dish.Info = info;
		}
	}
}
