using System;
using System.Collections;
using System.Transactions;
using Internal.Codebase.Infrastructure.Services.CoroutineRunner;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace Internal.Codebase.Infrastructure
{
    public sealed class SceneLoaderService : ISceneLoaderService
    {
        private ICoroutineRunner coroutineRunner;

        [Inject]
        private void Constructor(ICoroutineRunner coroutineRunner)
        {
            this.coroutineRunner = coroutineRunner;
        }
        
        public void LoadScene(string sceneName, Action onSceneLoadedCallback = null) => 
            coroutineRunner.StartCoroutine(LoadSceneCoroutine(sceneName, onSceneLoadedCallback));
        
        public string GetCurrentSceneName() => 
            SceneManager.GetActiveScene().name;

        private IEnumerator LoadSceneCoroutine(string sceneName, Action onSceneLoadedCallback)
        {
            if (GetCurrentSceneName() == sceneName)
            {
                onSceneLoadedCallback?.Invoke();
                yield break;
            }

            var loadSceneOperation = SceneManager.LoadSceneAsync(sceneName);
            while (!loadSceneOperation.isDone)
                yield return new WaitForEndOfFrame();

            onSceneLoadedCallback?.Invoke();
        }
    }
}