using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
   
    public GameObject chest;
    public GameObject strawberry;
    private Strawberry berry;
    private LevelManager manager;
   

    // Start is called before the first frame update
    void Start()
    {
        chest.SetActive(true);
        manager = FindObjectOfType<LevelManager>();
        berry = FindObjectOfType<Strawberry>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Opening()
    {
        StartCoroutine("Open");
    }
    public IEnumerator Open()
     
        {
            Instantiate(strawberry, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(0.1f);
        chest.SetActive(false);
        if (manager.levelReloading == true)
        {
            Debug.Log("Test");
            if (berry.isCollected == false)
            {
                chest.SetActive(true);
                
            }
        }
    }

   
}
