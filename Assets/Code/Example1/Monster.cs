using Unity.Collections;
using Unity.Mathematics;

namespace Code
{
	public struct MonsterDataArray
	{
		public NativeArray<float2> Velocity;
		public NativeArray<float> Health;
		public NativeArray<float> HealthRegen;
		public NativeArray<float> Stamina;
		public NativeArray<float> StaminaRegen;
		public NativeArray<int> Target;
		public NativeArray<float2> Position;
		public NativeArray<float> RespawnTime;
		public NativeArray<bool> IsAlive;
	}
}