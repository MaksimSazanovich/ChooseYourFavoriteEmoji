using DG.Tweening;
using UnityEngine;

namespace Internal.Codebase.UI.GameUI.WinPanel.WinnerBackground
{
    [DisallowMultipleComponent]
    public sealed class WinnerBackground : MonoBehaviour
    {
        [SerializeField] private int rotationSpeed;
        private void OnEnable()
        {
            transform.DORotate(new Vector3(0, 0, -360), rotationSpeed, RotateMode.LocalAxisAdd)
                .SetLoops(-1).SetEase(Ease.Linear).SetSpeedBased();
        }
        
        private void OnDisable()
        {
            transform.DOKill();
        }
    }
}