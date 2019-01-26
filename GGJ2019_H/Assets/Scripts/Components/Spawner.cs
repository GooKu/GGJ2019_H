using UnityEngine;
using System.Collections.Generic;

public class Spawner : MonoBehaviour
{

#region Ref

    [Header("Internal Ref")]
    [SerializeField] private GameObject _gameObject;
    [SerializeField] private Transform _tranform;
    
#endregion

#region Val

    [Header("Spawn Val")]
    [SerializeField] private List<Transform> _points = new List<Transform>();
    
#endregion

#region Event

    public event Observer._nullDelegate OnSpawn;
    public event Observer._nullDelegate OnRuin;
    
#endregion

#region Monos
    
    private void Awake(){

        // Initial Ref
        _gameObject = gameObject;
        _tranform = transform;
    }

    private void Start(){
        
        // Subscription
    }

#endregion

#region Methods

    public void Spawn(){

        int _index = Random.Range(0, _points.Count);
        Vector3 _point = new Vector3( _points[_index].position.x,
                                      0, 
                                      _points[_index].position.z) ;
        _tranform.position = _point;
        _gameObject.SetActive(true);
        OnSpawn?.Invoke();
    }

    private void Ruin(){

        _gameObject.SetActive(false);
        OnRuin?.Invoke();
    }
    
#endregion

}
