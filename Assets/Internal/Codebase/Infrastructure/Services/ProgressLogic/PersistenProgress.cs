using System;
using ModestTree;
using UnityEngine;
using YG;

namespace Internal.Codebase.Infrastructure.Services.ProgressLogic
{
    public sealed class PersistenProgress : IPersistenProgress
    {
        public string[] winners { get; private set; } = YandexGame.savesData.winners;
        
        public void Save()
        {
            if (!YandexGame.SDKEnabled)
                return;
            YandexGame.SaveProgress();
        }

        public string[] Load(Action callback = null)
        {
            winners = YandexGame.savesData.winners;
            return winners;
        }
    }
}