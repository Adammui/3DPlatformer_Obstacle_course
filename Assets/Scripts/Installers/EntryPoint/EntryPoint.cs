using UnityEngine;

namespace Installers.EntryPoint
{
    public abstract class EntryPoint: MonoBehaviour
    {
        private void Awake()
        {
            Run();
        }

        protected abstract void Run();
    }
}