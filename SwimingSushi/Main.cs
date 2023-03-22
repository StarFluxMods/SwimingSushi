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
using Kitchen;
using System.IO;
using System.Collections.Generic;

namespace SwimingSushi
{
	public class Main : BaseMod
	{
		public Main() : base("swimingsushi", "Swimming Sushi", "StarFluxGames", "0.2.3", ">=1.1.4", Assembly.GetExecutingAssembly()) { }

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

			AddGameDataObject<Roe_Provider>();
			AddGameDataObject<Roe>();
			//AddGameDataObject<Gunkan_Maki_Base>();
			AddGameDataObject<Gunkan_Maki>();
			AddGameDataObject<Gunkan_Maki_Plated>();
			AddGameDataObject<Gunkan_Maki_Dish>();

			//AddGameDataObject<Sushi_Bandana>();

			AddGameDataObject<Salmon>();
			AddGameDataObject<Salmon_Sliced>();
		}

		public static Texture2D GetApplianceSnapshot(GameObject prefab)
		{
			int instanceID = prefab.GetInstanceID();
			if (PrefabSnapshot.Snapshots == null)
			{
				PrefabSnapshot.Snapshots = new Dictionary<int, Texture2D>();
			}
			bool flag = !PrefabSnapshot.Snapshots.ContainsKey(instanceID) || PrefabSnapshot.Snapshots[instanceID] == null;
			if (flag)
			{
				PrefabSnapshot.CacheShaderValues();
				Quaternion rotation = Quaternion.LookRotation(new Vector3(1f, -1f, 1f), new Vector3(0f, 1f, 1f));
				SnapshotTexture snapshotTexture = Snapshot.RenderPrefabToTexture(8192, 8192, prefab, rotation, 0.5f, 0.5f, -10f, 10f, 0.5f, -0.25f * new Vector3(0f, 1f, 1f));
				PrefabSnapshot.ResetShaderValues();
				PrefabSnapshot.Snapshots[instanceID] = snapshotTexture.Snapshot;
			}
			return PrefabSnapshot.Snapshots[instanceID];
		}

		public override void OnInitialise()
		{
			foreach (Decor decor in GameData.Main.Get<Decor>())
			{
				if (decor.Type == LayoutMaterialType.Wallpaper)
				{
					decor.Material.SetTexture("_Overlay", bundle.LoadAsset<Texture>("Sushi_Wallpaper"));
				}
			}
		}

		public override void OnFrameUpdate()
		{
			Item crabRaw = (Item)GDOUtils.GetExistingGDO(ItemReferences.CrabRaw);
			crabRaw.DedicatedProvider = (Appliance)GDOUtils.GetCustomGameDataObject<CrabProvider>().GameDataObject;
		}
	}
}