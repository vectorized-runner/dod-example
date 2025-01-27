namespace Code
{
	public class Game
	{
		private Monster[] _monsters;

		public void GameLoop()
		{
			foreach (var monster in _monsters)
			{
				monster.Update();
			}
		}
	}
}