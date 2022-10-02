using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class tutorialManager : MonoBehaviour
{


    public AudioSource success;
    public GameObject finalTask;
    public GameObject nextTask;
    public GameObject currentTask;
    public bool canMakeBLT;
    public bool canMakeSalad;




    private void Start()
    {
        }
    void Awake()
    {
       }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (other.gameObject.GetComponent<lizardFood>().foodOne != null)
            {
                if (other.gameObject.GetComponent<lizardFood>().foodOne.tag == "Cheeseburger")
                {
                    lizardFood lf = other.gameObject.GetComponent<lizardFood>();
                    lf.foodOne = null;
                    lf.foodTwo = null;
                    lf.foodThree = null;
                    Destroy(lf.madeVisualOne.gameObject);
                    Destroy(lf.madeVisualTwo.gameObject);
                    Destroy(lf.madeVisualThree.gameObject);
                    success.Play();
                    nextTask.SetActive(true);
                    currentTask.SetActive(false);
                    canMakeBLT = true;


                }
                if (other.gameObject.GetComponent<lizardFood>().foodOne.tag == "BLT"&&canMakeBLT)
                {
                    lizardFood lf = other.gameObject.GetComponent<lizardFood>();
                    lf.foodOne = null;
                    lf.foodTwo = null;
                    lf.foodThree = null;
                    Destroy(lf.madeVisualOne.gameObject);
                    Destroy(lf.madeVisualTwo.gameObject);
                    Destroy(lf.madeVisualThree.gameObject);
                    success.Play();
                    nextTask.SetActive(false);
                    finalTask.SetActive(true);
                    canMakeSalad = true;


                }
                if (other.gameObject.GetComponent<lizardFood>().foodOne.tag == "Salad" && canMakeSalad)
                {
                    lizardFood lf = other.gameObject.GetComponent<lizardFood>();
                    lf.foodOne = null;
                    lf.foodTwo = null;
                    lf.foodThree = null;
                    Destroy(lf.madeVisualOne.gameObject);
                    Destroy(lf.madeVisualTwo.gameObject);
                    Destroy(lf.madeVisualThree.gameObject);
                    success.Play();
                    nextTask.SetActive(false);
                    finalTask.SetActive(false);
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);


                }
            }
        }
    }

  
}
