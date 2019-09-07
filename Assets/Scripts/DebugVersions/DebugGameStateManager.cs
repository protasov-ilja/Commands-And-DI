using System.IO;
using UnityEngine;

namespace Assets.Scripts.DebugVersions
{
	public class DebugGameStateManager : LocalGameStateManager
	{
		private static readonly string BackupGameStatePath = 
			Path.Combine(Application.persistentDataPath, "gameStateBackup.json");

		public override void Load()
		{
			base.Load();

			File.WriteAllText(BackupGameStatePath, JsonUtility.ToJson(GameState));
		}

		public void SaveBackupAs(string name)
		{
			File.Copy(
				Path.Combine(Application.persistentDataPath, "gameStateBackup.json"),
				Path.Combine(Application.persistentDataPath, $"{ name }.json"), true);
		}

		public void RestoreBackupState(string name)
		{
			var path = Path.Combine(Application.persistentDataPath, $"{ name }.json");
			Debug.Log($"Restoring state from { path }");

			GameState = JsonUtility.FromJson<GameState>(File.ReadAllText(path));
		}
	}
}
