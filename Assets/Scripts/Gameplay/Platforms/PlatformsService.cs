using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

namespace Gameplay.Platforms
{
    public class PlatformsService :MonoBehaviour
    {
        private Dictionary<PlatformObject, IPlatform> _platforms = new Dictionary<PlatformObject, IPlatform>();

        //убрать если не понадобиться
        private readonly Dictionary<PlatformObject, bool> _activatedPlatforms = new();
        
        public PlatformsService()
        {
            //создать депенденси
            //добавить в _platforms все платформы из level config( там IDictionary<PlatformType, PlatformConfig> Configs )
            //записать все обьекты платформ в _activatedPlatforms и установить bool в false
        }

        //todo
        public void Update(float deltaTime)
        {
            //добавляем дельту времени к кулдаунам платформ , сравниваем с конфигом кулдаун и если кулдаун закончился вызываем метод дамага из платформы класса (fixed upd)
        }
        
        //todo from entry point
        public void Create(List<PlatformObject> platforms)
        {
            _platforms.Clear();
            foreach (PlatformObject obj in platforms)
            {
                if(obj !=null && obj.Platform !=null)
                    _platforms.Add(obj,obj.Platform);
                Debug.Log(obj.Platform);
            }
            
            
            foreach (PlatformObject obj in _platforms.Keys) // для каждого обьекта платформы на уровне
            {
                obj.OnPlayersListChanged += obj.Platform.OnPlayersAffectedChanged;
                obj.OnPlatformInteracted += OnPlatformInteraction;
            }
            foreach (IPlatform platform in _platforms.Values) // для каждого типа платформ
            {
                    platform.OnHintUpdate += platform.HintObj.UpdateHint;
                if (platform.Config.IsAlwaysActive) platform.TurnOn(); // todo что-то не так как будто
            }
        }
        //todo exit point
        public void Dispose()
        {
            foreach (PlatformObject obj in _platforms.Keys)
            {
                obj.OnPlayersListChanged -= obj.Platform.OnPlayersAffectedChanged;
                obj.OnPlatformInteracted -= OnPlatformInteraction;
            }
            foreach (IPlatform platform in _platforms.Values)
            {
                platform.OnHintUpdate -= platform.HintObj.UpdateHint;
                platform.TurnOff();
            }
        }
        private void OnPlatformInteraction(PlatformObject obj, int players)
        {
            Debug.Log("cbuybfk");
            if (players > 0)
            {
                _activatedPlatforms[obj] = true;
                if(!obj.Platform.Config.IsAlwaysActive) obj.Platform.TurnOn();
            }
            else
            {
                _activatedPlatforms[obj] = false;
                if(!obj.Platform.Config.IsAlwaysActive) obj.Platform.TurnOff();
            }
        }
    }
}