namespace Assets.Scripts
{
	public interface IGameStateManager
	{
		GameState GameState { get; set; }

		void Load();
		void Save();
	}
}
