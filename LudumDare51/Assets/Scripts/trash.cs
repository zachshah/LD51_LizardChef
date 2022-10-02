using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trash : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
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
                GetComponent<AudioSource>().Play();
                lizardFood lf = other.gameObject.GetComponent<lizardFood>();
                lf.foodOne = null;
                lf.foodTwo = null;
                lf.foodThree = null;
                Destroy(lf.madeVisualOne.gameObject);
                Destroy(lf.madeVisualTwo.gameObject);
                Destroy(lf.madeVisualThree.gameObject);
            }
               
            
        }
    }
}
