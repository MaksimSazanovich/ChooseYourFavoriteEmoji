using System;
using Internal.Codebase.Infrastructure;
using Internal.Codebase.Infrastructure.Constants;
using Internal.Codebase.Infrastructure.Services.Curtain;
using Internal.Codebase.UI.LoadingCurtain;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Internal.Codebase.UI.WinUI
{
    [DisallowMultipleComponent]
    public sealed class WinButton : MonoBehaviour
    {
         [SerializeField] private Button button;
         private ISceneLoaderService sceneLoader;
         private ICurtainService curtain;
         private CurtainConfig curtainConfig;
         private ISceneLoaderService sceneLoaderService;

         [Inject]
         private void Constructor(ISceneLoaderService sceneLoader)
         {
             this.sceneLoader = sceneLoader;
         }
         
         [Inject]
         private void Constructor(ICurtainService curtain, CurtainConfig curtainConfig, ISceneLoaderService sceneLoaderService)
         {
             this.curtain = curtain;
             this.curtainConfig = curtainConfig;
             this.sceneLoaderService = sceneLoaderService;
         }
         
         private void OnEnable()
         {
             button.onClick.AddListener(() => curtain.ShowCurtain(true, HideCurtain));
         }

         private void HideCurtain()
         {
             curtain.HideCurtain(curtainConfig.HideDelay);
             sceneLoaderService.LoadScene(SceneName.MenuScene);
         }

    }
}