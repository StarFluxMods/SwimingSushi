using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kitchen;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using KitchenLib.References;
using SwimingSushi.Customs.Sushi.Avocado_Fish;
using SwimingSushi.Customs.Sushi.Crab_Mayo;
using UnityEngine;
using System.Reflection;

namespace SwimingSushi.Customs.Sushi.Upgrades
{
	public class Sushi_Soy_Sauce : CustomDish
	{
		public override string UniqueNameID => "Sushi_Soy_Sauce";

		public override DishType Type => DishType.Extra;
		public override string AchievementName => "";
		public override GameObject IconPrefab => null;
		public override GameObject DisplayPrefab => null;
		public override Unlock.RewardLevel ExpReward => Unlock.RewardLevel.Medium;
		public override bool IsUnlockable => true;
		public override UnlockGroup UnlockGroup => UnlockGroup.Dish;
		public override CardType CardType => CardType.Default;
		public override int MinimumFranchiseTier => 0;
		public override bool IsSpecificFranchiseTier => false;
		public override DishCustomerChange CustomerMultiplier => DishCustomerChange.SmallDecrease;
		public override float SelectionBias => 0;
		public override HashSet<Dish.IngredientUnlock> ExtraOrderUnlocks => new HashSet<Dish.IngredientUnlock>
		{
			new Dish.IngredientUnlock
			{
				MenuItem = (ItemGroup)GDOUtils.GetCustomGameDataObject<Sushi_Avocado_Fish_Plated>().GameDataObject,
				Ingredient = (Item)GDOUtils.GetExistingGDO(ItemReferences.CondimentSoySauce)
			},
			new Dish.IngredientUnlock
			{
				MenuItem = (ItemGroup)GDOUtils.GetCustomGameDataObject<Sushi_Crab_Mayo_Plated>().GameDataObject,
				Ingredient = (Item)GDOUtils.GetExistingGDO(ItemReferences.CondimentSoySauce)
			}
		};
		public override List<Unlock> HardcodedBlockers => new List<Unlock> { };
		public override HashSet<Item> MinimumIngredients => new HashSet<Item>
		{
			(Item)GDOUtils.GetExistingGDO(ItemReferences.CondimentSoySauce)
		};
		public override Dictionary<Locale, string> Recipe => new Dictionary<Locale, string>
		{
			{ Locale.English, "Combine 2 Cooked Seaweed to make Nori, add some Rice, Chopped Crab, then Mayonnaise and roll for serving!" }
		};
		public override List<Unlock> HardcodedRequirements => new List<Unlock> { (Unlock)GDOUtils.GetCustomGameDataObject<Sushi_Avocado_Fish_Plated_Dish>().GameDataObject };

		public override void OnRegister(GameDataObject gameDataObject)
		{
			Dish dish = (Dish)gameDataObject;
			LocalisationObject<UnlockInfo> info = new LocalisationObject<UnlockInfo>();
			FieldInfo dictionary = ReflectionUtils.GetField<LocalisationObject<UnlockInfo>>("Dictionary");
			Dictionary<Locale, UnlockInfo> dict = new Dictionary<Locale, UnlockInfo>();
			dict.Add(Locale.English, new UnlockInfo
			{
				Name = "Sushi - Soy Sauce",
				Description = "Adds Soy Sauce as a menu option"
			});
			dictionary.SetValue(info, dict);
			dish.Info = info;
		}
	}
}
