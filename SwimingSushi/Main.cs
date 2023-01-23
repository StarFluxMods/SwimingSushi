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
using System.Collections.Generic;
using Kitchen;
using KitchenLib.References;
using KitchenLib.Customs;
using HarmonyLib;
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
		}

		protected override void OnUpdate()
		{
			((Dish)Sushi_Crab_Mayo_Plated_Dish.GameDataObject).BlockedBy = Sushi_Crab_Mayo_Plated_Dish.HardcodedBlockers;
		}
	}

	public class sys : GenericSystemBase, IModSystem
	{
		private FixedSeedContext Seed(int category_seed, int instance, string seed)
		{
			bool flag = !Preferences.Get<bool>(Pref.SeedsAffectEverything);
			FixedSeedContext result;
			if (flag)
			{
				result = default(FixedSeedContext);
			}
			else
			{
				result = new FixedSeedContext(new Seed(seed), category_seed * 1231231 + instance);
			}
			return result;
		}

		private HashSet<int> CurrentUnlockIDs = new HashSet<int>();
		
		public static string seed = "aaaaa";
		public static int day = 3;

		private static System.Random random = new System.Random();

		public static string RandomString(int length)
		{
			const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
			return new string(Enumerable.Repeat(chars, length)
				.Select(s => s[random.Next(s.Length)]).ToArray());
		}

		protected override void OnUpdate()
		{
			using (FixedSeedContext fixedSeedContext = Seed(848292, day, seed.ToLower()))
			{
				this.CurrentUnlockIDs.Clear();
				this.CurrentUnlockIDs.Add(Main.Sushi_Avocado_Fish_Plated_Dish.ID);

				UnlockPack unlockPack = GameData.Main.Get<UnlockPack>(UnlockPackReferences.DefaultCompositePack);

				using (fixedSeedContext.UseSubcontext())
				{
					UnlockOptions options = unlockPack.GetOptions(this.CurrentUnlockIDs, new UnlockRequest(day, 0));
					//Main.instance.Log("----- " + seed.ToLower() + " ----- Day " + day + " -----");
					if (options.Unlock1 != null)
					{
						//Main.instance.Log(options.Unlock1.Name);
					}
					if (options.Unlock2 != null)
					{
						//Main.instance.Log(options.Unlock2.Name);
					}
				}
			}

			seed = RandomString(5);
		}
	}

	[HarmonyPatch(typeof(ItemSetView), "IsGroupSatisfied")]
	public class test
	{
		public static void Postfix(ItemSetView __instance, Satisfaction __result, ItemGroupData group, ItemList items)
		{
			if (group.ID == GDOUtils.GetCustomGameDataObject<Sushi_Avocado_Fish_Plated>().ID)
			{
				Main.instance.Log(IsGroupSatisfied(group, items).ToString());
			}
		}
		private static List<bool> TempUsed = new List<bool>();
		public static Satisfaction IsSetSatisfied(ItemSetData item_set, ItemList items, ref List<bool> used)
		{
			int num = 0;
			foreach (int num2 in item_set.Items)
			{
				for (int i = 0; i < items.Count; i++)
				{
					bool flag = !used[i] && num2 == items[i];
					if (flag)
					{
						used[i] = true;
						num++;
						break;
					}
				}
				bool flag2 = num > item_set.Max;
				if (flag2)
				{
					return Satisfaction.Impossible;
				}
			}
			bool flag3 = num < item_set.Min;
			Satisfaction result;
			if (flag3)
			{
				result = (item_set.IsMandatory ? Satisfaction.Impossible : Satisfaction.Partial);
			}
			else
			{
				result = Satisfaction.Correct;
			}
			return result;
		}
		public static Satisfaction IsGroupSatisfied(ItemGroupData group, ItemList items)
		{
			TempUsed.Fill(items.Count, false);
			Satisfaction satisfaction = Satisfaction.Correct;
			foreach (ItemSetData item_set in group.Sets)
			{
				Satisfaction satisfaction2 = IsSetSatisfied(item_set, items, ref TempUsed);
				if (satisfaction2 == Satisfaction.Impossible)
				{
					Main.instance.Log("11111111111111111111111111111111111111111111111");
					satisfaction = Satisfaction.Impossible;
				}
				if (satisfaction2 == Satisfaction.Partial)
				{
					if (satisfaction == Satisfaction.Correct)
					{
						satisfaction = Satisfaction.Partial;
					}
				}
			}
			for (int i = 0; i < TempUsed.Count; i++)
			{
				if (!TempUsed[i])
				{
					Item item = GameData.Main.Get<Item>(items[i]);
					Main.instance.Log(item.name + " : " + item.IsMergeableSide);
					Main.instance.Log(group + " : " + group.CanHaveSide);
					if (GameData.Main.TryGet<Item>(items[i], out item, true) && item.IsMergeableSide && group.CanHaveSide)
					{
						//Main.instance.Log(item.name);
						//Main.instance.Log(item.IsMergeableSide +" : "+ group.CanHaveSide);
						TempUsed[i] = true;
						break;
					}
				}
			}
			foreach (bool flag7 in TempUsed)
			{
				if (!flag7)
				{
					Main.instance.Log("222222222222222222222222222222222222222");
					return Satisfaction.Impossible;
				}
			}
			return satisfaction;
		}
	}
}