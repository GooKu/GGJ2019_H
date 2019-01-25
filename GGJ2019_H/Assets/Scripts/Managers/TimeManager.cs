using UnityEngine;

public class TimeManager : Singleton<TimeManager> {

# region Val

	[Header("Time val")]
	[SerializeField] private float _deltaTime;
	public float DeltaTime { get{ return _deltaTime; } }
	
	[SerializeField] private float _unscaleDeltaTime;
	public float UnScaleDeltaTime { get{ return _unscaleDeltaTime; } }

# endregion

#region Monos

    private void Start(){

        // Subscription
        GameManager.Instance.OnUpdate += () => { _deltaTime = Time.deltaTime;
												 _unscaleDeltaTime = Time.unscaledDeltaTime; };
    }
    
#endregion

}