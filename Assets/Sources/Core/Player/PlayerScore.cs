using System;
using UnityEngine;

namespace PopBall.Core.Player
{
    public class PlayerScore : MonoBehaviour
    {
        public const string BestScoreKey = "BestScore";

        public event Action<float> ScoreChanged;
        public event Action<float> BestScoreChanged;

        private float _score;
        private float _bestScore;

        public float BestScore
        {
            get => _bestScore;
            set
            {
                _bestScore = value;
                BestScoreChanged?.Invoke(_bestScore);
            }
        }

        public float CurrentScore
        {
            get => _score;
            set
            {
                _score = value;
                if (BestScore < _score)
                {
                    BestScore = _score;
                }
                ScoreChanged?.Invoke(_score);
            }
        }

        private void Awake()
        {
            BestScore = PlayerPrefs.GetFloat(BestScoreKey);
        }

        private void OnDestroy()
        {
            PlayerPrefs.SetFloat(BestScoreKey, BestScore);
        }
    }
}

