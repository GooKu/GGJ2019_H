using UnityEngine;
using UnityEngine.SceneManagement;

public class HomePage : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("Prototype");
        Debug.Log("Start");
    }

    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Exit");
    }
}
