using UnityEngine;

public class ChildNumberProducter : MonoBehaviour
{
    [SerializeField]
    private ChildNumber childNumberSample;

    public void Product()
    {
        for (int i = 0; i < CharacterManager.Instance.Children.Count; i++)
        {
            var childNumber = Instantiate(childNumberSample, transform);
            childNumber.Setting(CharacterManager.Instance.Children[i], i);
        }
    }
}
