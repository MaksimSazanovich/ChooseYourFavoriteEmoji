using DG.Tweening;
using Internal.Codebase.Infrastructure;
using Internal.Codebase.Infrastructure.Constants;
using Internal.Codebase.Infrastructure.Services.Curtain;
using Internal.Codebase.UI.LoadingCurtain;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Zenject;

namespace Internal.Codebase.UI.MenuUI
{
    [DisallowMultipleComponent]
    public sealed class MenuButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        [SerializeField] private Button button;
        private ICurtainService curtain;
        private CurtainConfig curtainConfig;
        private ISceneLoaderService sceneLoaderService;

        [Inject]
        private void Constructor(ICurtainService curtain, CurtainConfig curtainConfig, ISceneLoaderService sceneLoaderService)
        {
            this.curtain = curtain;
            this.curtainConfig = curtainConfig;
            this.sceneLoaderService = sceneLoaderService;
        }
        private void OnValidate()
        {
            button ??= GetComponent<Button>();
        }

        private void OnEnable()
        {
            button.onClick.AddListener(() => curtain.ShowCurtain(true, HideCurtain));
        }

        private void HideCurtain()
        {
            curtain.HideCurtain(curtainConfig.HideDelay);
            sceneLoaderService.LoadScene(SceneName.GameScene);
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            transform.DORotate(new Vector3(0, 0, -7), 0.1f, RotateMode.Fast);
            transform.DOScale(new Vector3(2.7f, 2.7f, 2.7f), 0.1f);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            transform.DORotate(new Vector3(0, 0, 0), 0.1f, RotateMode.Fast);
            transform.DOScale(new Vector3(2.5f, 2.5f, 2.5f), 0.1f);
        }

        private void OnDisable()
        {
            transform.DOKill();
        }
        
        
    }
}