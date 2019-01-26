using UnityEngine;
using UnityEngine.UI;

public class ChildNumber : MonoBehaviour
{
    [SerializeField]
    private Text number;

    private Transform child;
    private Vector3 offSet = new Vector3(0, 30, 0);

    public void Setting(Child child, int number)
    {
        this.child = child.transform;
        this.number.text = number.ToString();
    }

    private void Update()
    {
        if(child != null)
        {
            transform.position = Camera.main.WorldToScreenPoint(child.position) + offSet;
        }
    }

}
