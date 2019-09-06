using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts
{
	public class AddCoinsCommand : IGameStateCommand
	{
		private int _amount;

		public AddCoinsCommand(int amount)
		{
			_amount = amount;
		}

		public void Execute(GameState gameState)
		{
			gameState.coins += _amount;
		}
	}
}
