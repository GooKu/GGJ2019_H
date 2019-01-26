using UnityEngine;
using System.Collections.Generic;

public class Spawner : MonoBehaviour
{

#region Ref

    [Header("Internal Ref")]
    [SerializeField] private GameObject _gameObject;
    [SerializeField] private Transform _tranform;
    
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

    public void Spawn(Vector3 position){

        _tranform.position = position;
        _gameObject.SetActive(true);
        OnSpawn?.Invoke();
    }

    public void Ruin(){

        _gameObject.SetActive(false);
        OnRuin?.Invoke();
    }
    
#endregion

}
