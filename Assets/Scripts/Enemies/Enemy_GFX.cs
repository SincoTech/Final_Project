using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using UnityEngine.SceneManagement;

public class Enemy_GFX : MonoBehaviour
{
    public AIPath aiPath;


    // Update is called once per frame
    void Update()
    {
        if(aiPath.desiredVelocity.x >= 0.01f)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        else if (aiPath.desiredVelocity.x <= -0.01f)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
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
