using Gameplay.Platforms.Hints;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

namespace Gameplay.Platforms
{
    public interface IHint
    {
       public bool IsActive { get; set; }

       public void Start()
       {
           IsActive = true;
       }
       public void Stop()
       {
           IsActive = false;
       }
       public abstract void Update(HintUpdateContext context, GameObject hintObject);
    }
    public struct HintUpdateContext
    {
        public Vector3 WindDirection;
        public Material MaterialColor;
        public HintUpdateContext(Vector3 windDirection, Material materialColor=null)
        {
            WindDirection = windDirection;
            MaterialColor = materialColor;
        }
    }
}
