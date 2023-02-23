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

namespace SwimingSushi
{
	public class Main : BaseMod
	{
		public Main() : base("swimingsushi", "Swimming Sushi", "StarFluxGames", "0.2.0", "1.1.4", Assembly.GetExecutingAssembly()) { }

		public static AssetBundle bundle;

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
			AddGameDataObject<Sushi_Avocado_Fish_Plated>();AddGameDataObject<Sushi_Avocado_Fish_Plated_Dish>();

			
			AddGameDataObject<Sushi_Crab_Mayo_Unrolled>();
			AddGameDataObject<Sushi_Crab_Mayo_Rolled>();
			AddGameDataObject<Sushi_Crab_Mayo_Cut>();
			AddGameDataObject<Sushi_Crab_Mayo_Split>();
			AddGameDataObject<Sushi_Crab_Mayo_Plated>();
			AddGameDataObject<Sushi_Crab_Mayo_Plated_Dish>();
			

			AddGameDataObject<SalmonProvider>();
			AddGameDataObject<CrabProvider>();
			AddGameDataObject<Sushi_Soy_Sauce>();

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

			AddGameDataObject<Rice_Pot>();
			AddGameDataObject<Cooked_Rice_Pot>();
			AddGameDataObject<Rice_Cooked>();
			AddGameDataObject<Rice_Ball>();

			AddGameDataObject<Onigiri>();
			AddGameDataObject<Onigiri_Plated>();
			AddGameDataObject<Onigiri_Dish>();

		}

		public override void OnFrameUpdate()
		{
			Item crabRaw = (Item)GDOUtils.GetExistingGDO(ItemReferences.CrabRaw);
			crabRaw.DedicatedProvider = (Appliance)GDOUtils.GetCustomGameDataObject<CrabProvider>().GameDataObject;

			Item salmonRaw = (Item)GDOUtils.GetExistingGDO(ItemReferences.FishFilletRaw);
			salmonRaw.DedicatedProvider = (Appliance)GDOUtils.GetCustomGameDataObject<SalmonProvider>().GameDataObject;
		}
	}
}