using UnityEngine;

public class GameManager : Singleton<GameManager> {

# region Events

	public event Observer._nullDelegate OnFixedUpdate;
	public event Observer._nullDelegate OnUpdate;
	public event Observer._nullDelegate OnLateUpdate;

# endregion

# region Monos

	private void FixedUpdate(){ OnFixedUpdate?.Invoke(); }
	private void Update() {	OnUpdate?.Invoke(); }
	private void LateUpdate(){ OnLateUpdate?.Invoke(); }

# endregion

}