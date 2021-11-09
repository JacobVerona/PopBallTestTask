using System;

namespace PopBall.Core.Pause
{
    public class GamePause
    {
        public event Action Enabled;
        public event Action Disabled;

        public bool IsEnabled { get; private set; }

        public void Enable()
        {
            IsEnabled = true;
            OnEnabled();
            Enabled?.Invoke();
        }

        public void Disable()
        {
            IsEnabled = false;
            OnDisabled();
            Disabled?.Invoke();
        }

        protected virtual void OnEnabled() { }
        protected virtual void OnDisabled() { }
    }
}