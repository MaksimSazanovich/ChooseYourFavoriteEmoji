using System;
using Internal.Codebase.Infrastructure.Factories;
using Internal.Codebase.UI.LoadingCurtain;
using Zenject;

namespace Internal.Codebase.Infrastructure.Services.Curtain
{
    public sealed class CurtainService : ICurtainService
    {
        private IUIFactory uiFactory;
        private UI.LoadingCurtain.Curtain curtain;
        
        [Inject]
        private void Constructor(IUIFactory uiFactory) =>
            this.uiFactory = uiFactory;

        public void Init() =>
            curtain = uiFactory.CreateCurtain();

        public void ShowCurtain(bool isAnimated = true, Action callback = null) =>
            curtain.Show(isAnimated, callback);

        public void HideCurtain(bool isAnimated = true, Action callback = null) =>
            curtain.Hide(isAnimated, callback);

        public void HideCurtain(float startDelay, Action callback = null) =>
            curtain.Hide(startDelay, callback);
    }
}