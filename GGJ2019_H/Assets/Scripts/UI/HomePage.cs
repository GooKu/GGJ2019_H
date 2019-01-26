using UnityEngine;
using UnityEngine.SceneManagement;

public class HomePage : MonoBehaviour
{
    public GameObject creditWindow;

    public void StartGame()
    {
        SceneManager.LoadScene("Prototype");
    }

    public void Credit()
    {
     
        creditWindow.SetActive(true);
    }

    public void ReturnMenu()
    {
        creditWindow.SetActive(false);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
