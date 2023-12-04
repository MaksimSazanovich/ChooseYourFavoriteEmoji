using Internal.Codebase.Game;
using Internal.Codebase.UI.LoadingCurtain;
using NaughtyAttributes;
using UnityEngine;
using Zenject;

namespace Internal.Codebase.Installer
{
    [DisallowMultipleComponent]
    public sealed class ConfigInstaller : MonoInstaller
    {
        [SerializeField, Expandable] private CurtainConfig curtainConfig;
        [SerializeField, Expandable] private EmojiConfigs emojiConfigs;

        public override void InstallBindings()
        {
            Container.Bind<CurtainConfig>().FromInstance(curtainConfig).AsSingle();
            Container.Bind<EmojiConfigs>().FromInstance(emojiConfigs).AsSingle();
        }
    }
}