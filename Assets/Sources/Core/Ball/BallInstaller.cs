using UnityEngine;
using Zenject;

namespace PopBall.Core.Balls
{
    public class BallInstaller : MonoInstaller
    {
        [SerializeField] private BallsContainer _ballsContainer;
        [SerializeField] private BallSpawner _ballSpawnerInstance;

        public override void InstallBindings()
        {
            Container.Bind<BallsContainer>()
                .FromInstance(_ballsContainer)
                .AsSingle();

            Container.Bind<IFactory<Ball>>()
                .To<Ball.BallFactory>()
                .AsSingle();

            Container.Bind<BallSpawner>()
                .FromInstance(_ballSpawnerInstance)
                .AsSingle();
        }
    }
}