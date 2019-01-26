using UnityEngine;


[RequireComponent(typeof(Timer))]
public class ArenaManager : Singleton<ArenaManager>
{
#region Ref
    
    [Header("Internal Ref")]
    [SerializeField] private Timer _arenaTimer;
    [SerializeField] private Timer _prepareTimer;
    [SerializeField] private Timer _actionTimer;

#endregion

#region  Val
    
    [Header("Timer Val")]
    [SerializeField] private float _gameTime;
    public float ArenaTime => _gameTime;
    [SerializeField] private float _prepareTime;
    [SerializeField] private float _actionTime;

#endregion

#region  Events

    public event Observer._nullDelegate OnStartGame;
    public event Observer._nullDelegate OnPrepare;
    public event Observer._nullDelegate OnAction;
    public event Observer._nullDelegate OnEndGame;

#endregion

#region Monos

    private void Awake(){

        // Initial Ref
        _arenaTimer = GetComponents<Timer>()[0];
        _prepareTimer = GetComponents<Timer>()[1];
        _actionTimer = GetComponents<Timer>()[2];
    }

    private void Start(){

        // Subscription
        InputManager.Instance.OnWKeyDown += StartGame;
        // InputManager.Instance.OnWKeyDown += Action;
        _arenaTimer.OnTimeIsOut += EndGame;
        _prepareTimer.OnTimeIsOut += Action;
        _actionTimer.OnTimeIsOut += Prepare;
    }
    
#endregion

#region  Methods

    public void StartGame(){

        _arenaTimer.Current = _gameTime;
        _arenaTimer.IsStop = false;
        Prepare();
        OnStartGame?.Invoke();
    }

    public void Action(){

        _actionTimer.Current = _actionTime;
        _actionTimer.IsStop = false;
        OnAction?.Invoke();
    }

    public void Prepare(){

        _prepareTimer.Current = _prepareTime;
        _prepareTimer.IsStop = false;
        OnPrepare?.Invoke();
    }

    private void EndGame(){

        _prepareTimer.IsStop = true;
        _actionTimer.IsStop = true;
        OnEndGame?.Invoke();
    }
    
#endregion

}
