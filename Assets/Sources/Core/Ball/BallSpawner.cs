using PopBall.Core;
using PopBall.Core.Player;
using System.Collections;
using UnityEngine;
using Zenject;

namespace PopBall.Core.Balls
{
    public class BallSpawner : MonoBehaviour
    {
        [SerializeField] private Bounds _spawnArea;
        [SerializeField] private float _baseSpawnDelayInSeconds;

        [SerializeField] private IFactory<Ball> _ballFactory;

        private GameDifficulty _gameDifficulty;
        private PlayerScore _playerScore;

        [Inject]
        private void Constructor(IFactory<Ball> ballFactory, PlayerScore playerScore, GameDifficulty gameDifficulty)
        {
            _ballFactory = ballFactory;
            _playerScore = playerScore;
            _gameDifficulty = gameDifficulty;
        }

        private void OnEnable()
        {
            StartCoroutine(nameof(SpawnDelay));
        }

        private void OnDisable()
        {
            StopCoroutine(nameof(SpawnDelay));
        }

        public void Spawn()
        {
            var min = _spawnArea.min;
            var max = _spawnArea.max;

            var ball = _ballFactory.Create();
            ball.transform.position = transform.position + new Vector3(Random.Range(min.x, max.x),
                Random.Range(min.y, max.y), Random.Range(min.z, max.z));

            ball.Popped += OnPopped;
        }

        private void OnPopped(Ball ball)
        {
            ball.Popped -= OnPopped;
            _playerScore.CurrentScore += ball.Score;
        }

        private IEnumerator SpawnDelay()
        {
            while (true)
            {
                Spawn();
                yield return new WaitForSeconds(_baseSpawnDelayInSeconds / _gameDifficulty.CurrentDifficulty);
            }
        }

#if UNITY_EDITOR
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireCube(transform.position + _spawnArea.center, _spawnArea.size);
        }
#endif
    }
}