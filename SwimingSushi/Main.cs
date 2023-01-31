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
using SwimingSushi.Customs.Sushi;
using Kitchen;
using HarmonyLib;
using System.Collections.Generic;

namespace SwimingSushi
{
    public class Main : BaseMod
	{
		public Main() : base("swimingsushi", "Swiming Sushi", "StarFluxGames", "0.1.4", "1.1.3", Assembly.GetExecutingAssembly()) { }

		public static AssetBundle bundle;

		public static CustomDish Sushi_Avocado_Fish_Plated_Dish;
		public static CustomDish Sushi_Crab_Mayo_Plated_Dish;

		public override void OnPostActivate(Mod mod)
		{
			bundle = bundle = mod.GetPacks<AssetBundleModPack>().SelectMany(e => e.AssetBundles).ToList()[0];

			AddGameDataObject<Avocado>();
			AddGameDataObject<AvocadoProvider>();
			AddGameDataObject<ChoppedAvocado>();

			AddGameDataObject<NoriSheet>();
			//AddGameDataObject<PlainSushi_Unrolled>();

			AddGameDataObject<Sushi_Unrolled>();

			/*
			AddGameDataObject<Sushi_Avocado_Unrolled>();
			AddGameDataObject<Sushi_Fish_Unrolled>();
			AddGameDataObject<Sushi_Avocado_Fish_Unrolled>();
			AddGameDataObject<Sushi_Avocado_Fish_Rolled>();
			AddGameDataObject<Sushi_Avocado_Fish_Cut>();
			AddGameDataObject<Sushi_Avocado_Fish_Split>();
			AddGameDataObject<Sushi_Avocado_Fish_Plated>();
			Sushi_Avocado_Fish_Plated_Dish = AddGameDataObject<Sushi_Avocado_Fish_Plated_Dish>();

			
			AddGameDataObject<Sushi_Crab_Unrolled>();
			AddGameDataObject<Sushi_Mayo_Unrolled>();
			AddGameDataObject<Sushi_Crab_Mayo_Unrolled>();
			AddGameDataObject<Sushi_Crab_Mayo_Rolled>();
			AddGameDataObject<Sushi_Crab_Mayo_Cut>();
			AddGameDataObject<Sushi_Crab_Mayo_Split>();
			AddGameDataObject<Sushi_Crab_Mayo_Plated>();
			Sushi_Crab_Mayo_Plated_Dish = AddGameDataObject<Sushi_Crab_Mayo_Plated_Dish>();
			*/

			AddGameDataObject<SalmonProvider>();
			AddGameDataObject<CrabProvider>();

		}

		public override void OnInitialise()
		{

			ItemGroup group = GameData.Main.Get<ItemGroup>(ItemGroupReferences.PizzaRaw);

			if (group.Prefab != null)
			{
				ItemGroupView view = group.Prefab.GetComponent<ItemGroupView>();
				if (view != null)
				{
					Main.instance.Log("=============================");
					Main.instance.Log(view.ComponentGroups.Count.ToString());
					if (view.ComponentGroups.Count > 0)
					{
						foreach (ItemGroupView.ComponentGroup comp in view.ComponentGroups)
						{
							Main.instance.Log(comp.ToString());
							if (comp.Item != null)
								Main.instance.Log("Item: "+comp.Item.name + " -- " + comp.Item.ID);
							if (comp.GameObject != null)
								Main.instance.Log("GameObject: "+comp.GameObject.name);
							foreach (GameObject obj in comp.Objects)
							{
								Main.instance.Log("Objects: -=- "+obj.name);
							}
							Main.instance.Log(comp.DrawAll.ToString());
						}
					}					
				}
			}
			
			
		}

		public override void OnUpdate()
		{
			//((Dish)Sushi_Crab_Mayo_Plated_Dish.GameDataObject).BlockedBy = Sushi_Crab_Mayo_Plated_Dish.HardcodedBlockers;

			Item crabRaw = (Item)GDOUtils.GetExistingGDO(ItemReferences.CrabRaw);
			crabRaw.DedicatedProvider = (Appliance)GDOUtils.GetCustomGameDataObject<CrabProvider>().GameDataObject;

			Item salmonRaw = (Item)GDOUtils.GetExistingGDO(ItemReferences.FishFilletRaw);
			salmonRaw.DedicatedProvider = (Appliance)GDOUtils.GetCustomGameDataObject<SalmonProvider>().GameDataObject;
		}
	}
}