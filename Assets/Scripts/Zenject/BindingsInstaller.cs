using Zenject;

namespace Assets.Scripts
{
	public class BindingsInstaller : MonoInstaller<BindingsInstaller>
	{
		public override void InstallBindings()
		{
			Container.Bind<IGameStateManager>().To<LocalGameStateManager>().AsSingle();
			Container.Bind<Loader>().FromNewComponentOnNewGameObject().AsSingle().NonLazy();
			Container.Bind<IGameStateCommandsExecutor>().To<GameStateCommandExecutor>().AsSingle();
		}
	}
}
