using UnityEngine;

[RequireComponent(typeof(Objectpool))]
[RequireComponent(typeof(Spawner))]
[RequireComponent(typeof(Timer))]
public class Relative : MonoBehaviour
{

#region Ref

    [Header("Internal Ref")]
    [SerializeField] private Transform _transform;
    [SerializeField] private Objectpool _redEnvelopePool;
    public Objectpool RedEnvelopePool { get{ return _redEnvelopePool; } }

    [SerializeField] private Spawner _spawner;
    [SerializeField] private Timer _timer;
    
#endregion

#region Val

    [Header("Produce Val")]
    [SerializeField] private Vector2 _produceIntervalRange;
    [SerializeField] private Vector2 _produceRadiusRange;
    
#endregion

#region Events
    
    public event Observer._nullDelegate OnProduce;

#endregion

#region Monos

    private void Awake(){

        // Initial Ref
        _transform = transform;
        _redEnvelopePool = GetComponent<Objectpool>();
        _spawner = GetComponent<Spawner>();
        _timer = GetComponent<Timer>();
    }

    private void Start(){

        // Subscription
        InputManager.Instance.OnEKeyDown += Produce;
        _timer.OnTimeIsOut += () => { Produce();
                                      _timer.Current = Random.Range(_produceIntervalRange.x, _produceIntervalRange.y); };
        _spawner.OnSpawn += () => { _timer.Current = Random.Range(_produceIntervalRange.x, _produceIntervalRange.y);
                                    _timer.IsStop = false; };
        _spawner.OnRuin += () => _timer.IsStop = true;
    }
    
#endregion

#region Methods

    private void Produce(){

        OnProduce?.Invoke();
        RedEnvelope _envelope = _redEnvelopePool.Spawn().GetComponent<RedEnvelope>();
        float _angle = Random.Range(0.0f, 2.0f);
        Vector3 position = _transform.position+ 
                           new Vector3(Mathf.Sin(_angle), 
                                       0, 
                                       Mathf.Cos(_angle)).normalized* 
                           Random.Range(_produceRadiusRange.x, _produceRadiusRange.y);
        _envelope.Generate(position);
    }
    
#endregion

}
