using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace PopBall.Core.Pause.UI
{
    public class PauseButton : MonoBehaviour
    {
        [SerializeField] private Button _button;

        private PauseMenu _pause;

        [Inject]
        private void Constructor(PauseMenu pause)
        {
            _pause = pause;
        }

        private void OnEnable()
        {
            _button.onClick.AddListener(OnClick);
        }

        private void OnDisable()
        {
            _button.onClick.RemoveListener(OnClick);
        }

        private void OnClick()
        {
            _pause.gameObject.SetActive(true);
        }
    }
}

