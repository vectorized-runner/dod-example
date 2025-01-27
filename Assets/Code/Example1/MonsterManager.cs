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

		private float _maxHealth;
		private float _maxStamina;
		
		public void GameLoop()
		{
			var dt = Time.deltaTime;
			var time = Time.time;
			
			for (int i = 0; i < _aliveMonsterCount; i++)
			{
				_aliveMonster.Health[i] = math.clamp(_aliveMonster.Health[i] + _aliveMonster.HealthRegen[i] * dt, 0, _maxHealth);
			}
			for (int i = 0; i < _aliveMonsterCount; i++)
			{
				_aliveMonster.Position[i] += _aliveMonster.Velocity[i] * dt;
			}
			for (int i = 0; i < _aliveMonsterCount; i++)
			{
				_aliveMonster.Stamina[i] = math.clamp(_aliveMonster.Stamina[i] + _aliveMonster.StaminaRegen[i] * dt, 0, _maxStamina);
			}
			for (int i = 0; i < _deadMonsterCount; i++)
			{
				if (time > _deadMonster.RespawnTime[i])
				{
					_deadMonster.IsAlive[i] = true;
				}
			}
			
			// ...
		}
	}
}