using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class giveableItem : MonoBehaviour
{
    public GameObject itemToSpawn;
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
             lizardFood lf = other.gameObject.GetComponent<lizardFood>();
            if (lf.foodOne == null)
            {
                lf.foodOne = itemToSpawn;
            }else if (lf.foodTwo == null)
            {
                lf.foodTwo = itemToSpawn;
            }
            else if (lf.foodThree == null)
            {
                lf.foodThree = itemToSpawn;
            }
            else
            {
              lf.triggerReset(itemToSpawn);
            }
            Destroy(this.gameObject);
        }
    }
}
