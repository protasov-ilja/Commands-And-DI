using System.IO;
using UnityEngine;

namespace Assets.Scripts
{
	public class LocalGameStateManager : IGameStateManager
	{
		private static readonly string GameStatePath = Path.Combine(Application.persistentDataPath, "gameState.json");

		public GameState GameState { get; set; }

		public void Load()
		{
			Debug.Log("Runing");
			if (!File.Exists(GameStatePath))
			{
				Debug.Log("Exiting");
				return;
			}

			GameState = JsonUtility.FromJson<GameState>(File.ReadAllText(GameStatePath));
			if (GameState == null)
			{
				GameState = new GameState();
			}
		}

		public void Save()
		{
			File.WriteAllText(GameStatePath, JsonUtility.ToJson(GameState));
		}
	}
}
