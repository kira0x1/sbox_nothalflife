using Sandbox;
using Sandbox.UI;
using Sandbox.UI.Construct;

namespace MyGame
{
	partial class GunHud : Panel
	{
		public int CurAmmo;
		public int MagazineSize;
		public int HeldAmmoLeft;


		public override void Tick()
		{
			if ( !Game.IsClient ) return;
			Pawn player = (Pawn)Game.LocalPawn;
			Weapon activeWeapon = player.ActiveWeapon;
			CurAmmo = activeWeapon.CurrentAmmo;
			MagazineSize = activeWeapon.MagazineSize;
			HeldAmmoLeft = activeWeapon.HeldAmmoLeft;
			StateHasChanged();
		}
	}
}
