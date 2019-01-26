using System.Collections.Generic;
using UnityEngine;

public class TwitchBridge : MonoBehaviour
{
    public void MomGo(string nick, string command)
    {
        if(command != TwitchCommand.MomGo) { return; }

        momGo(0);
    }

    private void momGo(int number)
    {
        if(number < 0) { return; }

        if(number >= CharacterManager.Instance.GetMother.Count) { return; }

        var mom = CharacterManager.Instance.GetMother[number];

        mom.Select();
    }

    public void ChildGo(string nick, string command, int number)
    {
        if (command != TwitchCommand.ChildGo) { return; }

        if (number < 0) { return; }

        if (number >= CharacterManager.Instance.Children.Count) { return; }

        var child = CharacterManager.Instance.Children[number];

        child.Select();


    }


}
