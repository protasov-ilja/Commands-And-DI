using UnityEngine;
using Zenject;

namespace Assets.Scripts
{
	public class Loader : MonoBehaviour
	{
		private IGameStateManager _gameStateManager;

		[Inject]
		public void Init(IGameStateManager gameStateManager)
		{
			_gameStateManager = gameStateManager;
		}

		private void Awake()
		{
			Debug.Log("Laoding started");
			_gameStateManager.Load();
		}

		private void OnApplicationQuit()
		{
			Debug.Log("Quitting application");
			_gameStateManager.Save();
		}
	}
}
