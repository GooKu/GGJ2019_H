using UnityEngine;

public class MusicManager : MonoBehaviour
{

#region Ref

    [Header("Internal Ref")]
    [SerializeField] private AudioSource _beginSource;
    [SerializeField] private AudioSource _repeatSource;
    [SerializeField] private AudioSource _audioSource;

    [Header("External Ref")]
    [SerializeField] private AudioClip _begin;
    [SerializeField] private AudioClip _repeat;

#endregion

#region Monos

    private void Awake(){

        // Initial Ref
        _beginSource = GetComponents<AudioSource>()[0];
        _repeatSource = GetComponents<AudioSource>()[1];
        _begin = Resources.Load("Audios/Begin") as AudioClip;
        _repeat = Resources.Load("Audios/Repeat") as AudioClip;
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
    
#endregion

}
