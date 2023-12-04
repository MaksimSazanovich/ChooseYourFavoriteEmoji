using Internal.Codebase.Infrastructure.Constants;
using Internal.Codebase.Infrastructure.Services.Curtain;
using Internal.Codebase.UI.LoadingCurtain;
using UnityEngine;
using YG;
using Zenject;

namespace Internal.Codebase.Infrastructure
{
    [DisallowMultipleComponent]
    public sealed class GameBootstrapper : MonoBehaviour
    {
        private ICurtainService curtainService;
        private CurtainConfig curtainConfig;
        private ISceneLoaderService sceneLoader;

        [Inject]
        private void Constructor(
            ICurtainService curtainService,
            CurtainConfig curtainConfig,
            ISceneLoaderService sceneLoader
            )
        {
            this.curtainService = curtainService;
            this.curtainConfig = curtainConfig;
            this.sceneLoader = sceneLoader;
        }

        public void Start()
        {
            Debug.Log("0.0.0.6");
            Load();
        }

        private void Load()
        {
            curtainService.Init();
            curtainService.ShowCurtain(true, HideCurtain);
        }

        private void HideCurtain()
        {
            curtainService.HideCurtain(curtainConfig.HideDelay);
            sceneLoader.LoadScene(SceneName.MenuScene, InitGRA);
        }

        private void InitGRA()
        {
            YandexGame.GameReadyAPI();
        }
    }
}