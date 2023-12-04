using System;
using System.Collections.Generic;
using Internal.Codebase.Configs;
using Internal.Codebase.Infrastructure.LocalStorage;
using Internal.Codebase.Infrastructure.Services.ProgressLogic;
using Internal.Codebase.LocalStorage;
using Internal.Codebase.UI.GameUI.Cards;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.UI;
using YG;
using Zenject;
using Random = UnityEngine.Random;

namespace Internal.Codebase.Game
{
    [DisallowMultipleComponent]
    public sealed class GameScript : MonoBehaviour
    { 
        [SerializeField, Expandable] private EmojisConfig emojisConfig;

        [SerializeField] private List<EmojiList> startEmojis;

        private List<Sprite> firstEmojisList;
        private List<Sprite> secondEmojisList = new List<Sprite>();
        private Sprite emoji1;
        private Sprite emoji2;
        
        [SerializeField] private Image firstEmoji; 
        [SerializeField] private Image secondEmoji;
        [SerializeField] private Image emojiwinner;

        [SerializeField] private CanvasGroup gamePanel;
        [SerializeField] private CanvasGroup winPanel;
        [SerializeField] private GameObject cleanBackground;
        [SerializeField] private GameObject movingBackground;

        private RoundTypes.RoundTypes roundType = RoundTypes.RoundTypes.NormalRound;

        private bool canChekRoundType = true;
        private CardAnimator.CardAnimator cardAmimator;
        private Card1 card1;
        private Card2 card2;
        private IStorageService storageService;
        
        private Progress progress;
        
        private int currentEmojiType;
        private IPersistenProgress persistenProgress;
        private HashSet<int> finishedTopics;

        [Inject]
        private void Constructor(CardAnimator.CardAnimator cardAnimator, Card1 card1, Card2 card2,
            IStorageService storageService, IPersistenProgress persistenProgress)
        {
            this.cardAmimator = cardAnimator;
            this.card1 = card1;
            this.card2 = card2;
            this.storageService = storageService;
            this.persistenProgress = persistenProgress;
        }

        private void OnEnable()
        {
            cardAmimator.OnCardsOnBecameAnEdge += PlayRound;
            card1.OnClickToGetAnswer += GetAnswer;
            card2.OnClickToGetAnswer += GetAnswer;
        }

        private void OnDisable()
        {
            cardAmimator.OnCardsOnBecameAnEdge -= PlayRound;
            card1.OnClickToGetAnswer -= GetAnswer;
            card2.OnClickToGetAnswer -= GetAnswer;
        }

        private void Start()
        {
            storageService.Load<Progress>(SaveKey.LevelIndex, data =>
            {
                progress = data ?? new Progress(0);

                currentEmojiType = progress.index;

            });
            
            emojisConfig.Emojis = startEmojis[currentEmojiType].emoji;
            firstEmojisList = emojisConfig.Emojis;
            if (GetNumberOfExtraPlayers(firstEmojisList) > 0)
                roundType = RoundTypes.RoundTypes.ExtraRound;
            PlayRound();
        }

        private int GetNumberOfExtraPlayers(List<Sprite> emojis)
        {
            int a = 2;
            while (true)
            {
                if (emojis.Count-a <= 0)
                {
                    return a-emojis.Count;
                    break;
                }
                else
                    a *= 2;
            }
        }

        private void ChekRoundType()
        {
            if (GetNumberOfExtraPlayers(firstEmojisList) > 0)
                roundType = RoundTypes.RoundTypes.ExtraRound;
            else
            {
                roundType = RoundTypes.RoundTypes.NormalRound;
                canChekRoundType = false;
            }
        }
        public void PlayRound()
        {
            if (firstEmojisList.Count == 0 && secondEmojisList.Count == 1)
            {
                persistenProgress.winners[currentEmojiType] = secondEmojisList[0].name; 
                persistenProgress?.Save();
                
                gamePanel.alpha = 0;
                
                winPanel.gameObject.SetActive(true);
                cleanBackground.SetActive(false);
                movingBackground.SetActive(false);
                
                emojiwinner.enabled = true;
                emojiwinner.sprite = secondEmojisList[0];
                
                //storageService.Save(SaveKey.FinishedTopicsProgressData, finishedTopics.Add(currentEmojiType));
                YandexGame.savesData.finishedTopics.Add(currentEmojiType);
                YandexGame.SaveProgress();
                return;
            }
            else if (firstEmojisList.Count == 0 && secondEmojisList.Count > 1)
            {
                firstEmojisList = secondEmojisList;
                secondEmojisList = new List<Sprite>();
            }

            
            if(canChekRoundType)
            ChekRoundType();
            
            int random = Random.Range(0, firstEmojisList.Count);
            Debug.Log(random);
            emoji1 = firstEmojisList[random];
            
            random = Random.Range(0, firstEmojisList.Count);
            Debug.Log(random);
            emoji2 = firstEmojisList[random]; 
            
            if(emoji1 == emoji2)
                PlayRound();
            
            firstEmoji.sprite = emoji1;
            secondEmoji.sprite = emoji2;
        }

        public void GetAnswer(int index)
        {
            if (roundType == RoundTypes.RoundTypes.NormalRound)
            {
                if(index == 0)
                    secondEmojisList.Add(emoji1);
                else if (index == 1)
                    secondEmojisList.Add(emoji2);
                firstEmojisList.Remove(emoji1);
                firstEmojisList.Remove(emoji2);
            }
            else if (roundType == RoundTypes.RoundTypes.ExtraRound)
            {
                if(index == 0)
                    firstEmojisList.Remove(emoji2);
                else if (index == 1)
                    firstEmojisList.Remove(emoji1);
            }
        }
    }
}