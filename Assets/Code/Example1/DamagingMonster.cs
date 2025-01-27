namespace Code
{
	public struct DamagingMonster
	{
		public SimpleMonster SimpleMonster;
		public int Damage { get; set; }

		public void UpdateDamage()
		{
			// ... Damage the Player
		}
	}
}