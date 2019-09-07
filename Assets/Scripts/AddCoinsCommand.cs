using Newtonsoft.Json;

namespace Assets.Scripts
{
	public class AddCoinsCommand : IGameStateCommand
	{
		[JsonProperty("amount")]
		private int _amount;

		public AddCoinsCommand(int amount)
		{
			_amount = amount;
		}

		public void Execute(GameState gameState)
		{
			gameState.coins += _amount;
			if (gameState.coins < 0)
			{
				gameState.coins = 0;
			}
		}

		public override string ToString()
		{
			return $"{ GetType().ToString() } { _amount }";
		}
	}
}
