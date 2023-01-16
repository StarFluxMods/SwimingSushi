using KitchenData;
using KitchenLib.Customs;
using KitchenLib.References;
using KitchenLib.Utils;
using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace SwimingSushi.Customs
{
	public class FishProvider : CustomAppliance
	{
		public override string UniqueNameID => "FishProvider";
		public override int BaseGameDataObjectID => ApplianceReferences.SourceApple;
		public override GameObject Prefab => Main.bundle.LoadAsset<GameObject>("Fish_Provider");

		public override string Name => "Fish";
		public override List<IApplianceProperty> Properties => new List<IApplianceProperty>
		{
			KitchenPropertiesUtils.GetUnlimitedCItemProvider(-2145487392)
		};

		public override void OnRegister(GameDataObject gameDataObject)
		{
			Appliance appliance = (Appliance)gameDataObject;

			MaterialUtils.ApplyMaterial(appliance.Prefab, "Provider - Avocado/Crate/CrateMesh", new Material[] {
				MaterialUtils.GetExistingMaterial("Raw Fish Spiny")
			});

			MaterialUtils.ApplyMaterial(appliance.Prefab, "Body/SubMesh_0", new Material[] {
				MaterialUtils.GetExistingMaterial("Raw Fish Spiny")
			});

			MaterialUtils.ApplyMaterial(appliance.Prefab, "Eye/SubMesh_0.002", new Material[] {
				MaterialUtils.GetExistingMaterial("Raw Fish Spiny")
			});

			MaterialUtils.ApplyMaterial(appliance.Prefab, "Fin/SubMesh_0.001", new Material[] {
				MaterialUtils.GetExistingMaterial("Raw Fish Spiny")
			});
		}
	}
}
