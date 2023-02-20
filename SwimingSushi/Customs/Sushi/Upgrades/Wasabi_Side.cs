using KitchenData;
using KitchenLib.Customs;
using KitchenLib.References;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using KitchenLib.Utils;

namespace SwimingSushi.Customs
{
	public class Wasabi_Side : CustomDish
	{
		public override string UniqueNameID => "Wasabi_Side";
		public override DishType Type => DishType.Side;
		public override DishCustomerChange CustomerMultiplier => DishCustomerChange.SmallDecrease;
		public override CardType CardType => CardType.Default;
		public override Unlock.RewardLevel ExpReward => Unlock.RewardLevel.Small;
		public override UnlockGroup UnlockGroup => UnlockGroup.Dish;
		public override List<Dish.MenuItem> ResultingMenuItems => new List<Dish.MenuItem>
		{
			new Dish.MenuItem
			{
				Item = (Item)GDOUtils.GetCustomGameDataObject<Wasabi>().GameDataObject,
				Phase = MenuPhase.Side,
				Weight = 1
			}
		};
		public override HashSet<Item> MinimumIngredients => new HashSet<Item>
		{
			(Item)GDOUtils.GetCustomGameDataObject<Wasabi>().GameDataObject
		};

		public override List<Unlock> HardcodedRequirements => new List<Unlock>
		{
			(Unlock)GDOUtils.GetCustomGameDataObject<Sushi_Avocado_Fish_Plated_Dish>().GameDataObject,
			(Unlock)GDOUtils.GetCustomGameDataObject<Sushi_Crab_Mayo_Plated_Dish>().GameDataObject
		};

		public override Dictionary<Locale, string> Recipe => new Dictionary<Locale, string>
		{
			{ Locale.English, "Add Wasabi to your plated dish!" }
		};
		public override List<(Locale, UnlockInfo)> InfoList => new()
		{
			( Locale.English, LocalisationUtils.CreateUnlockInfo("Wasabi", "Adds Wasabi as a side", "") )
		};
	}
}