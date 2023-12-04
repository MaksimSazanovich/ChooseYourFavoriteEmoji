using System;
using System.Collections.Generic;
using Internal.Codebase.Game;
using Internal.Codebase.Infrastructure.LocalStorage;
using Internal.Codebase.Infrastructure.Services.ProgressLogic;
using Internal.Codebase.LocalStorage;
using UnityEngine;
using UnityEngine.UI;
using YG;
using Zenject;


namespace Internal.Codebase.UI.MenuUI
{
    [DisallowMultipleComponent]
    public sealed class WinnersBoard : MonoBehaviour
    {
        private IPersistenProgress persistenProgress;

        [SerializeField] private Image[] winners;
        private EmojiConfigs emojiConfigs;
        [SerializeField] private Image secretEmoji;
        [SerializeField] private Sprite blebaGames;
        private IStorageService storageService;
        
        private HashSet<int> finishedTopics = new HashSet<int>();

        [Inject]
        private void Constructor(IPersistenProgress persistenProgress, EmojiConfigs emojiConfigs,
            IStorageService storageService)
        {
            this.storageService = storageService;
            this.persistenProgress = persistenProgress;
            this.emojiConfigs = emojiConfigs;
        }
        
        private void Start()
        {
            string[] id = persistenProgress.Load();
            for (int i = 0; i < winners.Length; i++)
            {
                EmojiConfig emojiConfig = emojiConfigs.configs.Find(config => config.id == id[i]);
                if (id[i] != null && emojiConfig != null)
                    winners[i].sprite = emojiConfig.emoji;
            }
            persistenProgress?.Save();

            if (YandexGame.savesData.finishedTopics == null)
                return;
            
            finishedTopics = YandexGame.savesData.finishedTopics;
            
            if (finishedTopics.Count == 15)
                secretEmoji.sprite = blebaGames;
        }
    }
}