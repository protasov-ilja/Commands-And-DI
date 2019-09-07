using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace Assets.Scripts.DebugVersions
{
	public class DebugCommandsExecutor : GameStateCommandExecutor
	{
		public class CommandsHistory
		{
			public List<IGameStateCommand> commands;
		}

		private List<IGameStateCommand> _commands = new List<IGameStateCommand>();

		private readonly DebugGameStateManager _debugGameStateManager;
		private readonly JsonSerializerSettings _jsonSettings = new JsonSerializerSettings()
		{
			TypeNameHandling = TypeNameHandling.All
		};

		public IList<IGameStateCommand> History => _commands;

		public DebugCommandsExecutor(IGameStateManager gameStateManager)
			: base(gameStateManager)
		{
			_debugGameStateManager = (DebugGameStateManager)gameStateManager;
		}

		public void SaveReplay(string name)
		{
			_debugGameStateManager.SaveBackupAs(name);
			File.WriteAllText(GetReplayFile(name),
							JsonConvert.SerializeObject(new CommandsHistory { commands = _commands },
														_jsonSettings));
		}

		public void LoadReplay(string name)
		{
			_debugGameStateManager.RestoreBackupState(name);
			_commands = JsonConvert.DeserializeObject<CommandsHistory>(
				File.ReadAllText(GetReplayFile(name)), _jsonSettings).commands;

			_StateUpdated(_gameStateManager.GameState);
		}
		
		public void Replay(string name, int toIndex)
		{
			_debugGameStateManager.RestoreBackupState(name);
			LoadReplay(name);

			var history = _commands;
			_commands = new List<IGameStateCommand>();
			for (var i = 0; i < Math.Min(toIndex, history.Count); ++i)
			{
				Execute(history[i]);
			}

			_commands = history;
		}

		private string GetReplayFile(string name)
		{
			return Path.Combine(Application.persistentDataPath, $"{ name }_commands.json");
		}

		public override void Execute(IGameStateCommand command)
		{
			_commands.Add(command);

			base.Execute(command);
		}
	}
}
