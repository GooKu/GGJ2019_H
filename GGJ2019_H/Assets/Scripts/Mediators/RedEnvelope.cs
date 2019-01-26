using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Timer))]
public class RedEnvelope : MonoBehaviour
{

#region Ref

    [Header("Internal Ref")]
    [SerializeField] private GameObject _gameObject;
    [SerializeField] private Transform _transform;
    [SerializeField] private SphereCollider _sphereCollider;
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private Timer _timer;

    [Header("External Ref")]
    [SerializeField] private Relative _relative;
    
#endregion

#region Val

    [Header("Envelope Val")]
    [SerializeField] private Vector2 _moneyRange;
    public int Money{ get{ return (int)Random.Range(_moneyRange.x, _moneyRange.y); } }

    [SerializeField] private float _existDuration;
    
#endregion

#region Monos

    private void Awake(){

        // Initial Ref
        _gameObject = gameObject;
        _transform = transform;
        _sphereCollider = GetComponent<SphereCollider>();
        _rigidbody = GetComponent<Rigidbody>();
        _timer = GetComponent<Timer>();
        _relative = _transform.parent.GetComponent<Relative>();
    }

    private void Start(){

        //Subscription
        _timer.OnTimeIsOut += Destroy;
    }
    
#endregion

#region Methods

    public void Generate(Vector3 position){

        _transform.position = position;
        _sphereCollider.isTrigger = true;
        _rigidbody.useGravity = false;
        _rigidbody.isKinematic = true;
        _timer.Current = _existDuration;
        _timer.IsStop = false;
        _gameObject.SetActive(true);
    }

    private void Destroy(){

        _timer.IsStop = true;
        _gameObject.SetActive(false);
        _relative.RedEnvelopePool.Recycle(_gameObject);
    }
    
#endregion

}
