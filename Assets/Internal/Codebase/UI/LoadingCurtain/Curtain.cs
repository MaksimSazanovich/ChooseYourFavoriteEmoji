using System;
using DG.Tweening;
using UnityEngine;

namespace Internal.Codebase.UI.LoadingCurtain
{
    [DisallowMultipleComponent]
    public sealed class Curtain : MonoBehaviour
    {
        [SerializeField] private  CanvasGroup canvasGroup;
        private float animationDuration = 0.4f;
        [SerializeField] private RectTransform leftBluePart;
        [SerializeField] private RectTransform rightRedPart;

        [SerializeField] private Vector3 startleftBluePartPosition;
        [SerializeField] private Vector3 startrightRedPartPosition;

        public void Constructor(float animationDuration)
        {
            this.animationDuration = animationDuration;
        }

        private void Awake()
        {
            DontDestroyOnLoad(this);
        }

        public void Show(bool isAnimated, Action callback)
        {
            canvasGroup.DOKill();
            gameObject.SetActive(true);

            if (!isAnimated)
            {
                canvasGroup.alpha = 1;
                callback?.Invoke();
                return;
            }

            canvasGroup.alpha = 1;
            leftBluePart.DOAnchorPos(Vector2.zero, animationDuration).SetEase(Ease.OutBounce).OnComplete(() =>
            {
                callback?.Invoke();
            });
            rightRedPart.DOAnchorPos(Vector2.zero, animationDuration).SetEase(Ease.OutBounce);
        }

        public void Hide(bool isAnimated, Action callback)
        {
            canvasGroup.DOKill();

            if (!isAnimated)
            {
                gameObject.SetActive(false);
                callback?.Invoke();

                return;
            }

            canvasGroup
                .DOFade(0, animationDuration)
                .OnComplete(() =>
                {
                    callback?.Invoke();
                });

        }

        public void Hide(float startDelay, Action callback)
        {
            Debug.Log(nameof(Hide));
            canvasGroup
                .DOFade(0, animationDuration)
                .SetDelay(startDelay)
                .OnComplete(() =>
                {
                    gameObject.SetActive(false);
                    callback?.Invoke();
                    leftBluePart.DOAnchorPos(startleftBluePartPosition, 0.01f);
                    rightRedPart.DOAnchorPos(startrightRedPartPosition, 0.01f);
                });
        }
    }
}