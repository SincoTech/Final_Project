using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Code for restarting scene with 'R' key.
        bool restart = Input.GetKeyDown(KeyCode.R);

        if (restart)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
    public void restartScene()
    {
   

    // Code for restarting scene with mouse button click

       //  SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }    

}
