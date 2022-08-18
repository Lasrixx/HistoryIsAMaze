using UnityEngine.Audio;
using UnityEngine;

public class SoundSystem : MonoBehaviour
{
    private SoundSystem system = null;
    private AudioSource audio;

    private void Awake()
    {
        if (system == null)
        {
            system = this;
            DontDestroyOnLoad(gameObject);
            return;
        }
        if (system == this) return;
        Destroy(gameObject);
    }
    void Start()
    {
        audio = GetComponent<AudioSource>();
        audio.Play();
    }
}
