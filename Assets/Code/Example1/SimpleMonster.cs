using Unity.Mathematics;
using UnityEngine;

namespace Code
{
	public struct SimpleMonster
	{
		public MonsterData Data;
		
		public void UpdateRespawn()
		{
			if (Time.time > Data.RespawnTime)
			{
				Data.IsAlive = true;
			}
		}

		public void UpdateStamina()
		{
			Data.Stamina = math.clamp(Data.Stamina + Data.StaminaRegen * Time.deltaTime, 0, Data.MaxStamina);
		}

		public void UpdatePosition()
		{
			Data.Position += Data.Velocity * Time.deltaTime;
		}

		public void UpdateHealth()
		{
			Data.Health = math.clamp(Data.Health + Data.HealthRegen * Time.deltaTime, 0, Data.MaxHealth);
		}
	}
}