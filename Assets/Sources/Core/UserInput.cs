using PopBall.Core;
using PopBall.Core.Pause;
using UnityEngine;
using Zenject;

namespace PopBall.Core
{
    public class UserInput : MonoBehaviour
    {
        public event System.Action<Vector2> MouseClicked;

        private GamePause _pause;

        [Inject]
        private void Constructor(GamePause pause)
        {
            _pause = pause;
        }

        private void Update()
        {
            if (_pause.IsEnabled) return;

            if (Input.GetMouseButtonDown(0))
            {
                MouseClicked?.Invoke(Input.mousePosition);
            }
        }
    }
}
