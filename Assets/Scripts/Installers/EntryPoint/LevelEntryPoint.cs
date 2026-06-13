using Gameplay;
using Zenject;

namespace Installers.EntryPoint
{
    public class LevelEntryPoint : EntryPoint
    {
        private LevelService _levelService;

        [Inject]
        private void Construct(LevelService levelService)
        {
            _levelService = levelService;
        }

        protected override void Run()
        {
            _levelService.SpawnLevel();
        }
    }
}