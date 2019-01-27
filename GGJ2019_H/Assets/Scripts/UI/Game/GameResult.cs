using UnityEngine;
using UnityEngine.UI;

public class GameResult : MonoBehaviour
{
    [SerializeField]
    private GameObject gameResultUI;
    [SerializeField]
    private Text score;
    [SerializeField]
    private Image winnerImage;

    void Start()
    {
        ArenaManager.Instance.OnEndGame += endGameHandle;
        gameResultUI.GetComponentInChildren<Button>().onClick.AddListener(returnToHamePage);
    }

    private void endGameHandle()
    {
        gameResultUI.SetActive(true);

        int motherTotal = 0;

        foreach(var mom in CharacterManager.Instance.GetMother)
        {
            motherTotal += mom.Property;
        }

        int childTotal = 0;

        foreach (var child in CharacterManager.Instance.Children)
        {
            childTotal += child.Save;
        }

        if(motherTotal >= childTotal)
        {
            motherWin();
            return;
        }

        Child winner = null;
        int winnerMoney = 0;

        for(int i = 0; i < CharacterManager.Instance.Children.Count; i++)
        {
            var child = CharacterManager.Instance.Children[i];
            if (child.Save > winnerMoney)
            {
                winner = child;
                winnerMoney = child.Save;
            }
        }

        childWin(winner);
    }

    private void motherWin()
    {
        var mom = CharacterManager.Instance.GetMother[0];

        score.text = mom.Property.ToString();

        winnerImage.sprite = mom.GetComponentInChildren<SpriteRenderer>().sprite;
    }

    private void childWin(Child winner)
    {
        score.text = winner.Save.ToString();

        winnerImage.sprite = winner.GetComponentInChildren<SpriteRenderer>().sprite;
    }

    private void returnToHamePage()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("HomePage");
    }
}
