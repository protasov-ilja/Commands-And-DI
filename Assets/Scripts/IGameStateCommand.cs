namespace Assets.Scripts
{
	public interface IGameStateCommand : ICommand
	{
		void Execute(GameState gameState);
	}
}
