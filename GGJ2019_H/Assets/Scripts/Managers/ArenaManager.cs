using UnityEngine;


[RequireComponent(typeof(Timer))]
public class ArenaManager : Singleton<ArenaManager>
{
#region Ref
    
    [Header("Internal Ref")]
    [SerializeField] private Timer _prepareTimer;

    [SerializeField] private Timer _actionTimer;

#endregion

#region  Val
    
    [Header("Timer Val")]
    [SerializeField] private float _prepareTime;
    [SerializeField] private float _actionTime;

#endregion

#region  Events

    public event Observer._nullDelegate OnPrepare;
    public event Observer._nullDelegate OnAction;
    
#endregion

#region Monos

    private void Awake(){

        // Initial Ref
        _prepareTimer = GetComponents<Timer>()[0];
        _actionTimer = GetComponents<Timer>()[1];
    }

    private void Start(){

        // Subscription
        InputManager.Instance.OnQKeyDown += Prepare;
        // InputManager.Instance.OnWKeyDown += Action;
        _prepareTimer.OnTimeIsOut += Action;
        _actionTimer.OnTimeIsOut += Prepare;
    }
    
#endregion

#region  Methods

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
    
#endregion

}
