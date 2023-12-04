using System;

namespace Internal.Codebase.Infrastructure
{
    public interface ISceneLoaderService
    {
        public void LoadScene(string sceneName, Action onSceneLoadedCallback = null);
        public string GetCurrentSceneName();
    }
}