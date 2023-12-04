using Internal.Codebase.UI.GameUI.Cards;
using UnityEngine;
using Zenject;

namespace Internal.Codebase.Installer
{
    [DisallowMultipleComponent]
    public sealed class LevelInstaller : MonoInstaller
    {
        [SerializeField] private Card1 card1;
        [SerializeField] private Card2 card2;
        [SerializeField] private CardAnimator.CardAnimator cardAnimator;

        public override void InstallBindings()
        {
            Container.Bind<Card1>().FromInstance(card1).AsSingle();
            Container.Bind<Card2>().FromInstance(card2).AsSingle();
            Container.Bind<CardAnimator.CardAnimator>().FromInstance(cardAnimator).AsSingle();
        }
    }
}