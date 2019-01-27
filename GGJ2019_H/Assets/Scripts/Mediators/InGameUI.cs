using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class InGameUI : Singleton<InGameUI>
{

#region Ref

    [Header("Internal Ref")]
    [SerializeField] private Transform _transform;
    [SerializeField] private Text _motherName;
    [SerializeField] private Text _mothersMoney;
    [SerializeField] private Text _child0Name;
    [SerializeField] private Text _child0Money;
    [SerializeField] private Text _child1Name;
    [SerializeField] private Text _child1Money;
    [SerializeField] private Text _child2Name;
    [SerializeField] private Text _child2Money;

#endregion

#region Val

    [SerializeField] private List<string> _names = new List<string>(){ "Mother", "Child0", "Child1", "Child2" };
    public List<string> Names => _names;
    
#endregion

#region Monos

    private void Awake(){

        // Initial Ref
        _transform = transform;
        _motherName = _transform.GetChild(0).Find("Name").GetComponent<Text>();
        _mothersMoney = _transform.GetChild(0).Find("Money").GetComponent<Text>();
        _child0Name = _transform.GetChild(1).Find("Name").GetComponent<Text>();
        _child0Money = _transform.GetChild(1).Find("Money").GetComponent<Text>();
        _child1Name = _transform.GetChild(2).Find("Name").GetComponent<Text>();
        _child1Money = _transform.GetChild(2).Find("Money").GetComponent<Text>();
        _child2Name = _transform.GetChild(3).Find("Name").GetComponent<Text>();
        _child2Money = _transform.GetChild(3).Find("Money").GetComponent<Text>();
    }

    private void Start() {

        // Subscription
        GameManager.Instance.OnUpdate += UpdateMoney;
        _motherName.text = _names[0];
        _child0Name.text = _names[1];
        _child1Name.text = _names[2];
        _child2Name.text = _names[3];
    }
    
#endregion

#region Methods

    private void UpdateMoney(){

        _mothersMoney.text = CharacterManager.Instance.GetMother[0].Property.ToString();
        _child0Money.text = CharacterManager.Instance.Children[0].Property.ToString()+ "/"+ 
                            CharacterManager.Instance.Children[0].Save.ToString();
        _child1Money.text = CharacterManager.Instance.Children[1].Property.ToString()+ "/"+ 
                            CharacterManager.Instance.Children[1].Save.ToString();
        _child2Money.text = CharacterManager.Instance.Children[2].Property.ToString()+ "/"+ 
                            CharacterManager.Instance.Children[2].Save.ToString();
    }
    
#endregion

}
