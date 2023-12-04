using System.Collections.Generic;
using UnityEngine;

namespace Internal.Codebase.Configs
{
    [CreateAssetMenu(fileName = "EmojisConfig", menuName = "EmojisConfig", order = 0)]
    public class EmojisConfig : ScriptableObject
    {
        public List<Sprite> Emojis;
    }
}