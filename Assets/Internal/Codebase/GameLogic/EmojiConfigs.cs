using System;
using System.Collections.Generic;
using Internal.Codebase.Configs;
using Internal.Codebase.Infrastructure.Constants;
using NaughtyAttributes;
using UnityEngine;

[Serializable]
public sealed class EmojiConfig
{
    public string id;
    public Sprite emoji;
}

namespace Internal.Codebase.Game
{
    [CreateAssetMenu(menuName = "StaticData/Create EmojiConfigs", fileName = "EmojiConfigs", order = 0)]
    public sealed class EmojiConfigs : ScriptableObject
    {
        public List<EmojiConfig> configs;
        
        [Button(nameof(AutoFilingConfig))]
        private void AutoFilingConfig()
        {
            configs = new List<EmojiConfig>();

            var emojis = UnityEngine.Resources.LoadAll<Sprite>(AssetPath.EmojisSpites);

            foreach (var emoji in emojis)
            {
                var emojiConfig = new EmojiConfig()
                {
                    id = emoji.name,
                    emoji = emoji
                };
                
                configs.Add(emojiConfig);
            }
        }
    }
}