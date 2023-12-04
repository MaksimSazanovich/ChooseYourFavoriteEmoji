using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace Internal.Codebase.UI.ADTimer
{
    [DisallowMultipleComponent]
    public sealed class ClockImage : MonoBehaviour
    {
        [SerializeField] private Image Image;
        [SerializeField] private Ease ease;

        [SerializeField] private Vector3 normalScale;
        [SerializeField] private Vector3 bigScale;

        public void ShowAnimation()
        {
            DoSize(bigScale);
            Rotate();
        }
        public void Rotate(Action callback = null)
        {
            transform.DORotate(new Vector3(0, 0, 360), 5f, RotateMode.WorldAxisAdd).
                SetLoops(-1).SetEase(ease);
        }
        private void DoSize(Vector3 scale,Action callback = null)
        {
            transform.DOScale(scale, 0.1f);
        }
        
    }
}