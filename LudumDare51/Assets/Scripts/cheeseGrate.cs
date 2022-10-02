using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class cheeseGrate : MonoBehaviour
{
    public GameObject cheese;
    public Animator anim;
    public Transform spawn;

    GameObject spawnedCheese;
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
            GetComponent<AudioSource>().Play();
            anim.SetBool("grate", true);
            StartCoroutine(stopGrateSpawn());
        }
       
    }

    IEnumerator stopGrateSpawn()
    {
        yield return new WaitForSeconds(.1f);
        anim.SetBool("grate", false);
        yield return new WaitForSeconds(1.3f);
        if (spawnedCheese == null)
        {
            spawnedCheese = Instantiate(cheese, spawn.position, spawn.rotation);
        }
    }

}
