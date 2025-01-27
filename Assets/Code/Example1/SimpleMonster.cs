using Unity.Mathematics;
using UnityEngine;

namespace Code
{
	public class SimpleMonster : Monster
	{
		public void UpdateRespawn()
		{
			if (Time.time > RespawnTime)
			{
				IsAlive = true;
			}
		}

		public void UpdateStamina()
		{
			Stamina = math.clamp(Stamina + StaminaRegen * Time.deltaTime, 0, MaxStamina);
		}

		public void UpdatePosition()
		{
			Position += Velocity * Time.deltaTime;
		}

		public void UpdateHealth()
		{
			Health = math.clamp(Health + HealthRegen * Time.deltaTime, 0, MaxHealth);
		}
	}
}