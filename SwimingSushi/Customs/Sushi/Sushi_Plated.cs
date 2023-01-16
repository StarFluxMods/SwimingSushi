using KitchenLib.Customs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KitchenData;
using UnityEngine;
using KitchenLib.Utils;

namespace SwimingSushi.Customs.Sushi
{
	public class Sushi_Plated : CustomItem
	{
	}
	public class Sushi_Plated_Dish : CustomDish
	{
		public override DishType Type => DishType.Main;

		public override List<string> Starting

		public override GameObject DisplayPrefab => ((Item)GDOUtils.GetCustomGameDataObject<Sushi_Plated>().GameDataObject).Prefab;
		public override GameObject IconPrefab => ((Item)GDOUtils.GetCustomGameDataObject<Sushi_Plated>().GameDataObject).Prefab;
	}
}
