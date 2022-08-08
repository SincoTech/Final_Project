using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using UnityEngine.SceneManagement;

public class Enemy_AI_Bat : MonoBehaviour
{

    public Transform target;

    public float speed = 200;
    public float nextWayPoint = 3f;

    public Transform enemy_GFX;

    Path path;
    int currentWayPoint = 0;
    bool reachedEndOfPath = false;

    Seeker seeker;
    Rigidbody2D rigidBody;

    // Start is called before the first frame update
    void Start()
    {
        seeker = GetComponent<Seeker>();
        rigidBody = GetComponent<Rigidbody2D>();

        InvokeRepeating("PathUpdate", 0f, .5f);
    }

    void PathUpdate()
    {
        if (seeker.IsDone())
            seeker.StartPath(rigidBody.position, target.position, pathCompleted);
    }

    void pathCompleted(Path p)
    {
        if(!p.error)
        {
            path = p;
            currentWayPoint = 0;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(path == null)
        {
            return;
        }
        
        if(currentWayPoint >= path.vectorPath.Count)
        {
            reachedEndOfPath = true;
            return;
        }
        else
        {
            reachedEndOfPath = false;
        }

        Vector2 direction = ((Vector2)path.vectorPath[currentWayPoint] - rigidBody.position).normalized;
        Vector2 force = direction * speed * Time.deltaTime;

        rigidBody.AddForce(force);

        float distance = Vector2.Distance(rigidBody.position, path.vectorPath[currentWayPoint]);

        if (distance < nextWayPoint)
        {
            currentWayPoint++;
        }

        if (rigidBody.velocity.x >= 0.01f)
        {
            enemy_GFX.localScale = new Vector3(-1f, 1f, 1f);
        }
        else if (rigidBody.velocity.x <= -0.01f)
        {
            enemy_GFX.localScale = new Vector3(1f, 1f, 1f);
        }
    }



}
