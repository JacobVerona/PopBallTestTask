using UnityEngine;
using Zenject;

namespace PopBall.Core.Pause.UI
{
    public class PauseMenu : MonoBehaviour
    {
        private GamePause _pause;

        [Inject]
        private void Constructor(GamePause pause)
        {
            _pause = pause;
        }

        private void OnEnable()
        {
            _pause.Enable();
        }

        private void OnDisable()
        {
            _pause.Disable();
        }
    }
}

