using KitchenData;
using KitchenLib.Customs;
using KitchenLib.References;
using KitchenLib.Utils;
using System.Collections.Generic;
using UnityEngine;

namespace SwimingSushi.Customs
{
	public class SalmonProvider : CustomAppliance
	{
		public override string UniqueNameID => "SalmonProvider";
		public override int BaseGameDataObjectID => ApplianceReferences.SourceApple;
		public override GameObject Prefab => Main.bundle.LoadAsset<GameObject>("Fish Tank");

		public override string Name => "Salmon";
		public override List<IApplianceProperty> Properties => new List<IApplianceProperty>
		{
			KitchenPropertiesUtils.GetUnlimitedCItemProvider(ItemReferences.FishFilletRaw)
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

			MaterialUtils.ApplyMaterial(appliance.Prefab, "Fish_Tank/Salmon", new Material[] {
				MaterialUtils.GetExistingMaterial("Plastic - Grey"),
				MaterialUtils.GetExistingMaterial("Plastic - Grey")
			});

			MaterialUtils.ApplyMaterial(appliance.Prefab, "Fish_Tank/Salmon.001", new Material[] {
				MaterialUtils.GetExistingMaterial("Plastic - Grey"),
				MaterialUtils.GetExistingMaterial("Plastic - Grey")
			});

			MaterialUtils.ApplyMaterial(appliance.Prefab, "Fish_Tank/Salmon.002", new Material[] {
				MaterialUtils.GetExistingMaterial("Plastic - Grey"),
				MaterialUtils.GetExistingMaterial("Plastic - Grey")
			});
			
			MaterialUtils.ApplyMaterial(appliance.Prefab, "Crate", new Material[] {
				MaterialUtils.GetExistingMaterial("Wood - Default")
			});
		}
	}
}
