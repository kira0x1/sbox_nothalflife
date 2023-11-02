using Sandbox;

namespace MyGame
{
	public partial class Smg : Weapon
	{
		public override string ModelPath => "weapons/rust_smg/rust_smg.vmdl";
		public override string ViewModelPath => "weapons/rust_smg/v_rust_smg.vmdl";

		public override float PrimaryRate => 15.0f;

		public override int MagazineSize => 40;

		public override int MaxHeldAmmo => 260;

		[ClientRpc]
		protected virtual void ShootEffects()
		{
			Game.AssertClient();

			Particles.Create( "particles/pistol_muzzleflash.vpcf", EffectEntity, "muzzle" );

			Pawn.SetAnimParameter( "b_attack", true );
			ViewModelEntity?.SetAnimParameter( "fire", true );
		}

		public override void PrimaryAttack()
		{
			ShootEffects();
			Pawn.PlaySound( "rust_smg.shoot" );
			ShootBullet( 0.2f, 170, 45, 1.5f );
		}

		protected override void Animate()
		{
			Pawn.SetAnimParameter( "holdtype", (int)CitizenAnimationHelper.HoldTypes.Rifle );
		}
	}
}
