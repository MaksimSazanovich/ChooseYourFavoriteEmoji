using Internal.Codebase.Infrastructure.Constants;
using Internal.Codebase.UI.ADTimer;
using Internal.Codebase.UI.LoadingCurtain;
using UnityEngine;

namespace Internal.Codebase.Infrastructure.Services.ResourceProvider
{
    public sealed class ResourceProvider : IResourceProvider
    {
        public CurtainConfig LoadCurtainConfig()
        {
            return Resources.Load<CurtainConfig>(AssetPath.CurtainConfig);
        }

        public ADTimerConfig LoadTimerConfig()
        {
            return Resources.Load<ADTimerConfig>(AssetPath.TimerConfig);
        }
    }
}