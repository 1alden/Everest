using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchMusicOnLoad : MonoBehaviour
{
    public AudioClip newTrack;
    private AudioManager AM;

    void Start()
    {
        AM = FindObjectOfType<AudioManager>();
        if (newTrack != null)
        {
            AM.ChangeBGM(newTrack);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
