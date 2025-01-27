namespace Code
{
	public class DamagingMonster : SimpleMonster
	{
		public int Damage { get; set; }
		
		public void DamaingMonsterUpdate()
		{
			UpdateDamage();
			SimpleMonsterUpdate();
		}

		private void UpdateDamage()
		{
			// ... Damage the Player
		}
	}
}