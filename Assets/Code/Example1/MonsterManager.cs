using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;
using UnityEngine;

namespace Code
{
	[BurstCompile]
	public struct HealthJob : IJobParallelFor
	{
		public NativeArray<float> Health;

		[ReadOnly]
		public NativeArray<float> HealthRegen;

		public float MaxHealth;
		public float Dt;

		public void Execute(int i)
		{
			Health[i] = math.clamp(Health[i] + HealthRegen[i] * Dt, 0, MaxHealth);
		}
	}

	[BurstCompile]
	public struct StaminaJob : IJobParallelFor
	{
		public NativeArray<float> Stamina;

		[ReadOnly]
		public NativeArray<float> StaminaRegen;

		public float MaxStamina;
		public float Dt;

		public void Execute(int i)
		{
			Stamina[i] = math.clamp(Stamina[i] + StaminaRegen[i] * Dt, 0, MaxStamina);
		}
	}

	[BurstCompile]
	public struct PositionJob : IJobParallelFor
	{
		public NativeArray<float2> Position;

		[ReadOnly]
		public NativeArray<float2> Velocity;

		public float Dt;

		public void Execute(int i)
		{
			Position[i] = Velocity[i] * Dt;
		}
	}

	[BurstCompile]
	public struct RespawnJob : IJobParallelFor
	{
		public NativeArray<bool> IsAlive;

		[ReadOnly]
		public NativeArray<float> RespawnTime;

		public float Time;

		public void Execute(int i)
		{
			if (Time > RespawnTime[i])
			{
				IsAlive[i] = true;
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
			}.Schedule(_aliveMonsterCount, 64);

			var positionJob = new PositionJob
			{
				Dt = dt,
				Position = _aliveMonster.Position,
				Velocity = _aliveMonster.Velocity
			}.Schedule(_aliveMonsterCount, 64);

			var staminaJob = new StaminaJob
			{
				Dt = dt,
				MaxStamina = _maxStamina,
				Stamina = _aliveMonster.Stamina,
				StaminaRegen = _aliveMonster.StaminaRegen,
			}.Schedule(_aliveMonsterCount, 64);

			var respawnJob = new RespawnJob
			{
				IsAlive = _aliveMonster.IsAlive,
				RespawnTime = _aliveMonster.RespawnTime,
				Time = time
			}.Schedule(_deadMonsterCount, 64);

			// ...
		}
	}
}