using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lettuceRoll : MonoBehaviour
{
    public GameObject lettuce;
    public Animator anim;
    public Transform spawn;

    GameObject spawnedLettuce;
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
            if (spawnedLettuce == null)
            {
                GetComponent<AudioSource>().Play();
                anim.SetBool("grow", true);
            }
            StartCoroutine(stopGrateSpawn());
        }

    }

    IEnumerator stopGrateSpawn()
    {
        yield return new WaitForSeconds(.1f);
        anim.SetBool("grow", false);
        if (spawnedLettuce == null)
        {
            spawnedLettuce = Instantiate(lettuce, spawn.position, spawn.rotation);

        }
        yield return new WaitForSeconds(1.3f);
       
    }
}
