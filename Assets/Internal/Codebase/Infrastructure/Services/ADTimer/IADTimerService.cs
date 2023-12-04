using System;

namespace Internal.Codebase.Infrastructure.Services.ADTimer
{
    public interface IADTimerService
    {
        public void Init();
        public void ShowTimer(Action callback = null);
        public void HideTimer(Action callback = null);
    }
}