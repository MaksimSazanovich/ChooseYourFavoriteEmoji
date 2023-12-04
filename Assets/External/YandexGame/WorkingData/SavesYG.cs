using System.Collections.Generic;
using Internal.Codebase.Game;
using Internal.Codebase.Infrastructure.Services.ProgressLogic.Storage;

namespace YG
{
    [System.Serializable]
    public class SavesYG
    {
        // "Технические сохранения" для работы плагина (Не удалять)
        public int idSave;
        public bool isFirstSession = true;
        public string language = "ru";
        public bool promptDone;

        public string[] winners = new string [15];
        public HashSet<int> finishedTopics = new HashSet<int>();
    }
}
