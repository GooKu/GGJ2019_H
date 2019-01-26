using UnityEngine;

[RequireComponent(typeof(Timer))]
public class Relative : MonoBehaviour
{

#region Ref

    [Header("Internal Ref")]
    [SerializeField] private Transform _transform;
    [SerializeField] private Spawner _spawner;
    [SerializeField] private Timer _timer;
    
#endregion

#region Val

    [Header("Exist Val")]
    [SerializeField] private Vector2 _respawnDurationRange;
    public float RespawnDuration { get{ return Random.Range(_respawnDurationRange.x, 
                                                            _respawnDurationRange.y); }}
    
#endregion

#region Monos

    private void Awake(){

        // Initial Ref
        _transform = transform;
        _spawner = GetComponent<Spawner>();
        _timer = GetComponent<Timer>();
    }

    private void Start(){

        // Subscription
        _timer.OnTimeIsOut += Spawn;
    }

    private void OnTriggerEnter(Collider other){

        if (other.gameObject.CompareTag("Child")){

            Ruin();
        }
    }
    
#endregion

#region Methods

    public void Spawn(){
        
        _spawner.Spawn(_transform.position);
        _timer.IsStop = true;
    }

    private void Ruin(){

        _spawner.Ruin();
        _timer.Current = RespawnDuration;
        _timer.IsStop = false;
    }

    public void Stop(){

        _timer.IsStop = true;
    }
    
#endregion

}
