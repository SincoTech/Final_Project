using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyAI : MonoBehaviour
{

    [SerializeField] float moveSpeed = 1f;
    private Animator anim;
    Rigidbody2D myRigidbody;
    BoxCollider2D myBoxCollider2D;


    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        myBoxCollider2D = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
     if(isFacingRight())
        {
            //Move right
            myRigidbody.velocity = new Vector2(moveSpeed, 0f);
        } 
     else
        {
            //Move left
            myRigidbody.velocity = new Vector2(-moveSpeed, 0f);
        }
    }
    
    private bool isFacingRight()
    {
        return transform.localScale.x > Mathf.Epsilon;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //Turn
        transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
    }

    // ################# Kill Player ###################

    public int respawn;

    private void OnTriggerEnter2D(Collider2D other)
    {
        //If Patrol AI collides with object with tag 'Player', LoadScene 'respawn'
        if(other.CompareTag("Player"))
        {
            SceneManager.LoadScene(respawn);
        }
    }
}
