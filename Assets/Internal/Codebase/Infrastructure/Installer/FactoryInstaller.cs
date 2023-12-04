using Internal.Codebase.Infrastructure.Factories;
using UnityEngine;
using Zenject;

namespace Internal.Codebase.Installer
{
    [DisallowMultipleComponent]
    public sealed class FactoryInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<IUIFactory>().To<UIFactory>().AsSingle();
        }
    }
}