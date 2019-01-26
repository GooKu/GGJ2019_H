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
    public event Observer._nullDelegate OnEKeyDown;
    public event Observer._nullDelegate OnRKeyDown;
    public event Observer._nullDelegate OnCKeyDown;
    public event Observer._nullDelegate OnMKeyDown;
    public event Observer._nullDelegate OnPKeyDown;

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
        if (Input.GetKeyDown(KeyCode.E)) OnEKeyDown?.Invoke();
        if (Input.GetKeyDown(KeyCode.R)) OnRKeyDown?.Invoke();
        if (Input.GetKeyDown(KeyCode.C)) OnCKeyDown?.Invoke();
        if (Input.GetKeyDown(KeyCode.M)) OnMKeyDown?.Invoke();
        if (Input.GetKeyDown(KeyCode.P)) OnPKeyDown?.Invoke();
    }
    
#endregion

}
