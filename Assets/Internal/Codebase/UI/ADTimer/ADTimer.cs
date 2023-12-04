using System;
using System.Collections;
using Internal.Codebase.Infrastructure.Services.ADService;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Internal.Codebase.UI.ADTimer
{
    [DisallowMultipleComponent]
    public sealed class ADTimer : MonoBehaviour
    {
        [SerializeField] private TMP_Text text;
        [SerializeField] private ClockImage clock;
        private int duration = 3;
        
        [SerializeField] private  CanvasGroup canvasGroup;
        private IADService adService;

        public const string AD = "AD ";
        
        public void Constructor(int duration, IADService adService)
        {
            this.duration = duration;
            this.adService = adService;
        }

        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
        }

        private void Start()
        {
            gameObject.SetActive(false);
        }

        public void Show(Action callback)
        {
            gameObject.SetActive(true);
            canvasGroup.alpha = 1;
            
            clock.ShowAnimation();
            
            StartCoroutine(TimerBeforeAD());
        }

        public void Hide(Action callback = null)
        {
            gameObject.SetActive(false);
            canvasGroup.alpha = 0;
        }

        private IEnumerator TimerBeforeAD()
        {
            for (int i = 0; i < duration; i++)
            {
                text.text = AD + (duration - i) + "...";
                yield return new WaitForSeconds(1);
            }
            Hide();
            adService.ShowFullscreenAD();
        }
    }
}