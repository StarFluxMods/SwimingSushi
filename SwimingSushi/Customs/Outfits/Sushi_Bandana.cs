using System.Collections.Generic;
using Kitchen;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using UnityEngine;

namespace SwimingSushi.Customs
{
	public class Sushi_Bandana : CustomPlayerCosmetic
	{
		public override string UniqueNameID => "Sushi_Bandana";
		public override bool BlockHats => true;
		public override CosmeticType CosmeticType => CosmeticType.Hat;
		public override bool DisableInGame => false;
		public override bool IsDefault => false;
		public override List<(Locale, CosmeticInfo)> InfoList => new List<(Locale, CosmeticInfo)>
		{
			(Locale.English, new CosmeticInfo
			{
				Name = "Sushi Bandana",
				Description = "Allows you to be a real Sushi Chef!"
			})
		};
		public override GameObject Visual => Main.bundle.LoadAsset<GameObject>("Sushi_Bandana");


		public override void OnRegister(GameDataObject gameDataObject)
		{
			GameObject Prefab = ((PlayerCosmetic)gameDataObject).Visual;

			PlayerOutfitComponent playerOutfitComponent = Prefab.AddComponent<PlayerOutfitComponent>();
			playerOutfitComponent.Renderers.Add(GameObjectUtils.GetChildObject(Prefab, "Sushi_Bandana/SubMesh_0").GetComponent<SkinnedMeshRenderer>());
		}
	}
}