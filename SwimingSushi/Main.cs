using KitchenLib;
using KitchenMods;
using System.Linq;
using System.Reflection;
using UnityEngine;
using SwimingSushi.Customs;
using SwimingSushi.Customs.Sushi;

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
		}
	}
}