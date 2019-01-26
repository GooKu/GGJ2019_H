using System.Collections.Generic;
using UnityEngine;

public class Objectpool : MonoBehaviour {

# region Ref

	[Header("Internal")]
	[SerializeField] private Transform _transform;
	
	[SerializeField] private List<GameObject> _storing = new List<GameObject>();
	public List<GameObject> Storing { get{ return _storing; } }
	
	[SerializeField] private List<GameObject> _using = new List<GameObject>();
	public List<GameObject> Using { get{ return _using; } }

# endregion

# region Events

	public event Observer._nullDelegate OnLack;

# endregion

# region Monos

	private void Awake(){

		_transform = transform;
		_storing.Clear();
		_using.Clear();
	}

	private void Start(){

		for (int i= 0; i< _transform.childCount; i++){
			_storing.Add(_transform.GetChild(i).gameObject);
		}
	}

# endregion

# region Methods

	public GameObject Spawn(){

		lock (_storing){
			lock (_using){

				if (_storing.Count <= 0){

					OnLack?.Invoke();
					return null;
				}

				GameObject _object = _storing[0];
				_using.Add(_object);
				_storing.Remove(_object);
				return _object;
			}
		}
	}

	public void Recycle(GameObject target){

		lock (_storing){
			lock (_using){

				_storing.Add(target);
				_using.Remove(target);
			}
		}
	}
	public void Clear(GameObject target){

		lock (_storing){
			lock (_using){

				_storing.Clear();
				_using.Clear();
				for (int i = 0; i< _transform.childCount; i++){
					Destroy(_transform.GetChild(i).gameObject);
				}
			}
		}
	}

# endregion

}