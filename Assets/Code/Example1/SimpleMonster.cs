using Unity.Mathematics;
using UnityEngine;

namespace Code
{
	public class SimpleMonster : Monster
	{
		public void SimpleMonsterUpdate()
		{
			if (IsAlive)
			{
				UpdateHealth();
				UpdatePosition();
				UpdateStamina();
			}
			else
			{
				UpdateRespawn();
			}
		}

		private void UpdateRespawn()
		{
			if (Time.time > RespawnTime)
			{
				IsAlive = true;
			}
		}

		private void UpdateStamina()
		{
			Stamina = math.clamp(Stamina + StaminaRegen * Time.deltaTime, 0, MaxStamina);
		}

		private void UpdatePosition()
		{
			Position += Velocity * Time.deltaTime;
		}

		private void UpdateHealth()
		{
			Health = math.clamp(Health + HealthRegen * Time.deltaTime, 0, MaxHealth);
		}
	}
}