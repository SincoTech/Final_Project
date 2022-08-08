using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bat_AI : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // ################# Kill Player ###################

    public int respawn;

    private void OnTriggerEnter2D(Collider2D other)
    {
        //If Patrol AI collides with object with tag 'Player', LoadScene 'respawn'
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene(respawn);
        }
    }

}
