namespace Code
{
	public class DamagingMonster : SimpleMonster
	{
		public int Damage { get; set; }
		
		public override void Update()
		{
			UpdateDamage();
			base.Update();
		}

		private void UpdateDamage()
		{
			// ... Damage the Player
		}
	}
}