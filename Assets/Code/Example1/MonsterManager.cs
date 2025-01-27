namespace Code
{
	public class Game
	{
		private SimpleMonster[] _simpleMonsters;
		private DamagingMonster[] _damagingMonsters;
		
		public void GameLoop()
		{
			foreach (var monster in _simpleMonsters)
			{
				monster.SimpleMonsterUpdate();
			}
			foreach (var monster in _damagingMonsters)
			{
				monster.DamaingMonsterUpdate();
			}
		}
	}
}