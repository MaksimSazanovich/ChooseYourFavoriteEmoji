using System;
using UnityEngine;
using Zenject;

namespace Internal.Codebase.UI.GameUI.Cards
{
    [DisallowMultipleComponent]
    public sealed class Card1 : CardBase
    {
        public event Action<int> OnClickToGetAnswer;
        protected override void GetAnswer()
        {
            OnClickToGetAnswer?.Invoke(0);
        }
    }
}