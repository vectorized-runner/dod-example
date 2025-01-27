using System;

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
			foreach (ref var monster in _aliveSimpleMonsters.AsSpan())
			{
				monster.UpdateHealth();
			}
			foreach (ref var monster in _aliveSimpleMonsters.AsSpan())
			{
				monster.UpdatePosition();
			}
			foreach (ref var monster in _aliveSimpleMonsters.AsSpan())
			{
				monster.UpdateStamina();
			}
			foreach (ref var monster in _deadSimpleMonsters.AsSpan())
			{
				monster.UpdateRespawn();
			}
			
			// 
			
			foreach (ref var monster in _aliveDamagingMonsters.AsSpan())
			{
				monster.SimpleMonster.UpdateHealth();
			}
			foreach (ref var monster in _aliveDamagingMonsters.AsSpan())
			{
				monster.SimpleMonster.UpdatePosition();
			}
			foreach (ref var monster in _aliveDamagingMonsters.AsSpan())
			{
				monster.SimpleMonster.UpdateStamina();
			}
			foreach (ref var monster in _aliveDamagingMonsters.AsSpan())
			{
				monster.UpdateDamage();
			}
			foreach (ref var monster in _deadDamagingMonsters.AsSpan())
			{
				monster.SimpleMonster.UpdateRespawn();
			}
		}
	}
}