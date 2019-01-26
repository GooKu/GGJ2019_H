using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameStart : MonoBehaviour
{
    [SerializeField]
    private GameObject grid;
    [SerializeField]
    private Sprite[] sprites;
    [SerializeField]
    private ChildNumberProducter childNumberProducter;

    private string[] twitchCommand = new string[]
    {
        TwitchCommand.MomGo,
        TwitchCommand.ChildGo+" 0",
        TwitchCommand.ChildGo+" 1",
        TwitchCommand.ChildGo+" 2",
    };

    void Start()
    {
        var characterUIs = grid.GetComponentsInChildren<CharacterUI>();

        for(int i =0; i < characterUIs.Length; i++)
        {
            characterUIs[i].PCInit(sprites[i]
                , InGameUI.Instance.Names[i]
                , Enum.GetValues(typeof( Child.Key)).GetValue(i).ToString()
                , twitchCommand[i]);
        }

        GetComponent<Button>().onClick.AddListener(gameStart);
    }

    private void gameStart()
    {
        gameObject.SetActive(false);
        childNumberProducter.Product();
        ArenaManager.Instance.StartGame();
    }
}
