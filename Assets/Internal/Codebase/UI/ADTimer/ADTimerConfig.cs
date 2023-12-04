using UnityEngine;

namespace Internal.Codebase.UI.ADTimer
{
    [CreateAssetMenu(menuName = "StaticData/Create ADTimerConfig", fileName = "ADTimerConfig", order = 1)]
    public class ADTimerConfig : ScriptableObject
    {
        [field: SerializeField] public ADTimer ADTimer { get; private set; }
        
        [field: Space(20)]
        [field: SerializeField] public int Duration { get; private set; } = 3;
    }
}