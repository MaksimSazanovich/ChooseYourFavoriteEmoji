using YG;

namespace Internal.Codebase.Infrastructure.Services.ADService
{
    public sealed class ADService : IADService
    {
        public void ShowFullscreenAD()
        {
            if (IsSDKNotInit())
                return;
            
            YandexGame.FullscreenShow();
        }
        
        private static bool IsSDKNotInit() =>
            !YandexGame.SDKEnabled;
    }
}