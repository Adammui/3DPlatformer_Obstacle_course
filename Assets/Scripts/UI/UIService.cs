using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using UnityEditor.PackageManager.UI;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using Zenject;

namespace UI
{
    public abstract class UIService: MonoBehaviour
    {
        [SerializeField] private RectTransform _canvasRect;
        [SerializeField] private CanvasScaler _canvasScaler;
        [SerializeField] private RectTransform _parent;
        [SerializeField] private List<Screen> _screensPrefabs;
        private DiContainer _container;
        private Dictionary<Type, Screen> _screensDictionary;
        protected readonly Dictionary<Type, Screen> _screens = new();
        
        [Inject]
        private void Construct(DiContainer container)
        {
            _container = container;
        }
        
        public virtual void Initialize()
        {
            _screensDictionary = _screensPrefabs.ToDictionary(screen => screen.GetType(), s => s);
            _canvasScaler.matchWidthOrHeight = 0;
        }
        public TScreen ShowScreen<TScreen>() where TScreen : Screen
        {
            Type type = typeof(TScreen);
            Screen screen = GetOrCreateScreen(type);
            screen.Show();
            return (TScreen)screen;
        }
        public void HideScreen<TScreen>() where TScreen : Screen
        {
            Type type = typeof(TScreen);
            _screens[type].Hide();
        }
        private Screen GetOrCreateScreen(Type type)
        {
            return _screens.TryGetValue(type, out var window) ? window : CreateScreen(type);
        }
        private Screen CreateScreen(Type type)
        {
            Screen screen = _container.InstantiatePrefabForComponent<Screen>(_screensDictionary[type], _parent);
            _screens.Add(type,screen);
            screen.OnAwake();
            return screen;
        }
    }
}