using KitchenLib;
using KitchenMods;
using System.Linq;
using System.Reflection;
using UnityEngine;
using SwimingSushi.Customs;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.References;
using KitchenLib.Utils;
using SwimingSushi.Customs.Sushi.Upgrades;
using SwimingSushi.Customs.Providers;
using SwimingSushi.Customs.Sushi.Mega_Nigiri;

namespace SwimingSushi
{
	public class Main : BaseMod
	{
		public Main() : base("swimingsushi", "Swiming Sushi", "StarFluxGames", "0.1.7", "1.1.4", Assembly.GetExecutingAssembly()) { }

		public static AssetBundle bundle;

		public static CustomDish Sushi_Avocado_Fish_Plated_Dish;
		public static CustomDish Sushi_Crab_Mayo_Plated_Dish;
		public static CustomDish Sushi_Soy_Sauce;

		public override void OnPostActivate(Mod mod)
		{
			bundle = bundle = mod.GetPacks<AssetBundleModPack>().SelectMany(e => e.AssetBundles).ToList()[0];

			AddGameDataObject<Avocado>();
			AddGameDataObject<AvocadoProvider>();
			AddGameDataObject<ChoppedAvocado>();

			AddGameDataObject<NoriSheet>();
			AddGameDataObject<PlainSushi_Unrolled>();
			
			AddGameDataObject<Sushi_Avocado_Fish_Unrolled>();
			AddGameDataObject<Sushi_Avocado_Fish_Rolled>();
			AddGameDataObject<Sushi_Avocado_Fish_Cut>();
			AddGameDataObject<Sushi_Avocado_Fish_Split>();
			AddGameDataObject<Sushi_Avocado_Fish_Plated>();
			Sushi_Avocado_Fish_Plated_Dish = AddGameDataObject<Sushi_Avocado_Fish_Plated_Dish>();

			
			AddGameDataObject<Sushi_Crab_Mayo_Unrolled>();
			AddGameDataObject<Sushi_Crab_Mayo_Rolled>();
			AddGameDataObject<Sushi_Crab_Mayo_Cut>();
			AddGameDataObject<Sushi_Crab_Mayo_Split>();
			AddGameDataObject<Sushi_Crab_Mayo_Plated>();
			Sushi_Crab_Mayo_Plated_Dish = AddGameDataObject<Sushi_Crab_Mayo_Plated_Dish>();
			

			AddGameDataObject<SalmonProvider>();
			AddGameDataObject<CrabProvider>();
			Sushi_Soy_Sauce = AddGameDataObject<Sushi_Soy_Sauce>();

			AddGameDataObject<Wasabi_Provider>();
			AddGameDataObject<Wasabi>();
			AddGameDataObject<Wasabi_Side>();

			AddGameDataObject<Nigiri>();
			AddGameDataObject<Nigiri_Plated>();
			AddGameDataObject<Double_Nigiri>();
			AddGameDataObject<Double_Nigiri_Plated>();

			AddGameDataObject<Nigiri_Dish>();
			AddGameDataObject<Double_Nigiri_Dish>();

			AddGameDataObject<Mega_Rice_Tier1>();
			AddGameDataObject<Mega_Rice_Tier2>();
			AddGameDataObject<Cooked_Mega_Rice>();
			AddGameDataObject<Mega_Nigiri>();
			AddGameDataObject<Mega_Nigiri_Plated>();
			AddGameDataObject<Mega_Nigiri_Dish>();

		}

		public override void OnFrameUpdate()
		{
			((Dish)Sushi_Crab_Mayo_Plated_Dish.GameDataObject).BlockedBy = Sushi_Crab_Mayo_Plated_Dish.HardcodedBlockers;
			((Dish)Sushi_Soy_Sauce.GameDataObject).BlockedBy = Sushi_Soy_Sauce.HardcodedBlockers;

			Item crabRaw = (Item)GDOUtils.GetExistingGDO(ItemReferences.CrabRaw);
			crabRaw.DedicatedProvider = (Appliance)GDOUtils.GetCustomGameDataObject<CrabProvider>().GameDataObject;

			Item salmonRaw = (Item)GDOUtils.GetExistingGDO(ItemReferences.FishFilletRaw);
			salmonRaw.DedicatedProvider = (Appliance)GDOUtils.GetCustomGameDataObject<SalmonProvider>().GameDataObject;
		}
	}
}