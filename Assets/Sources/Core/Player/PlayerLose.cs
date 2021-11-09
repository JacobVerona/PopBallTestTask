using PopBall.Core.Player.UI;
using UnityEngine;
using Zenject;

namespace PopBall.Core.Player
{
    public class PlayerLose : MonoBehaviour
    {
        private Player _player;
        private PlayerLoseMenu _loseMenu;

        [Inject]
        private void Constructor(Player player, PlayerLoseMenu loseMenu)
        {
            _player = player;
            _loseMenu = loseMenu;
        }

        private void OnEnable()
        {
            _player.Died += OnDied;
        }

        private void OnDisable()
        {
            _player.Died -= OnDied;
        }

        private void OnDied()
        {
            _loseMenu.gameObject.SetActive(true);
        }
    }
}

