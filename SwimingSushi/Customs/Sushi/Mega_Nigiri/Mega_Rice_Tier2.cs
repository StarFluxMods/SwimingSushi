using System.Collections.Generic;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.References;
using KitchenLib.Utils;
using SwimingSushi.Customs.Rice;
using UnityEngine;

namespace SwimingSushi.Customs.Sushi.Mega_Nigiri
{
    public class Mega_Rice_Tier2 : CustomItemGroup
    {
        public override string UniqueNameID => "Mega_Rice_Tier2";
        public override GameObject Prefab => Main.bundle.LoadAsset<GameObject>("Mega_Rice_Tier2");
		/*
		public override List<Item.ItemProcess> Processes => new List<Item.ItemProcess>
		{
			new Item.ItemProcess
			{
				Duration = 5,
				IsBad = false,
				Process = (Process)GDOUtils.GetExistingGDO(ProcessReferences.Cook),
				RequiresWrapper = false,
				Result = (Item)GDOUtils.GetCustomGameDataObject<Cooked_Mega_Rice>().GameDataObject
			}
		};
		*/
		public override List<ItemGroup.ItemSet> Sets => new List<ItemGroup.ItemSet>()
        {
            new ItemGroup.ItemSet()
            {
                Max = 2,
                Min = 2,
                Items = new List<Item>()
                {
                    (Item)GDOUtils.GetCustomGameDataObject<Mega_Rice_Tier1>().GameDataObject,
					(Item)GDOUtils.GetCustomGameDataObject<Rice_Cooked>().GameDataObject,
                },
                IsMandatory = true
            }
        };
        public override bool AutoCollapsing => true;
    }
}
