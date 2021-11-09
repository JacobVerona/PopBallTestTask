using UnityEngine;
using Zenject;

namespace PopBall.Core.Balls
{
    public class Ball : MonoBehaviour
    {
        public event System.Action<Ball> Popped;

        [SerializeField] private Renderer _renderer;    

        [SerializeField] private ParticleSystem _destroyParticlesPrefab;

        [SerializeField] private Color _ballColor;

        [field: SerializeField] public float Damage { get; private set; }
        [field: SerializeField] public float Score { get; private set; }

        private void Awake()
        {
            _renderer.material.color = _ballColor;
        }

        public void Pop()
        {
            Popped?.Invoke(this);
            CreatePoppingParticles();
            Destroy(gameObject);
        }

        private void CreatePoppingParticles()
        {
            var particles = Instantiate(_destroyParticlesPrefab, transform.position, Quaternion.identity);
            var mainModule = particles.main;
            mainModule.startColor = _ballColor;
            particles.Play();
        }

        public class BallFactory : IFactory<Ball>
        {
            private DiContainer _container;
            private BallsContainer _ballsContainer;

            [Inject]
            public BallFactory(DiContainer container, BallsContainer ballsContainer)
            {
                _container = container;
                _ballsContainer = ballsContainer;
            }

            public Ball Create()
            {
                return _container.InstantiatePrefab(_ballsContainer.GetRandomPrefab())
                    .GetComponent<Ball>();
            }
        }
    }
}