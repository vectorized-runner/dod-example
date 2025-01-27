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
				monster.UpdateHealth();
			}
			foreach (var monster in _aliveSimpleMonsters)
			{
				monster.UpdatePosition();
			}
			foreach (var monster in _aliveSimpleMonsters)
			{
				monster.UpdateStamina();
			}
			foreach (var monster in _deadSimpleMonsters)
			{
				monster.UpdateRespawn();
			}
			
			// 
			
			foreach (var monster in _aliveDamagingMonsters)
			{
				monster.UpdateHealth();
			}
			foreach (var monster in _aliveDamagingMonsters)
			{
				monster.UpdatePosition();
			}
			foreach (var monster in _aliveDamagingMonsters)
			{
				monster.UpdateStamina();
			}
			foreach (var monster in _aliveDamagingMonsters)
			{
				monster.UpdateDamage();
			}
			foreach (var monster in _deadDamagingMonsters)
			{
				monster.UpdateRespawn();
			}
		}
	}
}