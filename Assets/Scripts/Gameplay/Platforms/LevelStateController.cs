using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using Gameplay;
using Gameplay.Player;
using Installers;
using UnityEngine;
using TMPro;
using UI;
using UnityEngine.UI;

public class LevelStateController 
{
    private readonly LevelService _levelService;
    private readonly LevelScreenPresenter _levelScreenPresenter;
    private readonly ContextLifetime _contextLifetime;
    private readonly EndScreenPresenter _endScreenPresenter;
    private readonly PlayerDeathController _playerDeath;

    private float _startTime, _finishTime;
    private bool _timerIsRunning = false;

    public LevelStateController(LevelService levelService, LevelScreenPresenter levelScreenPresenter, ContextLifetime contextLifetime, EndScreenPresenter endScreenPresenter,PlayerDeathController playerDeath)
    {
        _levelService = levelService;
        _levelScreenPresenter = levelScreenPresenter;
        _contextLifetime = contextLifetime;
        _endScreenPresenter = endScreenPresenter;
        _playerDeath = playerDeath;
    }
    public void Initialize()
    {
        TickAsync(_contextLifetime.Token).Forget();
        _levelService.LevelObject.FinishPlatform.StatePlatformEntered +=  HandleWin;
        _levelService.LevelObject.StartPlatform.StatePlatformEntered +=  TimerStart;
        _playerDeath.PlayerDead += HandleDefeat;
    }
    public void Dispose()
    {
        _levelService.LevelObject.FinishPlatform.StatePlatformEntered -=  HandleWin;
        _levelService.LevelObject.StartPlatform.StatePlatformEntered -=  TimerStart;
        _playerDeath.PlayerDead -= HandleDefeat;
    }
    async UniTaskVoid TickAsync(CancellationToken token)
    {
        while(!token.IsCancellationRequested)
        { 
            if (_timerIsRunning)
            {
                _levelScreenPresenter.DisplayTime(Time.time - _startTime);
            }
            await UniTask.Yield(token);
        }
    }
    private void TimerStart()
    {
        Debug.Log("Game started!");
        _timerIsRunning = true;
        _startTime = Time.time;
        
    }
    private void TimerEnd()
    {
        _timerIsRunning = false;
        _finishTime = Time.time - _startTime;
         Debug.Log("Voyage time: " + _finishTime);
    }
    // Handles what happens when player wins
    private void HandleWin() 
    {
        TimerEnd();
        _levelScreenPresenter.CloseScreen();
        _endScreenPresenter.ShowScreen("You succeeded!!!"+ "\n Your space voyage time: "+ _finishTime);
    }
    // Handles what happens when player looses (called player lost all hp too)
    private void HandleDefeat()
    {
        TimerEnd();
        _levelScreenPresenter.CloseScreen();
        _endScreenPresenter.ShowScreen( "Defeat.."+ "\n You wandered to no avail for some time: "+ _finishTime);
    }
}
