using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
[RequireComponent(typeof(Rigidbody))]
public class Treasure : Singleton<Treasure>
{

#region Ref

    [Header("Internal")]
    [SerializeField] private Transform _transform;
    [SerializeField] private BoxCollider _boxCollider;
    [SerializeField] private Rigidbody _rigidbody;
    
#endregion

#region Val

    [Header("Property Val")]
    [SerializeField] private int _property;
    
#endregion

#region  Events

    public event Observer._nullDelegate OnSave;

#endregion

#region  Monos

    private void Awake(){

        _transform = transform;
        _boxCollider = GetComponent<BoxCollider>();
        _rigidbody = GetComponent<Rigidbody>();
    }
    
#endregion

#region Methods

    public void Save(int money){

        _property += money;
    }
    
#endregion

}