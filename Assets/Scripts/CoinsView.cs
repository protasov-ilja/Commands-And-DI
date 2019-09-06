using TMPro;
using UnityEngine;
using Zenject;

namespace Assets.Scripts
{
	public class CoinsView : MonoBehaviour
	{
		[SerializeField] private TextMeshProUGUI currencyText;

		private IGameStateCommandsExecutor _commandExecutor;

		[Inject]
		public void Init(IGameStateCommandsExecutor commandExecutor)
		{
			_commandExecutor = commandExecutor;
			_commandExecutor.StateUpdated += UpdateView;
		}

		public void AddCoins()
		{
			var cmd = new AddCoinsCommand(Random.Range(1, 100));
			_commandExecutor.Execute(cmd);
		}

		public void RemoveCoins()
		{
			var cmd = new AddCoinsCommand(-Random.Range(1, 100));
			_commandExecutor.Execute(cmd);
		}

		public void UpdateView(GameState gameState)
		{
			currencyText.text = $"Coins: { gameState.coins }";
		}

		private void OnDestroy()
		{
			_commandExecutor.StateUpdated -= UpdateView;
		}
	}
}
