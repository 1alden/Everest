using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchMusic : MonoBehaviour
{
    public AudioClip newTrack;
    private AudioManager AM;

    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Player")
        {
            if(newTrack != null)
            {
                AM = FindObjectOfType<AudioManager>();
                AM.ChangeBGM(newTrack);
            }
           
        }
    }
}
