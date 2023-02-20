using KitchenLib.Customs;
using System.Collections.Generic;
using KitchenData;
using UnityEngine;
using KitchenLib.Utils;
using KitchenLib.References;
using System.Reflection;

namespace SwimingSushi.Customs
{
	public class Nigiri_Dish : CustomDish
	{
		//CustomGameDataObject
		public override string UniqueNameID => "Nigiri_Dish";
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
			(Item)GDOUtils.GetExistingGDO(ItemReferences.Wok),
			(Item)GDOUtils.GetExistingGDO(ItemReferences.Rice),
			(Item)GDOUtils.GetExistingGDO(ItemReferences.FishFilletRaw)
		};

		
		public override HashSet<Process> RequiredProcesses => new HashSet<Process>
		{
			(Process)GDOUtils.GetExistingGDO(ProcessReferences.Cook),
			(Process)GDOUtils.GetExistingGDO(ProcessReferences.Chop),
		};

		public override List<Dish.MenuItem> ResultingMenuItems => new List<Dish.MenuItem>
		{
			new Dish.MenuItem
			{
				Item = (Item)GDOUtils.GetCustomGameDataObject<Nigiri_Plated>().GameDataObject,
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
				MenuItem = (ItemGroup)GDOUtils.GetCustomGameDataObject<Nigiri_Plated>().GameDataObject,
				Ingredient = (Item)GDOUtils.GetExistingGDO(ItemReferences.FishFilletRaw)
			}
		};
		public override Dictionary<Locale, string> Recipe => new Dictionary<Locale, string>
		{
			{ Locale.English, "Combine Cooked Rice, and some Fish Fillet to make your Nigiri!" }
		};

		public override void OnRegister(GameDataObject gameDataObject)
		{
			Dish dish = (Dish)gameDataObject;
			LocalisationObject<UnlockInfo> info = new LocalisationObject<UnlockInfo>();
			FieldInfo dictionary = ReflectionUtils.GetField<LocalisationObject<UnlockInfo>>("Dictionary");
			Dictionary<Locale, UnlockInfo> dict = new Dictionary<Locale, UnlockInfo>();
			dict.Add(Locale.English, new UnlockInfo
			{
				Name = "Nigiri",
				Description = "Adds Nigiri as a Main"
			});
			dictionary.SetValue(info, dict);
			dish.Info = info;
		}
	}
}
