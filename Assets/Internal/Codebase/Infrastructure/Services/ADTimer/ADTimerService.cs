using System;
using Internal.Codebase.Infrastructure.Factories;
using UnityEngine;
using Zenject;

namespace Internal.Codebase.Infrastructure.Services.ADTimer
{
    class ADTimerService : IADTimerService
    {
        private IUIFactory uiFactory;
        private UI.ADTimer.ADTimer adTimer;

        [Inject]
        private void Constructor(IUIFactory uiFactory) =>
            this.uiFactory = uiFactory;

        public void Init() =>
            adTimer = uiFactory.CreateTimer();

        public void ShowTimer(Action callback = null) =>
            adTimer.Show(callback);

        public void HideTimer(Action callback = null) =>
            adTimer.Hide(callback);
    }
}