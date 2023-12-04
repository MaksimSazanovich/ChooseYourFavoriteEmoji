using Internal.Codebase.UI.ADTimer;
using Internal.Codebase.UI.LoadingCurtain;
using UnityEngine;

namespace Internal.Codebase.Infrastructure.Services.ResourceProvider
{
    public interface IResourceProvider
    {
        public CurtainConfig LoadCurtainConfig();
        public ADTimerConfig LoadTimerConfig();
    }
}