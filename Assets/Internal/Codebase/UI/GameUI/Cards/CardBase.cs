using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Zenject;

namespace Internal.Codebase.UI.GameUI.Cards
{
    public abstract class CardBase : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler
    {
        [SerializeField] protected Button button;
        [SerializeField] protected RectTransform transform;
        [SerializeField] protected Vector2 endValue;

        private CardAnimator.CardAnimator cardAnimator;

        private bool canDOSize = true;
        private bool canSetScale = true;

        public event Action OnClick;

        protected static int touches = 0;
        protected static bool canClick = true;
        
        [Inject]
        private void Constructor(CardAnimator.CardAnimator cardAnimator)
        {
            this.cardAnimator = cardAnimator;
        }

        private void OnEnable()
        {
            button.onClick.AddListener(InvokeOnClick);
            cardAnimator.OnStartFlip += LockDoSize;
            cardAnimator.OnEndFlip += UnlockDoSize;
            cardAnimator.OnEndFlip += SetCanClickTrue;
            cardAnimator.OnStartFlip += SetTouchsZero;
            cardAnimator.OnEndFlip += SetTouchsZero;
        }

        private void OnDisable()
        {
            button.onClick.RemoveListener(InvokeOnClick);
            cardAnimator.OnStartFlip -= LockDoSize;
            cardAnimator.OnEndFlip -= UnlockDoSize;
            cardAnimator.OnEndFlip -= SetCanClickTrue;
            cardAnimator.OnStartFlip -= SetTouchsZero;
            cardAnimator.OnEndFlip -= SetTouchsZero;
        }

        protected virtual void InvokeOnClick()
        {
            if (touches == 1 && canClick)
            {
                canClick = false;
                OnClick?.Invoke();
                Debug.Log(nameof(GetAnswer));
                GetAnswer();
            }
            else if (touches >= 2)
                touches = 0;
        }

        protected virtual void GetAnswer()
        {
            
        }

        private void SetTouchsZero() => touches = 0;

        private void SetCanClickTrue() => canClick = true;


        private void LockDoSize() => canDOSize = false;
        private void UnlockDoSize() => canDOSize = true;

        private void DoSize()
        {
            canSetScale = false;
            transform.DOScale(new Vector3(3.1f, 3.1f), 0.1f)
                .OnComplete(() =>
                {
                    canSetScale = true;
                });
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            if (canDOSize)
                DoSize();
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            if (canDOSize)
                transform.DOScale(new Vector3(3, 3, 3), 0.1f)
                    .SetEase(Ease.OutBounce)
                    .OnComplete(() =>
                    {
                        canSetScale = true;
                    });
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            touches++;
            Debug.Log("touches: " + touches);
        }
    }
}