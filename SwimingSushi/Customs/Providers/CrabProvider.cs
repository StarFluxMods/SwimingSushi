using KitchenData;
using KitchenLib.Customs;
using KitchenLib.References;
using KitchenLib.Utils;
using System.Collections.Generic;
using UnityEngine;

namespace SwimingSushi.Customs.Providers
{
    public class CrabProvider : CustomAppliance
    {
        public override string UniqueNameID => "CrabProvider";
        public override int BaseGameDataObjectID => ApplianceReferences.SourceApple;
        public override GameObject Prefab => Main.bundle.LoadAsset<GameObject>("Crab_Tank");
		public override List<(Locale, ApplianceInfo)> InfoList => new List<(Locale, ApplianceInfo)>
		{
			(
				Locale.English,
				new ApplianceInfo
				{
					Name = "Crab",
					Description = "Provides Crab"
				}
			)
		};
		public override List<IApplianceProperty> Properties => new List<IApplianceProperty>
        {
            KitchenPropertiesUtils.GetUnlimitedCItemProvider(ItemReferences.CrabRaw)
        };

        public override void OnRegister(GameDataObject gameDataObject)
        {
            Appliance appliance = (Appliance)gameDataObject;
            GameObjectUtils.GetChildObject(appliance.Prefab, "Fish_Tank/Fish Tank").GetComponent<MeshRenderer>().materials[1] = MaterialUtils.GetExistingMaterial("Door Glass");
        }
    }
}
