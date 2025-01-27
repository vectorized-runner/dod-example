using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;
using UnityEngine;

namespace Code
{
	[BurstCompile]
	public struct HealthJob : IJob
	{
		public NativeArray<float> Health;
		
		[ReadOnly]
		public NativeArray<float> HealthRegen;
		
		public float MaxHealth;
		public float Dt;
		
		public void Execute()
		{
			for (int i = 0; i < Health.Length; i++)
			{
				Health[i] = math.clamp(Health[i] + HealthRegen[i] * Dt, 0, MaxHealth);
			}
		}
	}
	
	[BurstCompile]
	public struct StaminaJob : IJob
	{
		public NativeArray<float> Stamina;
		
		[ReadOnly]
		public NativeArray<float> StaminaRegen;
		
		public float MaxStamina;
		public float Dt;
		
		public void Execute()
		{
			for (int i = 0; i < Stamina.Length; i++)
			{
				Stamina[i] = math.clamp(Stamina[i] + StaminaRegen[i] * Dt, 0, MaxStamina);
			}
		}
	}

	[BurstCompile]
	public struct PositionJob : IJob
	{
		public NativeArray<bool> IsAlive;

		[ReadOnly]
		public NativeArray<float> RespawnTime;
		
		public float Time;
		
		public void Execute()
		{
			for (int i = 0; i < IsAlive.Length; i++)
			{
				if (Time > RespawnTime[i])
				{
					IsAlive[i] = true;
				}
			}
		}
	}
	
	[BurstCompile]
	public struct RespawnJob : IJob
	{
		public NativeArray<bool> IsAlive;

		[ReadOnly]
		public NativeArray<float> RespawnTime;
		
		public float Time;
		
		public void Execute()
		{
			for (int i = 0; i < IsAlive.Length; i++)
			{
				if (Time > RespawnTime[i])
				{
					IsAlive[i] = true;
				}
			}
		}
	}
	
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

			var healthJob = new HealthJob
			{
				Dt = dt,
				MaxHealth = _maxHealth,
				Health = _aliveMonster.Health,
				HealthRegen = _aliveMonster.HealthRegen,
			}.Schedule();

			var positionJob = new PositionJob
			{
				Time = time,
				IsAlive = _aliveMonster.IsAlive,
				RespawnTime = _aliveMonster.RespawnTime
			}.Schedule();

			var staminaJob = new StaminaJob
			{
				Dt = dt,
				MaxStamina = _maxStamina,
				Stamina = _aliveMonster.Stamina,
				StaminaRegen = _aliveMonster.StaminaRegen,
			}.Schedule();

			var respawnJob = new RespawnJob
			{
				IsAlive = _aliveMonster.IsAlive,
				RespawnTime = _aliveMonster.RespawnTime,
				Time = time
			};
			
			// ...
		}
	}
}