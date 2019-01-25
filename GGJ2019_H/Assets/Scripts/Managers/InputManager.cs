using UnityEngine;

public class InputManager : Singleton<InputManager>
{

#region Val
    
    [Header("Input Val")]
    private bool _isInputAvailable;
    public bool IsInputAvailable{ get{ return _isInputAvailable; } }

#endregion

# region Events

    public event Observer._nullDelegate OnQKeyDown;
    public event Observer._nullDelegate OnWKeyDown;

# endregion

#region Monos

    private void Awake(){


    }

    private void Start(){

        // Subscription
        GameManager.Instance.OnFixedUpdate += KeyboardInput;
    }
    
#endregion

#region Methods

    private void KeyboardInput(){

        if (Input.GetKeyDown(KeyCode.Q)) OnQKeyDown?.Invoke();
        if (Input.GetKeyDown(KeyCode.W)) OnWKeyDown?.Invoke();
    }
    
#endregion

}
