using UnityEngine;

public class GameUIProcesser : MonoBehaviour
{
    [SerializeField]
    private GameStart gameStart;

    void Start()
    {
        gameStart.gameObject.SetActive(true);
    }
}
