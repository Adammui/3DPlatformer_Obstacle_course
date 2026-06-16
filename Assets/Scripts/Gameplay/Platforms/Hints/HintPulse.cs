using System;
using UnityEngine;

namespace Gameplay.Platforms.Hints
{
    [Serializable]
    public class HintPulse : IHint
    {
        public bool IsActive { get; set; }
        private MeshRenderer renderer;
        public void Update(HintUpdateContext data, GameObject hintObj) // hint config in the data
        {
            if (IsActive)
            {
                renderer ??= hintObj.GetComponent<MeshRenderer>();
                renderer.material = data.MaterialColor;
            }
        }
    }
}