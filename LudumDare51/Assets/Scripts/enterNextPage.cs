using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class enterNextPage : MonoBehaviour
{
    public bool lastScene = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.RightShift))
        {
            if (!lastScene)
            {
                Debug.Log("clicked");
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
            else
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
            }
        }
        if (Input.GetKey(KeyCode.Escape)&&lastScene)
        {
            Application.Quit();
        }
        if (Input.GetKeyUp(KeyCode.LeftShift) && lastScene)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 4);
        }
    }
}
