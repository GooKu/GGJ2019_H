using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwitchTest : MonoBehaviour
{
    public void Test(string nick, string command)
    {
        Debug.Log($"{nick}, {command}");
    }

    public void TestNumber(string nick, string command, int number)
    {
        Debug.Log($"{nick}, {command}, {number}");
    }
}
