using PopBall.Core.Pause;
using PopBall.Core.Pause.UI;
using UnityEngine;
using Zenject;

namespace PopBall.Core
{
    public class GameInstaller : MonoInstaller
    {
        [SerializeField] private GameDifficulty _gameDifficulty;

        [SerializeField] private PauseMenu _pauseMenu;

        public override void InstallBindings()
        {
            Container.Bind<GameDifficulty>()
                .FromInstance(_gameDifficulty)
                .AsSingle();

            Container.Bind(typeof(GamePause), typeof(System.IDisposable))
                .To<UnityPause>()
                .AsSingle();

            Container.Bind<PauseMenu>()
                .FromInstance(_pauseMenu)
                .AsSingle();
        }
    }
}

