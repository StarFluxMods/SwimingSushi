using KitchenData;
using KitchenLib.Customs;
using KitchenLib.References;
using KitchenLib.Utils;
using System.Collections.Generic;
using UnityEngine;

namespace SwimingSushi.Customs.Providers
{
    public class AvocadoProvider : CustomAppliance
    {
        public override string UniqueNameID => "AvocadoProvider";
        public override int BaseGameDataObjectID => ApplianceReferences.SourceApple;
        public override GameObject Prefab => Main.bundle.LoadAsset<GameObject>("Avocado_Provider");
		public override List<(Locale, ApplianceInfo)> InfoList => new List<(Locale, ApplianceInfo)>
		{
			(
				Locale.English,
				new ApplianceInfo
				{
					Name = "Avocados",
					Description = "Provides Avocados"
				}
			)
		};
		public override List<IApplianceProperty> Properties => new List<IApplianceProperty>
        {
            KitchenPropertiesUtils.GetUnlimitedCItemProvider(GDOUtils.GetCustomGameDataObject<Avocado>().GameDataObject.ID)
        };
    }
}
