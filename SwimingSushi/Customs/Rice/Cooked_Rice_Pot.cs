using Kitchen;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.References;
using KitchenLib.Utils;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace SwimingSushi.Customs.Rice
{
	public class Cooked_Rice_Pot : CustomItem
	{
		public override string UniqueNameID => "Cooked_Rice_Pot";
		public override GameObject Prefab => Main.bundle.LoadAsset<GameObject>("Cooked_Rice_Pot");
		public override Item SplitSubItem => (Item)GDOUtils.GetCustomGameDataObject<Rice_Cooked>().GameDataObject;
		public override int SplitCount => 3;
		public override List<Item> SplitDepletedItems => new List<Item>
		{
			(Item)GDOUtils.GetExistingGDO(ItemReferences.Pot)
		};

		public override void OnRegister(GameDataObject gameDataObject)
		{
			Item item = (Item)gameDataObject;
			ObjectsSplittableView view = item.Prefab.AddComponent<ObjectsSplittableView>();

			FieldInfo info = ReflectionUtils.GetField<ObjectsSplittableView>("Objects");
			List<GameObject> list = new List<GameObject>();
			list.Add(GameObjectUtils.GetChildObject(item.Prefab, "Rice_Bottom"));
			list.Add(GameObjectUtils.GetChildObject(item.Prefab, "Rice_Middle"));
			list.Add(GameObjectUtils.GetChildObject(item.Prefab, "Rice_Top"));
			info.SetValue(view, list);
		}
	}
}
