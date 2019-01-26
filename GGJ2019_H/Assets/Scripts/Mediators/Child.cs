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
    [SerializeField] private ParticleSystem _earnEffect;
    [SerializeField] private ParticleSystem _lostEffect;
    [SerializeField] private ParticleSystem _saveEffect;

#endregion

#region Val

    [Header("Rush Val")]
    [SerializeField] private float _turningSpeed;
    public enum Key { Q, C, M, P }
    [SerializeField] private Key _key;

    [Header("Money Val")]
    [SerializeField] private int _property;
    public int Property => _property;
    [SerializeField] private int _save;
    public int Save => _save;

    [SerializeField] private Vector2 _earnRange;
    public int Earn{ get{ return (int)Random.Range(_earnRange.x, _earnRange.y); } }

    [SerializeField] private int _lost;

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
        _earnEffect = _transform.Find("Earn").GetComponent<ParticleSystem>();
        _lostEffect = _transform.Find("Lost").GetComponent<ParticleSystem>();
        _saveEffect = _transform.Find("Save").GetComponent<ParticleSystem>();
    }

    private void Start(){

        // Subscription
        // InputManager.Instance.OnQKeyDown += Aim;
        ArenaManager.Instance.OnEndGame += () => _rotater.IsStop = true;
        if (_key == Key.Q) InputManager.Instance.OnQKeyDown += Select;
        else if (_key == Key.C) InputManager.Instance.OnCKeyDown += Select;
        else if (_key == Key.M) InputManager.Instance.OnMKeyDown += Select;
        else if (_key == Key.P) InputManager.Instance.OnPKeyDown += Select;
        ArenaManager.Instance.OnPrepare += Aim;
        ArenaManager.Instance.OnAction += () => { Select();
                                                  _rusher.Detect(); };
    }

    private void OnTriggerEnter(Collider other){

        if (other.gameObject.CompareTag("Treasure")){

            _save += _property;
            _property = 0;
            _saveEffect.Play();
        }

        if (other.gameObject.CompareTag("Relative")){

            EarnMoney();
        }

        if (other.gameObject.CompareTag("Mother")){

            if (_property > _lost){

                other.gameObject.GetComponent<Mother>().Stole(_lost);
                _property -= _lost;
            }
            else{
                
                other.gameObject.GetComponent<Mother>().Stole(_property);
                _property = 0;
            }
        }
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

    public void EarnMoney(){

        _property += Earn;
        _earnEffect.Play();
        Debug.Log(_earnEffect.isPlaying);
    }

    public void LostMoney(int money){

        _property -= money;
        _lostEffect.Play();
        if (_property < 0) _property = 0;
    }
    
#endregion

}
