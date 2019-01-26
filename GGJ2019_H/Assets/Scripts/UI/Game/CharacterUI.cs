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

    public void PCInit(Sprite character, string name, string hotKey)
    {
        characterImg.sprite = character;
        characterName.text = name;
        hotKeyText.text = $"Hot Key:{hotKey}";
    }
}
