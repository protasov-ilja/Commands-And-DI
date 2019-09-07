using Assets.Scripts.DebugVersions;
using Zenject;

namespace Assets.Scripts
{
	public class BindingsInstaller : MonoInstaller<BindingsInstaller>
	{
		public override void InstallBindings()
		{
			
			Container.Bind<Loader>().FromNewComponentOnNewGameObject().AsSingle().NonLazy();
#if DEBUG

			Container.Bind<IGameStateManager>().To<DebugGameStateManager>().AsSingle();
			Container.Bind<IGameStateCommandsExecutor>().To<DebugCommandsExecutor>().AsSingle();
			// To debug version work, add "DEBUG" in Player Settings -> Other Settings -> Scripting define symbols.
#else
			Container.Bind<IGameStateManager>().To<LocalGameStateManager>().AsSingle();
			Container.Bind<IGameStateCommandsExecutor>().To<GameStateCommandExecutor>().AsSingle();
#endif
		}
	}
}
