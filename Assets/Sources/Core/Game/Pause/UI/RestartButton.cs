using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace PopBall.Core.Pause.UI
{
    public class RestartButton : MonoBehaviour
    {
        [SerializeField] private Button _targetButton;

        private void OnEnable()
        {
            _targetButton.onClick.AddListener(OnRestart);
        }

        private void OnDisable()
        {
            _targetButton.onClick.RemoveListener(OnRestart);
        }

        private void OnRestart()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
