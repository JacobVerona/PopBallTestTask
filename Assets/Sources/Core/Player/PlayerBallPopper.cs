using PopBall.Core.Balls;
using UnityEngine;
using Zenject;

namespace PopBall.Core.Player
{
    public class PlayerBallPopper : MonoBehaviour
    {
        private UserInput _input;

        [Inject]
        private void Constructor(UserInput input)
        {
            _input = input;
        }

        private void OnEnable()
        {
            _input.MouseClicked += OnMouseClicked;
        }

        private void OnDisable()
        {
            _input.MouseClicked -= OnMouseClicked;
        }

        private void OnMouseClicked(Vector2 mousePos)
        {
            var ray = Camera.main.ScreenPointToRay(mousePos);
            if (Physics.Raycast(ray, out RaycastHit hit, 100f))
            {
                if (hit.collider.TryGetComponent(out Ball ball))
                {
                    ball.Pop();
                }
            }
        }
    }
}

