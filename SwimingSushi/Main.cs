using KitchenLib;
using KitchenLib.Event;
using KitchenMods;
using System.Linq;
using System.Reflection;
using UnityEngine;
using SwimingSushi.Customs;
using SwimingSushi.Customs.Sushi.Base;
using SwimingSushi.Customs.Sushi.Avocado_Fish;
using SwimingSushi.Customs.Sushi.Crab_Mayo;
using KitchenData;
using KitchenLib.Utils;
using System.Collections.Generic;

namespace SwimingSushi
{
    public class Main : BaseMod
	{
		public Main() : base("swimingsushi", "Swiming Sushi", "StarFluxGames", "0.1.0", "1.1.3", Assembly.GetExecutingAssembly()) { }

		public static AssetBundle bundle;

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
			AddGameDataObject<Sushi_Avocado_Fish_Plated_Dish>();

			/*
			AddGameDataObject<Sushi_Crab_Unrolled>();
			AddGameDataObject<Sushi_Crab_Mayo_Unrolled>();
			AddGameDataObject<Sushi_Crab_Mayo_Rolled>();
			AddGameDataObject<Sushi_Crab_Mayo_Cut>();
			AddGameDataObject<Sushi_Crab_Mayo_Split>();
			AddGameDataObject<Sushi_Crab_Mayo_Plated>();
			AddGameDataObject<Sushi_Crab_Mayo_Plated_Dish>();
			*/

			Events.BuildGameDataEvent += (s, args) =>
			{
				Main.instance.Log("=========Hello World");
				//FieldInfo prerequisiteDishesEditor = ReflectionUtils.GetField<Unlock>("HardcodedBlockers");
				foreach (Dish dish in args.gamedata.Get<Dish>())
				{
					foreach (Unlock unlock in dish.BlockedBy)
					{
					}
				}
			};
		}
	}
}