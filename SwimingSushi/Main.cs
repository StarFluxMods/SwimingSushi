using KitchenLib;
using KitchenMods;
using System.Linq;
using System.Reflection;
using UnityEngine;
using SwimingSushi.Customs;
using SwimingSushi.Customs.Sushi.Base;
using SwimingSushi.Customs.Sushi.Avocado_Fish;
using SwimingSushi.Customs.Sushi.Crab_Mayo;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.References;
using KitchenLib.Utils;

namespace SwimingSushi
{
    public class Main : BaseMod
	{
		public Main() : base("swimingsushi", "Swiming Sushi", "StarFluxGames", "0.1.1", "1.1.3", Assembly.GetExecutingAssembly()) { }

		public static AssetBundle bundle;

		public static CustomDish Sushi_Avocado_Fish_Plated_Dish;
		public static CustomDish Sushi_Crab_Mayo_Plated_Dish;

		protected override void OnPostActivate(Mod mod)
		{
			bundle = bundle = mod.GetPacks<AssetBundleModPack>().SelectMany(e => e.AssetBundles).ToList()[0];

			AddGameDataObject<Avocado>();
			AddGameDataObject<AvocadoProvider>();
			AddGameDataObject<ChoppedAvocado>();

			AddGameDataObject<NoriSheet>();
			AddGameDataObject<PlainSushi_Unrolled>();

			AddGameDataObject<Sushi_Avocado_Unrolled>();
			AddGameDataObject<Sushi_Avocado_Fish_Unrolled>();
			AddGameDataObject<Sushi_Avocado_Fish_Rolled>();
			AddGameDataObject<Sushi_Avocado_Fish_Cut>();
			AddGameDataObject<Sushi_Avocado_Fish_Split>();
			AddGameDataObject<Sushi_Avocado_Fish_Plated>();
			Sushi_Avocado_Fish_Plated_Dish = AddGameDataObject<Sushi_Avocado_Fish_Plated_Dish>();

			
			AddGameDataObject<Sushi_Crab_Unrolled>();
			AddGameDataObject<Sushi_Crab_Mayo_Unrolled>();
			AddGameDataObject<Sushi_Crab_Mayo_Rolled>();
			AddGameDataObject<Sushi_Crab_Mayo_Cut>();
			AddGameDataObject<Sushi_Crab_Mayo_Split>();
			AddGameDataObject<Sushi_Crab_Mayo_Plated>();
			Sushi_Crab_Mayo_Plated_Dish = AddGameDataObject<Sushi_Crab_Mayo_Plated_Dish>();

			AddGameDataObject<SalmonProvider>();
			AddGameDataObject<CrabProvider>();
		}

		protected override void OnUpdate()
		{
			((Dish)Sushi_Crab_Mayo_Plated_Dish.GameDataObject).BlockedBy = Sushi_Crab_Mayo_Plated_Dish.HardcodedBlockers;

			Item crabRaw = (Item)GDOUtils.GetExistingGDO(ItemReferences.CrabRaw);
			crabRaw.DedicatedProvider = (Appliance)GDOUtils.GetCustomGameDataObject<CrabProvider>().GameDataObject;

			Item salmonRaw = (Item)GDOUtils.GetExistingGDO(ItemReferences.FishFilletRaw);
			salmonRaw.DedicatedProvider = (Appliance)GDOUtils.GetCustomGameDataObject<SalmonProvider>().GameDataObject;
		}
	}
}