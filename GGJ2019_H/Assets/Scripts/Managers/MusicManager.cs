using UnityEngine;

public class MusicManager : Singleton<MusicManager>
{

#region Ref

    [Header("Internal Ref")]
    [SerializeField] private AudioSource _beginSource;
    [SerializeField] private AudioSource _repeatSource;
    [SerializeField] private AudioSource _audioSource;

    [Header("External Ref")]
    [SerializeField] private AudioClip _begin;
    [SerializeField] private AudioClip _repeat;
    [SerializeField] private AudioClip _childScared;
    [SerializeField] private AudioClip _moneyCollect;

    #endregion

    #region Monos

    private void Awake(){

        // Initial Ref
        _beginSource = GetComponents<AudioSource>()[0];
        _repeatSource = GetComponents<AudioSource>()[1];
        _audioSource = GetComponents<AudioSource>()[2];
        _begin = Resources.Load("Audios/Begin") as AudioClip;
        _repeat = Resources.Load("Audios/Repeat") as AudioClip;
        _childScared = Resources.Load("Audios/ChildScared") as AudioClip;
        _moneyCollect = Resources.Load("Audios/MoneyCollect") as AudioClip;
    }

    private void Start() {

        // Initial music
        _beginSource.clip = _begin;
        _repeatSource.clip = _repeat;
        _repeatSource.loop = true;
        Begin();
        Invoke("Repeat", _begin.length);
    }
    
#endregion

#region Methods

    private void Begin(){

        _beginSource.Play();
    }

    private void Repeat(){

        _repeatSource.Play();
    }

    public void ChildScared()
    {
        _audioSource.clip = _childScared;
        _audioSource.Play();
    }

    public void MoneyCollect()
    {
        _audioSource.clip = _moneyCollect;
        _audioSource.Play();
    }
    #endregion

}
