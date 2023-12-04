using Internal.Codebase.Infrastructure.Constants;
using Internal.Codebase.Infrastructure.Services.ADService;
using Internal.Codebase.Infrastructure.Services.ResourceProvider;
using Internal.Codebase.UI.ADTimer;
using Internal.Codebase.UI.LoadingCurtain;
using UnityEngine;
using Zenject;

namespace Internal.Codebase.Infrastructure.Factories
{
    public sealed class UIFactory : IUIFactory
    {
        private IResourceProvider resourceProvider;
        private IADService adService;

        [Inject]
        private void Constructor(IResourceProvider resourceProvider, IADService adService)
        {
            this.adService = adService;
            this.resourceProvider = resourceProvider;
        }
        public Curtain CreateCurtain()
        {
            var config = resourceProvider.LoadCurtainConfig();

            var view = Object.Instantiate(config.Curtain);
            view.Constructor(config.AnimationDuration);

            return view;
        }

        public ADTimer CreateTimer()
        {
            var adTimerConfig = resourceProvider.LoadTimerConfig();

            var view = Object.Instantiate(adTimerConfig.ADTimer);
            view.Constructor(adTimerConfig.Duration, adService);

            return view;
        }
    }
}