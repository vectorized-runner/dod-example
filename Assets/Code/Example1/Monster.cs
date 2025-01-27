using Unity.Mathematics;

namespace Code
{
	public struct MonsterDataArray
	{
		public float2[] Velocity;
		public float[] Health;
		public float[] HealthRegen;
		public float[] Stamina;
		public float[] StaminaRegen;
		public int[] Target;
		public float2[] Position;
		public float[] RespawnTime;
		public bool[] IsAlive;
	}
}