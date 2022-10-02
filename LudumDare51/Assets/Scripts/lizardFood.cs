using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lizardFood : MonoBehaviour
{
    public GameObject foodOne;
    public GameObject foodTwo;
    public GameObject foodThree;

    public bool hasVisualOne;
    public bool hasVisualTwo;
    public bool hasVisualThree;

    public GameObject madeVisualOne;
    public GameObject madeVisualTwo;
    public GameObject madeVisualThree;

    public int Tomato;
    public int Dough;
    public int Cheese;
    public int Meat;
    public int Lettuce;
    GameObject[] foodToPass = new GameObject[3];

    public GameObject Pizza;
    public GameObject Burger;
    public GameObject Salad;
    public GameObject GrilledCheese;
    public GameObject BLT;
    public GameObject MegaMeat;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasVisualOne&&foodOne!=null)
        {
             madeVisualOne = Instantiate(foodOne,transform.position,transform.rotation);
            madeVisualOne.GetComponent<follow>().player = transform;
            hasVisualOne = true;
        }
        if (!hasVisualTwo && foodTwo != null)
        {
             madeVisualTwo = Instantiate(foodTwo, transform.position, transform.rotation);
            madeVisualTwo.GetComponent<follow>().player = madeVisualOne.transform;
            hasVisualTwo = true;
        }
        if (!hasVisualThree && foodThree != null)
        {
             madeVisualThree = Instantiate(foodThree, transform.position, transform.rotation);
            madeVisualThree.GetComponent<follow>().player = madeVisualTwo.transform;
            hasVisualThree = true;
        }

        if (foodOne == null)
        {
            hasVisualOne = false;
        }
        if (foodTwo == null)
        {
            hasVisualTwo = false;
        }
        if (foodThree == null)
        {
            hasVisualThree = false;
        }


        if (foodOne != null && foodTwo != null && foodThree != null)
        {
            
            foodToPass[0]=foodOne;
            foodToPass[1] = foodTwo;
            foodToPass[2] = foodThree;
            checkForCreation(foodToPass);
        }

    }

    public void triggerReset(GameObject itemToSpawn) {
       
        foodOne = null;
        foodTwo = null;
        foodThree = null;
        Destroy(madeVisualOne.gameObject);
        Destroy(madeVisualTwo.gameObject);
        Destroy(madeVisualThree.gameObject);
        foodOne = itemToSpawn;
        hasVisualOne = false;
    }
    void checkForCreation(GameObject[] foodStr)
    {
     

        for(int i = 0; i < foodStr.Length; i++)
        {
            if (foodStr[i].tag == "Tomato")
            {
                Tomato++;
            }
            if (foodStr[i].tag == "Dough")
            {
                Dough++;

            }
            if (foodStr[i].tag == "Cheese")
            {
                Cheese++;

            }
            if (foodStr[i].tag == "Meat")
            {
                Meat++;

            }
            if (foodStr[i].tag == "Lettuce")
            {
                Lettuce++;

            }
        }
        if (Tomato == 1&&Dough == 1 && Cheese == 1){
            Debug.Log("pizza");
            foodOne = null;
            foodTwo = null;
            foodThree = null;
            Destroy(madeVisualOne.gameObject);
            Destroy(madeVisualTwo.gameObject);
            Destroy(madeVisualThree.gameObject);
            foodOne = Pizza;
            hasVisualOne = false;
        }
        if (Cheese == 1 && Dough == 1 && Meat == 1)
        {
            Debug.Log("burger");
            foodOne = null;
            foodTwo = null;
            foodThree = null;
            Destroy(madeVisualOne.gameObject);
            Destroy(madeVisualTwo.gameObject);
            Destroy(madeVisualThree.gameObject);
            foodOne = Burger;
            hasVisualOne = false;
        }
        if (Tomato == 1 && Meat == 1 && Lettuce == 1)
        {
            Debug.Log("blt");
            foodOne = null;
            foodTwo = null;
            foodThree = null;
            Destroy(madeVisualOne.gameObject);
            Destroy(madeVisualTwo.gameObject);
            Destroy(madeVisualThree.gameObject);
            foodOne = BLT;
            hasVisualOne = false;
        }
        if (Cheese == 2 && Dough == 1)
        {
            Debug.Log("Grilled Cheese");
            foodOne = null;
            foodTwo = null;
            foodThree = null;
            Destroy(madeVisualOne.gameObject);
            Destroy(madeVisualTwo.gameObject);
            Destroy(madeVisualThree.gameObject);
            foodOne = GrilledCheese;
            hasVisualOne = false;
        }
        if (Tomato == 1 && Lettuce == 2)
        {
            Debug.Log("salad");
            foodOne = null;
            foodTwo = null;
            foodThree = null;
            Destroy(madeVisualOne.gameObject);
            Destroy(madeVisualTwo.gameObject);
            Destroy(madeVisualThree.gameObject);
            foodOne = Salad;
            hasVisualOne = false;
        }
        if (Meat == 3)
        {
            Debug.Log("MEAT");
            foodOne = null;
            foodTwo = null;
            foodThree = null;
            Destroy(madeVisualOne.gameObject);
            Destroy(madeVisualTwo.gameObject);
            Destroy(madeVisualThree.gameObject);
            foodOne = MegaMeat;
            hasVisualOne = false;
        }

        Tomato = 0;
        Dough = 0;
        Cheese = 0;
        Meat = 0;
        Lettuce = 0;
    }
}
