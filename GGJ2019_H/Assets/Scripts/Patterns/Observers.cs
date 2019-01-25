using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Observer : Singleton<Observer>{

    public delegate void _nullDelegate();
    public delegate void _intDelegate(int value);
    public delegate void _floatDelegate(float value);
    public delegate void _vector3Delegate(Vector3 value);
}