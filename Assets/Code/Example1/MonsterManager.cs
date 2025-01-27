namespace Code
{
	public class Game
	{
		private SimpleMonster[] _aliveSimpleMonsters;
		private SimpleMonster[] _deadSimpleMonsters;
		private DamagingMonster[] _aliveDamagingMonsters;
		private DamagingMonster[] _deadDamagingMonsters;

		public void GameLoop()
		{
			foreach (var monster in _aliveSimpleMonsters)
			{
				monster.SimpleMonsterUpdateAlive();
			}

			foreach (var monster in _deadSimpleMonsters)
			{
				monster.SimpleMonsterUpdateDead();
			}

			foreach (var monster in _aliveDamagingMonsters)
			{
				monster.DamagingMonsterUpdateAlive();
			}

			foreach (var monster in _deadDamagingMonsters)
			{
				monster.DamagingMonsterUpdateDead();
			}
		}
	}
}