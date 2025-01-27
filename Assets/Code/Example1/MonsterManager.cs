using System;
using Unity.Mathematics;
using UnityEngine;

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
				monster.Data.Health = math.clamp(monster.Data.Health + monster.Data.HealthRegen * Time.deltaTime, 0, monster.Data.MaxHealth);
			}
			foreach (ref var monster in _aliveSimpleMonsters.AsSpan())
			{
				monster.Data.Position += monster.Data.Velocity * Time.deltaTime;
			}
			foreach (ref var monster in _aliveSimpleMonsters.AsSpan())
			{
				monster.Data.Stamina = math.clamp(monster.Data.Stamina + monster.Data.StaminaRegen * Time.deltaTime, 0, monster.Data.MaxStamina);
			}
			foreach (ref var monster in _deadSimpleMonsters.AsSpan())
			{
				if (Time.time > monster.Data.RespawnTime)
				{
					monster.Data.IsAlive = true;
				}
			}
			
			// 
			
			foreach (ref var monster in _aliveDamagingMonsters.AsSpan())
			{
				monster.Data.Health = math.clamp(monster.Data.Health + monster.Data.HealthRegen * Time.deltaTime, 0, monster.Data.MaxHealth);
			}
			foreach (ref var monster in _aliveDamagingMonsters.AsSpan())
			{
				monster.Data.Position += monster.Data.Velocity * Time.deltaTime;
			}
			foreach (ref var monster in _aliveDamagingMonsters.AsSpan())
			{
				monster.Data.Stamina = math.clamp(monster.Data.Stamina + monster.Data.StaminaRegen * Time.deltaTime, 0, monster.Data.MaxStamina);
			}
			foreach (ref var monster in _aliveDamagingMonsters.AsSpan())
			{
				monster.UpdateDamage();
			}
			foreach (ref var monster in _deadDamagingMonsters.AsSpan())
			{
				if (Time.time > monster.Data.RespawnTime)
				{
					monster.Data.IsAlive = true;
				}
			}
		}
	}
}