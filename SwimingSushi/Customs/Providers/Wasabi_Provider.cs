using KitchenData;
using KitchenLib.Customs;
using KitchenLib.References;
using KitchenLib.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace SwimingSushi.Customs.Providers
{
	internal class Wasabi_Provider : CustomAppliance
	{
		public override string UniqueNameID => "Wasabi_Plant";
		public override int BaseGameDataObjectID => ApplianceReferences.SourceApple;
		public override GameObject Prefab => Main.bundle.LoadAsset<GameObject>("Wasabi_Plant");

		public override List<(Locale, ApplianceInfo)> InfoList => new List<(Locale, ApplianceInfo)>
		{
			(
				Locale.English,
				new ApplianceInfo
				{
					Name = "Wasabi",
					Description = "Provides Wasabi"
				}
			)
		};
		public override List<IApplianceProperty> Properties => new List<IApplianceProperty>
		{
			KitchenPropertiesUtils.GetUnlimitedCItemProvider(GDOUtils.GetCustomGameDataObject<Wasabi>().GameDataObject.ID)
		};
	}
}
