using UnityEngine;

public class Rotater : MonoBehaviour {

# region Ref

	[Header("Internal Ref")]
	[SerializeField] private Transform _transform;
	public Transform _Transform{

		get{

			if (!_transform) _transform = transform;
			return _transform;
		}
	}

# endregion

# region Val

	[Header("Rotate Val")]
	[SerializeField] private Vector3 _axis;
    public Vector3 Axis { 
        
        get{ return _axis; } 
        set{ _axis = value.normalized; } 
    }

	[SerializeField] private float _speed;
    public float Speed { 
        
        get{ return _speed; } 
        set{ _speed = value; } 
    }

	[SerializeField] private bool _isWorldSpace;
    public bool IsWorldSpace { 
        
        get{ return _isWorldSpace; } 
        set{ _isWorldSpace = value; } 
    }

	[SerializeField] private bool _isStop = true;
    public bool IsStop { 
        
        get{ return _isStop; } 
        set{ _isStop = value; } 
    }

# endregion

# region Monos

	private void Awake(){

		_transform = transform;
	}

	private void Start(){

		GameManager.Instance.OnUpdate += CommonRotate;
	}

# endregion

# region Methods

	public void CommonRotate(){

		if (_isStop) return;
		if (_isWorldSpace) _Transform.rotation *= Quaternion.Euler(_axis* _speed* Time.deltaTime);
		else if (_transform != null) _Transform.localRotation *= Quaternion.Euler(_axis* _speed* Time.deltaTime);
	}

# endregion

}