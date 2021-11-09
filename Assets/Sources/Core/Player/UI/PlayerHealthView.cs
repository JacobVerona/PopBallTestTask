using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace PopBall.Core.Player.UI
{
    public class PlayerHealthView : MonoBehaviour
    {
        [SerializeField] private Image _healthIcon;
        private Player _playerHealth;

        [Inject]
        private void Constructor(Player playerHealth)
        {
            _playerHealth = playerHealth;
        }

        private void OnEnable()
        {
            _playerHealth.HealthChanged += OnHealthChanged;
        }

        private void OnDisable()
        {
            _playerHealth.HealthChanged -= OnHealthChanged;
        }

        private void OnHealthChanged(float health)
        {
            _healthIcon.fillAmount = health/_playerHealth.MaxHealth;
        }
    }
}

