using UnityEngine;
using System.Collections;

public class AudioManager : MonoBehaviour {

    public static AudioManager Instance;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    public void PlaySound(AudioClip sfx)
    {
        audio.PlayOneShot(sfx);
    }
}
