using Gameplay.Platforms;
using UnityEngine;
using UnityEngine.Serialization;

namespace Gameplay
{
    public class Level : MonoBehaviour
    {
        [SerializeField] private PlatformObject[] platforms;
        public PlatformObject[] Platforms => platforms;
    }
}
