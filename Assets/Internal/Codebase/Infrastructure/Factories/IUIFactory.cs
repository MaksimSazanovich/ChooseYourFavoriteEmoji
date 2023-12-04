using Internal.Codebase.Infrastructure.Services.ADService;
using Internal.Codebase.UI.ADTimer;
using Internal.Codebase.UI.LoadingCurtain;

namespace Internal.Codebase.Infrastructure.Factories
{
    public interface IUIFactory
    {
        public Curtain CreateCurtain();
        public ADTimer CreateTimer();
    }
}