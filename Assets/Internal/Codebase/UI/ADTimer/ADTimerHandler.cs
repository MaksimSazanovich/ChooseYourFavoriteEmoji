using System.Collections;
using Internal.Codebase.Infrastructure.Services.ADTimer;
using UnityEngine;
using YG;
using Zenject;

namespace Internal.Codebase.UI.ADTimer
{
    public sealed class ADTimerHandler : MonoBehaviour
    {
        private IADTimerService adTimerService;
        [SerializeField] private float timeBeforeAD = 150;

        [Inject]
        private void Constructor(IADTimerService adTimerService)
        {
            this.adTimerService = adTimerService;
        }

        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
        }

        private void OnEnable()
        {
            YandexGame.CloseFullAdEvent += HideTimer;
        }
        
        private void OnDisable()
        {
            YandexGame.CloseFullAdEvent -= HideTimer;
        }

        private void Start()
        {
            StartCoroutine(ADTimer());
            adTimerService.Init();
        }

        private void HideTimer()
        {
            adTimerService.HideTimer();
            StartCoroutine(ADTimer());
        }

        private IEnumerator ADTimer()
        {
            yield return new WaitForSeconds(timeBeforeAD);
            adTimerService.ShowTimer();
        }
    }
}