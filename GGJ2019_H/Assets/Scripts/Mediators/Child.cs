﻿using UnityEngine;

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
    public enum Key { Q, C, M, P }
    [SerializeField] private Key _key;

    [Header("Money Val")]
    [SerializeField] private int _property;
    [SerializeField] private Vector2 _earnRange;
    public int Earn{ get{ return (int)Random.Range(_earnRange.x, _earnRange.y); } }

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
        if (_key == Key.Q) InputManager.Instance.OnQKeyDown += Select;
        else if (_key == Key.C) InputManager.Instance.OnCKeyDown += Select;
        else if (_key == Key.M) InputManager.Instance.OnMKeyDown += Select;
        else if (_key == Key.P) InputManager.Instance.OnPKeyDown += Select;
        ArenaManager.Instance.OnPrepare += Aim;
        ArenaManager.Instance.OnAction += () => { Select();
                                                  _rusher.Detect(); };
    }

    private void OnTriggerEnter(Collider other){

        if (other.gameObject.CompareTag("Relative")){

            EarnMoney();
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
    }
    
#endregion

}
