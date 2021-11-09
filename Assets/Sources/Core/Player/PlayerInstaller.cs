using PopBall.Core.Player.UI;
using UnityEngine;
using Zenject;

namespace PopBall.Core.Player
{
    public class PlayerInstaller : MonoInstaller
    {
        [SerializeField] private PlayerLoseMenu _playerLoseMenu;
        [SerializeField] private Player _player;
        [SerializeField] private PlayerScore _playerScore;
        [SerializeField] private PlayerDangerZone _playerDangerousZone;

        public override void InstallBindings()
        {
            Container.Bind<Player>()
                .FromInstance(_player)
                .AsSingle();

            Container.Bind<PlayerScore>()
                .FromInstance(_playerScore)
                .AsSingle();

            Container.Bind<PlayerDangerZone>()
                .FromInstance(_playerDangerousZone)
                .AsSingle();

            Container.Bind<PlayerLoseMenu>()
                .FromInstance(_playerLoseMenu)
                .AsSingle();
        }
    }
}
