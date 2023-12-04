using System;

namespace Internal.Codebase.Infrastructure.Services.ProgressLogic
{
    public interface IPersistenProgress
    {
        public string[] winners { get; }
        void Save();
        string[] Load(Action callback = null);
    }
}