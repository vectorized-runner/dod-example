namespace Code
{
	public class DamagingMonster : SimpleMonster
	{
		public int Damage { get; set; }

		public void DamagingMonsterUpdateAlive()
		{
			UpdateDamage();
			SimpleMonsterUpdateAlive();
		}

		public void DamagingMonsterUpdateDead()
		{
			UpdateRespawn();
		}

		private void UpdateDamage()
		{
			// ... Damage the Player
		}
	}
}