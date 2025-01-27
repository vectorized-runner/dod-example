using System;
using Unity.Mathematics;
using UnityEngine;

namespace Code
{
	public class Game
	{
		private MonsterDataArray _aliveMonster;
		private int _aliveMonsterCount;

		private MonsterDataArray _deadMonster;
		private int _deadMonsterCount;

		private DamagingMonsterArray _damagingMonster;
		private int _damagingMonsterCount;

		public void GameLoop()
		{
			for (int i = 0; i < _aliveMonsterCount; i++)
			{
				_aliveMonster.Health[i] = math.clamp(_aliveMonster.Health[i] + _aliveMonster.HealthRegen[i] * Time.deltaTime, 0, _aliveMonster.MaxHealth[i]);
			}
			for (int i = 0; i < _aliveMonsterCount; i++)
			{
				_aliveMonster.Position[i] += _aliveMonster.Velocity[i] * Time.deltaTime;
			}
			for (int i = 0; i < _aliveMonsterCount; i++)
			{
				_aliveMonster.Stamina[i] = math.clamp(_aliveMonster.Stamina[i] + _aliveMonster.StaminaRegen[i] * Time.deltaTime, 0, _aliveMonster.MaxStamina[i]);
			}
			for (int i = 0; i < _deadMonsterCount; i++)
			{
				if (Time.time > _deadMonster.RespawnTime[i])
				{
					_deadMonster.IsAlive[i] = true;
				}
			}
			
			// ...
		}
	}
}