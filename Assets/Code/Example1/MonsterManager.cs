using Unity.Burst;
using Unity.Burst.Intrinsics;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Jobs;
using Unity.Mathematics;
using UnityEngine;
using static Unity.Burst.Intrinsics.X86.Sse;

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
	public unsafe struct PositionJob : IJob
	{
		// public NativeArray<float3> Position;
		public NativeArray<float> PositionXs;
		public NativeArray<float> PositionYs;
		public NativeArray<float> PositionZs;

		// public NativeArray<float3> Velocity;
		[ReadOnly]
		public NativeArray<float> VelocityXs;
		[ReadOnly]
		public NativeArray<float> VelocityYs;
		[ReadOnly]
		public NativeArray<float> VelocityZs;

		public float Dt;

		public void Execute()
		{
			var count = PositionXs.Length / 4;
			
			for (int i = 0; i < count; i += 4)
			{
		       // public static float3 operator * (float lhs, float3 rhs)
		       // { return new float3 (lhs * rhs.x, lhs * rhs.y, lhs * rhs.z); }
		       
		       // public static float3 operator + (float3 lhs, float3 rhs)
		       // { return new float3 (lhs.x + rhs.x, lhs.y + rhs.y, lhs.z + rhs.z); }
		       
		        // Original method
				// Position[i] = Position[i] + Velocity[i] * Dt;

				
				// var pos = Position[i];
				v128 posXs = load_ps((float*)PositionXs.GetUnsafePtr() + i);
				v128 posYs = load_ps((float*)PositionYs.GetUnsafePtr() + i);
				v128 posZs = load_ps((float*)PositionZs.GetUnsafePtr() + i);

				// var vel = Velocity[i];
				v128 velXs = load_ps((float*)VelocityXs.GetUnsafePtr() + i);
				v128 velYs = load_ps((float*)VelocityYs.GetUnsafePtr() + i);
				v128 velZs = load_ps((float*)VelocityZs.GetUnsafePtr() + i);

				// var dt = Dt;
				v128 vdt = new v128(Dt);
				
				// var newPosX = pos.x + vel.x * dt;
				// var newPosY = pos.y + vel.y * dt;
				// var newPosZ = pos.z + vel.z * dt;
				var newPosXs = add_ps(posXs, mul_ps(velXs, vdt));
				var newPosYs = add_ps(posYs, mul_ps(velYs, vdt));
				var newPosZs = add_ps(posZs, mul_ps(velZs, vdt));

				// Position[i] = newPos;
				store_ps((float*)PositionXs.GetUnsafePtr() + i, newPosXs);
				store_ps((float*)PositionYs.GetUnsafePtr() + i, newPosYs);
				store_ps((float*)PositionZs.GetUnsafePtr() + i, newPosZs);
			}
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
			}.Schedule();

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