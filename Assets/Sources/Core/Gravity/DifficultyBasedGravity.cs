using UnityEngine;
using Zenject;

namespace PopBall.Core.Gravity
{
    [RequireComponent(typeof(Rigidbody))]
    public class DifficultyBasedGravity : MonoBehaviour
    {
        [SerializeField] private float _baseGravity;

        private GameDifficulty _gameDifficulty;

        private Vector3 _velocity;

        [Inject]
        private void Constuctor(GameDifficulty gameDifficulty)
        {
            _gameDifficulty = gameDifficulty;
        }

        private void Start()
        {
            _velocity = Vector3.down * _baseGravity * _gameDifficulty.CurrentDifficulty;
        }

        private void FixedUpdate()
        {
            transform.position += _velocity * Time.deltaTime;
        }
    }
}

