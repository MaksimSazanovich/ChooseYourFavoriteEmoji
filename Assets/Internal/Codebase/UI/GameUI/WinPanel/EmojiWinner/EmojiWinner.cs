using System;
using DG.Tweening;
using UnityEngine;

namespace Internal.Codebase.EmojiWinner
{
    [DisallowMultipleComponent]
    public sealed class EmojiWinner : MonoBehaviour
    {
        [SerializeField] private Ease ease;
        [SerializeField] private Vector3 maxScale;
        [SerializeField] private Vector3 startScale;
        private void OnEnable()
        {
            transform.DOPunchScale(maxScale, 2f, 0,0).SetEase(ease).SetLoops(-1);
        }
        
        private void OnDisable()
        {
            transform.DOKill();
        }
    }
}