using UnityEngine;
using DG.Tweening;

public class Rusher : MonoBehaviour
{

#region Ref

    [Header("Internal")]
    [SerializeField] private Transform _transform;

#endregion

#region Val

    [Header("Rush Val")]
    [SerializeField] private float _distance;
    [SerializeField] private float _duration;
    [SerializeField] private Vector3 _direction;
    public Vector3 Direction{ get{ return _direction; } set{ _direction = value; } }

    [SerializeField] private Vector3 _destination;

    [Header("Body Val")]
    [SerializeField] private float _bodyRadious;

#endregion

#region Events
    
    public event Observer._nullDelegate OnDetect;
    public event Observer._nullDelegate OnTeleport;

#endregion

#region Monos

    private void Awake(){

        // Initial Ref
        _transform = transform;
    }

    private void Start(){

        // Subscription
        // InputManager.Instance.OnQKeyDown += Detect;
        OnDetect += Teleport;
    }

#endregion

#region Methods

    // Detect the destination.
    public void Detect(){

        RaycastHit hit;

        if (Physics.Raycast(_transform.position, _direction, out hit, _distance, 1 << 10) && hit.collider.gameObject.CompareTag("LandScape"))
        {
            _destination = new Vector3(hit.point.x, 0, hit.point.z);
        }
        else
        {
            _destination = _transform.position+ _distance* _direction.normalized;
        }
        OnDetect?.Invoke();
    }

    private void Teleport(){

        _destination = _destination - _direction.normalized * _bodyRadious;
        _transform.DOMove(_destination, _duration)
                  .SetEase(Ease.OutCubic);
        OnTeleport?.Invoke();
    }
    
#endregion

}
