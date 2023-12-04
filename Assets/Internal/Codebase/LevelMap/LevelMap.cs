using System.Diagnostics.CodeAnalysis;
using Internal.Codebase.Infrastructure.Constants;
using Internal.Codebase.LocalStorage;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace Internal.Codebase.LevelMap
{
    [SuppressMessage("ReSharper", "CommentTypo")]
    public sealed class LevelMap : MonoBehaviour
    {
        [SerializeField] private Progress progress;
        private IStorageService storageService;

        [Inject]
        private void Construct(IStorageService storage) =>
            storageService = storage;

        private void Start() =>
            storageService.Load<Progress>(SaveKey.LevelIndex, Loaded);

        private void Loaded(Progress data) =>
            progress = data ?? new Progress(0);

        public void GetIndex(int index)
        {
            progress.index = index;

            // Нужно сохранять не значение типа int "progress.index", а объект целиком "progress".
            storageService.Save(SaveKey.LevelIndex, progress);
            
            // Local Storage - C:\Users\UsersName\AppData\LocalLow\Blebagames\RaftProtection\Database -> LevelIndex
        }
        
    }
}