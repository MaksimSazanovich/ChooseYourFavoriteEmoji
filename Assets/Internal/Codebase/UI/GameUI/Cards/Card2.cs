using System;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Internal.Codebase.UI.GameUI.Cards
{
    [DisallowMultipleComponent]
    public sealed class Card2 : CardBase
    {
        public event Action<int> OnClickToGetAnswer;
        protected override void GetAnswer()
        {
            OnClickToGetAnswer?.Invoke(1);
        }
    }
}