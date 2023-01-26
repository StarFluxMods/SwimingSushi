using KitchenData;
using KitchenLib.Customs;
using KitchenLib.References;
using KitchenLib.Utils;
using System.Collections.Generic;
using UnityEngine;

namespace SwimingSushi.Customs
{
	public class CrabProvider : CustomAppliance
	{
		public override string UniqueNameID => "CrabProvider";
		public override int BaseGameDataObjectID => ApplianceReferences.SourceApple;
		public override GameObject Prefab => Main.bundle.LoadAsset<GameObject>("Crab Tank");

		public override string Name => "Crab";
		public override List<IApplianceProperty> Properties => new List<IApplianceProperty>
		{
			KitchenPropertiesUtils.GetUnlimitedCItemProvider(ItemReferences.CrabRaw)
		};

		public override void OnRegister(GameDataObject gameDataObject)
		{
			Appliance appliance = (Appliance)gameDataObject;
			MaterialUtils.ApplyMaterial(appliance.Prefab, "Fish_Tank/Fish Tank", new Material[] {
				MaterialUtils.GetExistingMaterial("AppleGreen"),
				MaterialUtils.GetExistingMaterial("Door Glass"),
				MaterialUtils.GetExistingMaterial("Plastic - Black"),
				MaterialUtils.GetExistingMaterial("Paper - Menu Body")
			});

			MaterialUtils.ApplyMaterial(appliance.Prefab, "Fish_Tank/Crab - Raw", new Material[] {
				MaterialUtils.GetExistingMaterial("Crab - Raw Shell")
			});

			MaterialUtils.ApplyMaterial(appliance.Prefab, "Fish_Tank/Crab - Raw.001", new Material[] {
				MaterialUtils.GetExistingMaterial("Crab - Raw Shell")
			});

			MaterialUtils.ApplyMaterial(appliance.Prefab, "Fish_Tank/Crab - Raw.002", new Material[] {
				MaterialUtils.GetExistingMaterial("Crab - Raw Shell")
			});
			
			MaterialUtils.ApplyMaterial(appliance.Prefab, "Crate", new Material[] {
				MaterialUtils.GetExistingMaterial("Wood - Default")
			});
		}
	}
}
