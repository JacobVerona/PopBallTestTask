using System;
using UnityEngine;

namespace PopBall.Core.Player
{
    public class Player : MonoBehaviour
    {
        public event Action<float> HealthChanged;
        public event Action Died;

        private float _health;

        [field: SerializeField] public float MaxHealth { get; set; }
        public bool IsDied { get; private set; }

        public float Health
        {
            get => _health;
            private set
            {
                _health = value;
                HealthChanged?.Invoke(_health);
            }
        }

        private void Awake()
        {
            _health = MaxHealth;   
        }

        public void ApplyDamage(float value)
        {
            if (IsDied)
                throw new InvalidOperationException("Player is died but you trying to damage it");

            Health -= value;

            if (Health <= 0)
            {
                Died?.Invoke();
                IsDied = true;
            }
        }
    }
}

