using UnityEngine;
using System.Collections.Generic;

[RequireComponent(typeof(Rotater))]
[RequireComponent(typeof(Rusher))]
[RequireComponent(typeof(Timer))]
public class Mother : MonoBehaviour
{
#region Ref

    [Header("Internal Ref")]
    [SerializeField] private Transform _transform;
    [SerializeField] private Rotater _rotater;
    [SerializeField] private Rusher _rusher;
    [SerializeField] private Timer _timer;

#endregion

#region Val

    [Header("Rush Val")]
    [SerializeField] private float _turningSpeed;
    [SerializeField] private int _rushCountMax;
    [SerializeField] private int _rushCount;
    [SerializeField] private float _rushInterval;
    [SerializeField] private List<Vector3> _directions = new List<Vector3>();

    [Header("Money Val")]
    [SerializeField] private int _property;
    public int Property => _property;

#endregion

#region Events

    private event Observer._nullDelegate OnSelect;
    private event Observer._nullDelegate OnRush;
    
#endregion

#region Monos

    private void Awake(){

        // Initial Ref
        _transform = transform;
        _rotater = GetComponent<Rotater>();
        _rusher = GetComponent<Rusher>();
        _timer = GetComponent<Timer>();
    }

    private void Start(){

        // Subscription
        // InputManager.Instance.OnQKeyDown += Aim;
        InputManager.Instance.OnQKeyDown += Select;
        ArenaManager.Instance.OnEndGame += () => { _timer.IsStop = true;
                                                   _rotater.IsStop = true; };
        ArenaManager.Instance.OnPrepare += Aim;
        ArenaManager.Instance.OnAction += Action;
        _timer.OnTimeIsOut += Rush;
    }
    
#endregion

#region Methods

    // Start rotating
    private void Aim(){

        _rotater.Axis = Vector3.up;
        _rotater.Speed = _turningSpeed;
        _rotater.IsStop = false;
        _directions.Clear();
        _rushCount = 0;
    }

    // Select Direction
    public void Select(){

        if (_directions.Count >= _rushCountMax) return;
        _directions.Add(new Vector3(_transform.forward.x, 0, _transform.forward.z).normalized);
        OnSelect?.Invoke();
        if (_directions.Count >= _rushCountMax) _rotater.IsStop = true;
    }

    // Complete Select and ready to rush
    private void Action(){

        _rotater.IsStop = true;
        for (int i= _rushCount; i< _rushCountMax; i++){

            float _angle = Random.Range(0.0f, 2.0f);
            _directions.Add(new Vector3(Mathf.Sin(_angle), 
                                       0, 
                                       Mathf.Cos(_angle)));
            OnSelect?.Invoke();
        }
        Rush();
    }

    private void Rush(){

        _rusher.Direction = _directions[_rushCount];
        _rusher.Detect();
        _rushCount += 1;

        if (_rushCount < _rushCountMax) {

            _timer.Current = _rushInterval;
            _timer.IsStop = false;
        }
        OnRush?.Invoke();
    }

    
    public void Stole(int money){

        _property += money;
    }    
    
#endregion

}
