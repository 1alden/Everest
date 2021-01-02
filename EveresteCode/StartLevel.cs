using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartLevel : MonoBehaviour
{
    AudioSource source;
    public float timeToSpawnLevel;

    public AudioClip startLevel;

    public string sceneName;
    public GameObject startImage;
    public GameObject startText;
    public GameObject startPart;

    private void Start()
    {
        source = GetComponent<AudioSource>();
        PlayerPrefs.SetInt(SceneManager.GetActiveScene().name, 1);
        startImage.SetActive(true);
    }
   private void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {

            source.clip = startLevel;
            source.Play();
            startImage.SetActive(false);
            startText.SetActive(false);
            startPart.SetActive(false);
            Invoke("StartGame", timeToSpawnLevel);
           
        }
    }
    void StartGame()
    {
        SceneManager.LoadScene(sceneName);
    }
   
}
