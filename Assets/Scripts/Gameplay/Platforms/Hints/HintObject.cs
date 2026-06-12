using UnityEngine;

namespace Gameplay.Platforms.Hints
{
    public class HintObject : MonoBehaviour
    {
        [SerializeReference , SubclassSelector ] private IHint hint;
        public IHint Hint => hint;
        public void ShowHint()
        {
            hint.Start();
        }

        public void StopHint()
        {
            hint.Stop();
        }

        public void UpdateHint(HintUpdateContext data)
        {
            hint.Update(data, this.gameObject);
        }
    }
}