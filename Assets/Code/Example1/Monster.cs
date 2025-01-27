using Unity.Mathematics;

namespace Code
{
	public abstract class Monster
	{
		public float2 Velocity { get; set; }
		public float Health { get; set; }
		public float HealthRegen { get; set; }
		public float MaxHealth { get; set; }
		public float Stamina { get; set; }
		public float StaminaRegen { get; set; }
		public float MaxStamina { get; set; }
		public int Target { get; set; }
		public float2 Position { get; set; }
		public bool IsAlive { get; set; }
		public float RespawnTime { get; set; }
	}
}