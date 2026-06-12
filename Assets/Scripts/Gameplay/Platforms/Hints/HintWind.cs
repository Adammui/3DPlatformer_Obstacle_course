using System;
using UnityEngine;
namespace Gameplay.Platforms.Hints
{
    [Serializable]
    public class HintWind : IHint
    {
        public bool IsActive { get; set; }

        public void Update(HintUpdateContext data, GameObject hintObj)
        {
            if (IsActive)
                hintObj.transform.forward = data.WindDirection.normalized;
        }
    }
}