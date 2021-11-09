using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace PopBall.Core.Pause.UI
{
    public class PlayButton : MonoBehaviour
    {
        [SerializeField] private Button _play;
        private PauseMenu _pause;

        [Inject]
        private void Constructor(PauseMenu pause)
        {
            _pause = pause;
        }

        private void OnEnable()
        {
            _play.onClick.AddListener(OnPlay);
        }

        private void OnDisable()
        {
            _play.onClick.RemoveListener(OnPlay);
        }

        private void OnPlay()
        {
            _pause.gameObject.SetActive(false);
        }
    }
}

