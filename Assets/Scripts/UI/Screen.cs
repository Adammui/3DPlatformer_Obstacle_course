using System;
using UnityEngine;

namespace UI
{
    public abstract class Screen: MonoBehaviour
    {
        private bool _isOpened;

        public event Action<Screen> Showing;
        public event Action<Screen> Hidden;
        public event Action<Screen> Hiding;
        
        public virtual void OnAwake()
        {
            gameObject.SetActive(false);

            RectTransform mainRect = GetComponent<RectTransform>();
            mainRect.anchorMin = Vector2.zero;
            mainRect.anchorMax = Vector2.one;
            mainRect.sizeDelta = Vector2.zero;
            mainRect.pivot = Vector2.one * 0.5f;
            mainRect.localScale = Vector3.one;
            mainRect.anchoredPosition3D = Vector3.zero;
        }

        public void Show()
        {
            if(_isOpened)
                return;
                
            gameObject.SetActive(true);
            OnShowing();
            _isOpened = true;
        }

        public void Hide()
        {
            if(!_isOpened)
                return;
            
            OnHiding();
            OnHidden();
            gameObject.SetActive(false);
            _isOpened = false;
        }
        protected virtual void OnShowing()
        {
            Showing?.Invoke(this);
        }
        
        protected virtual void OnHiding()
        {
            Hiding?.Invoke(this);
        }
        
        protected virtual void OnHidden()
        {
            Hidden?.Invoke(this);
        }
    }
}