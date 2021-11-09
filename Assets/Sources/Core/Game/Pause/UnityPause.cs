using UnityEngine;

namespace PopBall.Core.Pause
{
    public class UnityPause : GamePause, System.IDisposable
    {
        protected override void OnEnabled()
        {
            Time.timeScale = 0;
        }

        protected override void OnDisabled()
        {
            Time.timeScale = 1;
        }

        public void Dispose()
        {
            OnDisabled();
        }
    }
}