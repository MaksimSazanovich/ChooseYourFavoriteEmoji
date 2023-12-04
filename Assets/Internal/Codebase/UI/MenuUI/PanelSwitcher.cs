using DG.Tweening;
using UnityEngine;

namespace Internal.Codebase.UI.MenuUI
{
    [DisallowMultipleComponent]
    public sealed class PanelSwitcher : MonoBehaviour
    {
        [SerializeField] private RectTransform winnersPanel;
        [SerializeField] private RectTransform menuPanel;
        [SerializeField] private CanvasGroup winCanvasGroup;
        [SerializeField] private CanvasGroup menuCanvasGroup;

        [SerializeField] private float animationDuration;
        [SerializeField] private Ease ease;

        [SerializeField] private GameObject leftArrow;
        [SerializeField] private GameObject rightArrow;

        private PanelTypes currentPanelType = PanelTypes.Menu;

        private void Start()
        {
            winCanvasGroup.alpha = 0;
            menuCanvasGroup.alpha = 1;
            CheckArrows();
        }

        public void MoveRight()
        {
            currentPanelType = PanelTypes.Winners;
            CheckArrows();
            winCanvasGroup.alpha = 1;
            winnersPanel.DOAnchorPos(Vector2.zero, animationDuration).SetEase(ease);
            menuPanel.DOAnchorPos(new Vector2(-1950, 0), animationDuration).SetEase(ease).OnComplete(() =>
            {
             
                menuCanvasGroup.alpha = 0;
            });
        }

        public void MoveLeft()
        {
            currentPanelType = PanelTypes.Menu;
            CheckArrows();
            menuCanvasGroup.alpha = 1;
            winnersPanel.DOAnchorPos(new Vector2(1950, 0), animationDuration).SetEase(ease).OnComplete(
                () =>
                {
                
                    winCanvasGroup.alpha = 0;
                });
            menuPanel.DOAnchorPos(Vector2.zero, animationDuration).SetEase(ease);
        }

        private void CheckArrows()
        {
            leftArrow.SetActive(currentPanelType == PanelTypes.Winners);
            rightArrow.SetActive(currentPanelType == PanelTypes.Menu);
        }
    }
}