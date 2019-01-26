using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : Singleton<CharacterManager>
{

#region Ref

    [Header("Internal Ref")]
    [SerializeField] private Transform _transform;
    [SerializeField] private List<Mother> _mothers = new List<Mother>();
    public List<Mother> GetMother{ get{ return _mothers; } }

    [SerializeField] private List<Child> _children = new List<Child>();
    public List<Child> Children{ get{ return _children; } }

#endregion

#region Val

    [Header("Character Val")]
    [SerializeField] private int _motherNumber;
    [SerializeField] private int _childNumber;

#endregion

#region Event

    public event Observer._nullDelegate OnInitRefComplete;
    
#endregion

#region Monos

    private void Awake(){

        // Initiail Ref
        _transform = transform;
        for(int i= 0; i< _motherNumber; i++){

            _mothers.Add(_transform.GetChild(i).GetComponent<Mother>());
        }
        for (int i= _motherNumber; i< _motherNumber+ _childNumber; i++){

            _children.Add(_transform.GetChild(i).GetComponent<Child>());
        }
        OnInitRefComplete?.Invoke();
    }

    private void Start(){

        Debug.Log(_mothers[0].gameObject.name);
        Debug.Log(_children[0].gameObject.name);
        Debug.Log(_children[1].gameObject.name);
        Debug.Log(_children[2].gameObject.name);
    }
    
#endregion

}
