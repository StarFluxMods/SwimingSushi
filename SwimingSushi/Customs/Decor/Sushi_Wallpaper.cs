using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KitchenLib.Customs;
using UnityEngine;
using KitchenData;

namespace SwimingSushi.Customs
{
	public class Sushi_Wallpaper : CustomDecor
	{
		public override string UniqueNameID => "Sushi_Wallpaper";
		public override Material Material => null;
		public override Appliance ApplicatorAppliance => null;
		public override LayoutMaterialType Type => LayoutMaterialType.Floor;
		public override bool IsAvailable => true;
	}
}
