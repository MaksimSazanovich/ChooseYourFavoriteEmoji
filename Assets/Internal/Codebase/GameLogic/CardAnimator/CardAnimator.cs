using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Internal.Codebase.UI.GameUI.Cards;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Internal.Codebase.CardAnimator
{
    [DisallowMultipleComponent]
    public sealed class CardAnimator : MonoBehaviour
    {
        public event Action OnCardsOnBecameAnEdge;
        public event Action OnStartFlip;
        public event Action OnEndFlip;
        
        private const string FLIP = "Flip";

        private bool canFlip = true;
        private Card1 card1;
        private Card2 card2;

        [SerializeField] private RectTransform emoji1;
        [SerializeField] private RectTransform emoji2;

        private Vector3 scaleEmoji1;
        private Vector3 scaleEmoji2;

        private Vector3 cardsScale;

        [Inject]
        private void Constructor(Card1 card1, Card2 card2)
        {
            this.card1 = card1;
            this.card2 = card2;
        }

        private void OnEnable()
        {
            card1.OnClick += SetCardScaleToCard2;
            card1.OnClick += Flip;
            card2.OnClick += SetCardScaleToCard1;
            card2.OnClick += Flip;
        }

        private void OnDisable()
        {
            card1.OnClick -= Flip;
            card1.OnClick -= SetCardScaleToCard2;
            card2.OnClick -= Flip;
            card2.OnClick -= SetCardScaleToCard1;
        }

        private void SetCardScaleToCard1()
        {
            cardsScale = card1.transform.localScale; 
        }

        private void SetCardScaleToCard2()
        {
            cardsScale = card2.transform.localScale; 
        }

        public void InvokeOnCardsOnBecameAnEdge() => OnCardsOnBecameAnEdge?.Invoke();
        private void Flip()
        {
            if (canFlip)
            {
                canFlip = false;
                OnStartFlip?.Invoke();
                Debug.Log("Flip");
                card1.transform.DOScale(new Vector3(0,cardsScale.y,0), 0.15f).OnComplete(() =>
                    {
                        InvokeOnCardsOnBecameAnEdge();
                        card1.transform.DOScale(cardsScale, 0.15f);
                        StartCoroutine(DelayEndFlip());
                    }
                );
                card2.transform.DOScale(new Vector3(0,cardsScale.y,0), 0.15f).OnComplete(() =>
                    {
                        card2.transform.DOScale(cardsScale, 0.15f);
                        
                    }
                );
            }
        }
        
        private IEnumerator DelayEndFlip()
        {
            yield return new WaitForSeconds(0.3f);
            OnEndFlip?.Invoke();
            canFlip = true;
        }

        public void FlipEmoji1()
        {
            scaleEmoji1 = emoji1.localScale;
            scaleEmoji1.x *= -1;
            emoji1.localScale = scaleEmoji1;
        }
        
        public void FlipEmoji2()
        {
            scaleEmoji2 = emoji2.localScale;
            scaleEmoji1.x *= -1;
            emoji2.localScale = scaleEmoji1;
        }
    }
}