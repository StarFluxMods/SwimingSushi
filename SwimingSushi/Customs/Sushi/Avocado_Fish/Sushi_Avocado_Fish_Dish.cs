using KitchenLib.Customs;
using System.Collections.Generic;
using KitchenData;
using UnityEngine;
using KitchenLib.Utils;
using KitchenLib.References;
using System.Reflection;

namespace SwimingSushi.Customs
{
	public class Sushi_Avocado_Fish_Plated_Dish : CustomDish
	{
		//CustomGameDataObject
		public override string UniqueNameID => "Sushi_Avocado_Fish_Plated_Dish";
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
		public override List<Unlock> HardcodedRequirements => new List<Unlock> { };
		public override List<Unlock> HardcodedBlockers => new List<Unlock> { };

		//CustomDish
		public override string AchievementName => "";
		public override DishType Type => DishType.Base;
		public override List<string> StartingNameSet => new List<string> {
			"Sushi Train",
			"Su Shi Is Funny",
			"Swim Fish! Swim!",
			"Fish Oasis",
			"Wrap Me Sushi",
		};
		public override HashSet<Item> MinimumIngredients => new HashSet<Item>()
		{
			(Item)GDOUtils.GetExistingGDO(ItemReferences.Seaweed),
			(Item)GDOUtils.GetExistingGDO(ItemReferences.Pot),
			(Item)GDOUtils.GetExistingGDO(ItemReferences.Water),
			(Item)GDOUtils.GetExistingGDO(ItemReferences.Rice),
			(Item)GDOUtils.GetExistingGDO(ItemReferences.FishFilletRaw),
			(Item)GDOUtils.GetCustomGameDataObject<Avocado>().GameDataObject,
		};
		public override HashSet<Process> RequiredProcesses => new HashSet<Process>
		{
			(Process)GDOUtils.GetExistingGDO(ProcessReferences.Cook),
			(Process)GDOUtils.GetExistingGDO(ProcessReferences.Chop),
			(Process)GDOUtils.GetExistingGDO(ProcessReferences.Knead),
		};
		public override GameObject IconPrefab => Main.bundle.LoadAsset<GameObject>("Sushi_Icon");
		public override GameObject DisplayPrefab => ((Item)GDOUtils.GetCustomGameDataObject<Sushi_Avocado_Fish_Plated>().GameDataObject).Prefab;
		public override List<Dish.MenuItem> ResultingMenuItems => new List<Dish.MenuItem>
		{
			new Dish.MenuItem
			{
				Item = (Item)GDOUtils.GetCustomGameDataObject<Sushi_Avocado_Fish_Plated>().GameDataObject,
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
				MenuItem = (ItemGroup)GDOUtils.GetCustomGameDataObject<Sushi_Avocado_Fish_Plated>().GameDataObject,
				Ingredient = (Item)GDOUtils.GetCustomGameDataObject<Avocado>().GameDataObject
			}
		};
		public override bool IsAvailableAsLobbyOption => true;
		public override bool DestroyAfterModUninstall => false;
        public override Dictionary<Locale, string> Recipe => new Dictionary<Locale, string>
        {
            { Locale.English, "Combine 2 Cooked Seaweed to make Nori, Boil some Rice, Chopped Avocado, then Fish Fillet and roll for serving!" }
        };

        public override void OnRegister(GameDataObject gameDataObject)
        {
            Dish dish = (Dish)gameDataObject;
            LocalisationObject<UnlockInfo> info = new LocalisationObject<UnlockInfo>();
            FieldInfo dictionary = ReflectionUtils.GetField<LocalisationObject<UnlockInfo>>("Dictionary");
            Dictionary<Locale, UnlockInfo> dict = new Dictionary<Locale, UnlockInfo>();
            dict.Add(Locale.English, new UnlockInfo
            {
                Name = "Sushi",
                Description = "Adds Sushi as a Main"
            });
            dictionary.SetValue(info, dict);
            dish.Info = info;

			/*
            MaterialUtils.ApplyMaterial(dish.IconPrefab, "Plate/Plate/Cylinder", new Material[]
            {
                MaterialUtils.GetExistingMaterial("Plate"),
                MaterialUtils.GetExistingMaterial("Plate - Ring")
            });
            MaterialUtils.ApplyMaterial(dish.IconPrefab, "Sushi/SushiSplit/SushiSplit/Sushi_Split", new Material[]
            {
                MaterialUtils.GetExistingMaterial("Raw Fish Spiny"),
                MaterialUtils.GetCustomMaterial("Nori"),
                MaterialUtils.GetExistingMaterial("Rice"),
                MaterialUtils.GetExistingMaterial("Lettuce")
            });
			*/
        }
    }
}
