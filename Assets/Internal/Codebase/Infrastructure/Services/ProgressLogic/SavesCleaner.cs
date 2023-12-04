using System;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;
using YG;

namespace Internal.Codebase.Infrastructure.Services.ProgressLogic
{
    [DisallowMultipleComponent]
    public sealed class SavesCleaner : MonoBehaviour
    {
        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
        }

        [Button(nameof(Clear))]
        public void Clear()
        {
            YandexGame.savesData.winners = new string [15];
            YandexGame.savesData.finishedTopics = new HashSet<int>();
            YandexGame.SaveProgress();
        }
    }
}