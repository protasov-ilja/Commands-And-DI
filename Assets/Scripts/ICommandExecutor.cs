using System;

namespace Assets.Scripts
{
	public interface ICommandExecutor<TState, TCommand> where TCommand : ICommand
	{
		event Action<TState> StateUpdated;
		void Execute(TCommand command);
	}

	public interface IGameStateCommandsExecutor : ICommandExecutor<GameState, IGameStateCommand>
	{

	}
}
