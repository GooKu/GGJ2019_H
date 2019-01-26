using UnityEngine;

[RequireComponent(typeof(Rotater))]
[RequireComponent(typeof(Rusher))]
public class Child : MonoBehaviour
{

#region Ref

    [Header("Internal Ref")]
    [SerializeField] private Transform _transform;
    [SerializeField] private Rotater _rotater;
    [SerializeField] private Rusher _rusher;

#endregion

#region Val

    [Header("Rush Val")]
    [SerializeField] private float _turningSpeed;

#endregion

#region Events

    private event Observer._nullDelegate OnSelect;
    
#endregion

#region Monos

    private void Awake(){

        // Initial Ref
        _transform = transform;
        _rotater = GetComponent<Rotater>();
        _rusher = GetComponent<Rusher>();
    }

    private void Start(){

        // Subscription
        // InputManager.Instance.OnQKeyDown += Aim;
        InputManager.Instance.OnWKeyDown += Select;
        ArenaManager.Instance.OnPrepare += Aim;
        ArenaManager.Instance.OnAction += () => { Select();
                                                  _rusher.Detect(); };
    }
    
#endregion

#region Methods

    // Start rotating
    private void Aim(){

        _rotater.Axis = Vector3.up;
        _rotater.Speed = _turningSpeed;
        _rotater.IsStop = false;
    }

    // Select Direction
    public void Select(){

        _rotater.IsStop = true;
        _rusher.Direction = new Vector3(_transform.forward.x, 0, _transform.forward.z).normalized;
        OnSelect?.Invoke();
    }
    
#endregion

}
