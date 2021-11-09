using TMPro;
using UnityEngine;
using Zenject;

namespace PopBall.Core.Player.UI
{
    public class PlayerScoreView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _scoreView;
        [SerializeField] private TMP_Text _bestScoreView;

        private PlayerScore _playerScore;

        [Inject]
        private void Constructor(PlayerScore playerScore)
        {
            _playerScore = playerScore;
        }

        private void Start()
        {
            OnScoreChanged(_playerScore.CurrentScore);
            OnBestScoreChanged(_playerScore.BestScore);
        }

        private void OnEnable()
        {
            _playerScore.ScoreChanged += OnScoreChanged;
            _playerScore.BestScoreChanged += OnBestScoreChanged;
        }

        private void OnDisable()
        {
            _playerScore.ScoreChanged -= OnScoreChanged;
            _playerScore.BestScoreChanged -= OnBestScoreChanged;
        }

        private void OnScoreChanged(float score)
        {
            _scoreView.text = score.ToString();
        }

        private void OnBestScoreChanged(float bestScore)
        {
            _bestScoreView.text = bestScore.ToString();
        }
    }
}

