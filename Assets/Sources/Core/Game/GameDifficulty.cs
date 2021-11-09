using UnityEngine;

namespace PopBall.Core
{
    public class GameDifficulty : MonoBehaviour
    {
        [field: SerializeField] public float CurrentDifficulty { get; set; } = 1f;
        [field: SerializeField] public float DifficultyModifier { get; set; } = 1f;
        [field: SerializeField] public float MaxDifficulty { get; set; } = 20f;

        private void Update()
        {
            CurrentDifficulty = Mathf.Clamp(CurrentDifficulty + DifficultyModifier * Time.time * Time.deltaTime, 1f, MaxDifficulty);
        }
    }
}