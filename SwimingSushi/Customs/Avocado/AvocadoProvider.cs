using KitchenData;
using KitchenLib.Customs;
using KitchenLib.References;
using KitchenLib.Utils;
using System.Collections.Generic;
using UnityEngine;

namespace SwimingSushi.Customs
{
	public class AvocadoProvider : CustomAppliance
	{
		public override string UniqueNameID => "AvocadoProvider";
		public override int BaseGameDataObjectID => ApplianceReferences.SourceApple;
		public override GameObject Prefab => Main.bundle.LoadAsset<GameObject>("Provider - Avocado");

		public override string Name => "Avocados";
		public override List<IApplianceProperty> Properties => new List<IApplianceProperty>
		{
			KitchenPropertiesUtils.GetUnlimitedCItemProvider(GDOUtils.GetCustomGameDataObject<Avocado>().GameDataObject.ID)
		};

		public override void OnRegister(GameDataObject gameDataObject)
		{
			Appliance appliance = (Appliance)gameDataObject;
			MaterialUtils.ApplyMaterial(appliance.Prefab, "Avocado_Provider/Avocado/Mesh", new Material[] {
				MaterialUtils.GetExistingMaterial("Tree Dark"),
				MaterialUtils.GetExistingMaterial("Baked Apple")
			});
			MaterialUtils.ApplyMaterial(appliance.Prefab, "Avocado_Provider/Crate/Mesh", new Material[] {
				MaterialUtils.GetExistingMaterial("Wood - Default")
			});
		}
	}
}
