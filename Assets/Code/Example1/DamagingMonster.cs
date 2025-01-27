namespace Code
{
	public struct DamagingMonster
	{
		public MonsterData Data;
		public int Damage { get; set; }

		public void UpdateDamage()
		{
			// ... Damage the Player
		}
	}
}