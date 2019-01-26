using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net.Sockets;
using System.IO;

public class TwitchController : MonoBehaviour
{
    private TcpClient twitchClinet;
    private StreamReader reader;
    private StreamWriter writer;

    [SerializeField]
    private UnityEngine.UI.Text debugText;

    public string userName, oAuth, chanelName;

    // Start is called before the first frame update
    void Start()
    {
        Connect();
    }

    // Update is called once per frame
    void Update()
    {
        if (!twitchClinet.Connected)
        {
            Connect();
        }

        ReadChat();
    }

    private void Connect()
    {
        twitchClinet = new TcpClient("irc.chat.twitch.tv", 6667);
        reader = new StreamReader(twitchClinet.GetStream());
        writer = new StreamWriter(twitchClinet.GetStream());

        writer.WriteLine("PASS " + oAuth);
        writer.WriteLine("NICK " + userName);
        writer.WriteLine("USER " + userName + " 8 * :" + userName);
        writer.WriteLine("JOIN #" + chanelName);
        writer.Flush();
    }

    private void ReadChat()
    {
        if(twitchClinet.Available > 0)
        {
            var message = reader.ReadLine();

            if (!message.Contains("PRIVMSG")) { return; }

            var splitPoint = message.IndexOf("!", 1);
            var chatName = message.Substring(0, splitPoint);
            chatName = chatName.Substring(1);

            splitPoint = message.IndexOf(":", 1);
            message = message.Substring(splitPoint + 1);

            if (debugText)
            {
                debugText.text = message;
            }

            commandMatcher(message);
        }
    }

    private void commandMatcher(string message)
    {
        if(message == TwitchCommand.MomGo)
        {
            momGo(0);
        }else if(message.StartsWith(TwitchCommand.ChildGo)
            && message.Length == TwitchCommand.ChildGo.Length + 1)
        {
            if (!int.TryParse(message[TwitchCommand.ChildGo.Length].ToString(), out int result))
            {
                return;
            }

            ChildGo(result);
        }
    }

    private void momGo(int number)
    {
        if (number < 0) { return; }
        if (number >= CharacterManager.Instance.GetMother.Count) { return; }
        var mom = CharacterManager.Instance.GetMother[number];
        mom.Select();
    }

    public void ChildGo(int number)
    {
        Debug.Log($"Child Go:{number}");
        if (number < 0) { return; }

        if (number >= CharacterManager.Instance.Children.Count) { return; }

        var child = CharacterManager.Instance.Children[number];

        child.Select();
    }

}
