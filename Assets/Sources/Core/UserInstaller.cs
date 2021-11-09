using Zenject;


namespace PopBall.Core.Player
{
    public class UserInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<UserInput>()
                .FromNewComponentOn(gameObject)
                .AsSingle();
        }
    }
}
