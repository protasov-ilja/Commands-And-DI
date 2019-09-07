using System;

namespace Assets.Scripts
{
	public class GameStateCommandExecutor : IGameStateCommandsExecutor
	{
		protected readonly IGameStateManager _gameStateManager;

		protected Action<GameState> _StateUpdated;

		public event Action<GameState> StateUpdated
		{
			add
			{
				_StateUpdated += value;
				value?.Invoke(_gameStateManager.GameState);
			}

			remove
			{
				_StateUpdated -= value;
			}
		}

		public GameStateCommandExecutor(IGameStateManager gameStateManger)
		{
			_gameStateManager = gameStateManger;
		}

		public virtual void Execute(IGameStateCommand command)
		{
			command.Execute(_gameStateManager.GameState);
			_StateUpdated?.Invoke(_gameStateManager.GameState);
		}
	}
}
