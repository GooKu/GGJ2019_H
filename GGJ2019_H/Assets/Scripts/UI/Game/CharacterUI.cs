using UnityEngine;
using UnityEngine.UI;

public class CharacterUI : MonoBehaviour
{
    [SerializeField]
    private Image characterImg;
    [SerializeField]
    private Text characterName;
    [SerializeField]
    private Text hotKeyText;
    [SerializeField]
    private Text twitchCommandText;

    public void PCInit(Sprite character, string name, string hotKey, string twitch)
    {
        characterImg.sprite = character;
        characterName.text = name;
        hotKeyText.text = $"Hot Key:{hotKey}";
        twitchCommandText.text = $"Twitch Command:{twitch}";
    }
}
