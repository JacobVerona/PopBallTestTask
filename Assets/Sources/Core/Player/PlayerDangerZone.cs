using PopBall.Core.Balls;
using UnityEngine;
using Zenject;

namespace PopBall.Core.Player
{
    [RequireComponent(typeof(BoxCollider))]
    public class PlayerDangerZone : MonoBehaviour
    {
        private Player _playerHealth;

        [Inject]
        private void Constructor(Player playerHealth)
        {
            _playerHealth = playerHealth;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out Ball ball))
            {
                _playerHealth.ApplyDamage(ball.Damage);
                Destroy(ball.gameObject);
            }
        }
    }
}

