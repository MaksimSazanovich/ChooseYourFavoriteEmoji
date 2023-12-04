using Internal.Codebase.Infrastructure;
using Internal.Codebase.Infrastructure.LocalStorage;
using Internal.Codebase.Infrastructure.Services.ADService;
using Internal.Codebase.Infrastructure.Services.ADTimer;
using Internal.Codebase.Infrastructure.Services.CoroutineRunner;
using Internal.Codebase.Infrastructure.Services.Curtain;
using Internal.Codebase.Infrastructure.Services.ProgressLogic;
using Internal.Codebase.Infrastructure.Services.ResourceProvider;
using Internal.Codebase.LocalStorage;
using UnityEngine;
using Zenject;
using ResourceProvider = Internal.Codebase.Infrastructure.Services.ResourceProvider.ResourceProvider;

namespace Internal.Codebase.Installer
{
    [DisallowMultipleComponent]
    public sealed class ServiceInstaller : MonoInstaller, ICoroutineRunner
    {
        public override void InstallBindings()
        {
            Container.Bind<ICurtainService>().To<CurtainService>().AsSingle().NonLazy();
            Container.Bind<IADTimerService>().To<ADTimerService>().AsSingle().NonLazy();
            
            Container.Bind<ICoroutineRunner>().FromInstance(this).AsSingle().NonLazy();
            Container.Bind<ISceneLoaderService>().To<SceneLoaderService>().AsSingle().NonLazy();
            
            Container.Bind<IStorageService>().To<JsonToFileStorageService>().AsSingle().NonLazy();
            Container.Bind<IPersistenProgress>().To<PersistenProgress>().AsSingle().NonLazy();;
            
            Container.Bind<IResourceProvider>().To<ResourceProvider>().AsSingle().NonLazy();
            Container.Bind<IADService>().To<ADService>().AsSingle().NonLazy();
        }
    }
}