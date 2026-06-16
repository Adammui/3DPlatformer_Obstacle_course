using Gameplay.Platforms;

namespace Installers
{
    public class LevelExitPoint : IExitPoint
    {
        private PlatformsService _platformsService;
        private readonly ContextLifetime _contextLifetime;

        public LevelExitPoint(PlatformsService platformsService, ContextLifetime contextLifetime)
        {
            _platformsService = platformsService;
            _contextLifetime = contextLifetime;
        }
        public void Exit()
        {
            _contextLifetime.Dispose();
            _platformsService.Dispose();
        }
    }
}