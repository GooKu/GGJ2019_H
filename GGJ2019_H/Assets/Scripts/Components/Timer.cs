using UnityEngine;

public class Timer : MonoBehaviour {

# region Val

	[SerializeField] private float _current;
    public float Current { 
        
        get{ return _current; } 
        set{ Cal(value- _current); } 
    }

	[SerializeField] private float _speed = 1;
    public float Speed { 
        
        get{ return _speed; } 
        set{ _speed = value; } 
    }

	[SerializeField] private bool _isUnscale;
    public bool IsUnscale { 
        
        get{ return _isUnscale; } 
        set{ _isUnscale = value; } 
    }

	[SerializeField] private bool _isStop;
    public bool IsStop { 
        
        get{ return _isStop; } 
        set{ _isStop = value; } 
    }

	[SerializeField] private bool _isOut;
    public bool IsOut { 
        
        get{ return _isOut; } 
        set{ _isOut = value; } 
    }

# endregion

# region Events

	public event Observer._nullDelegate OnTimeChange;
	public event Observer._nullDelegate OnTimeIsOut;

# endregion
	
# region Monos

	private void Start () {
		
		// Subscription
		GameManager.Instance.OnUpdate += CommonCount;
	}

# endregion

# region Time count

	private void CommonCount(){
		if (_isStop) return;
		else if (_isUnscale) Cal(-TimeManager.Instance.UnScaleDeltaTime * _speed);
		else Cal(-TimeManager.Instance.DeltaTime* _speed);
	}

	public void Cal(float value){
		
		if (_current + value <= 0){

			_isOut = true;
			if (_current > 0) {
				
				_current = 0;
				OnTimeChange?.Invoke();
				OnTimeIsOut?.Invoke();
			}
		}
		else {
			
			_current += value;
			OnTimeChange?.Invoke();
		}

		if (_current == 0) _isOut = true;
		else _isOut = false;
	}
	
	public void Clear() { Cal(-_current); }

# endregion
}