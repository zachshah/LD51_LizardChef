using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meatGen : MonoBehaviour
{
    public GameObject meat;
    public Animator anim;
    public Transform spawn;

    GameObject spawnedMeat;
    public CapsuleCollider glassJar;
    bool triggeredJarClose;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectWithTag("Player").GetComponent<lizardController>().isDashing == true)
        {
            glassJar.enabled = false;

        }
        else
        {
            if (!triggeredJarClose)
            {
                triggeredJarClose = true;
                StartCoroutine(closeJar());

            }

        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (spawnedMeat == null)
            {
                GetComponent<AudioSource>().Play();
                anim.SetBool("gen", true);
            }
            StartCoroutine(stopGenSpawn());
        }

    }

    IEnumerator stopGenSpawn()
    {
        yield return new WaitForSeconds(.1f);
        anim.SetBool("gen", false);
        yield return new WaitForSeconds(1.1f);
        if (spawnedMeat == null)
        {
            spawnedMeat = Instantiate(meat, spawn.position, spawn.rotation);
        }
    }
    IEnumerator closeJar()
    {
        yield return new WaitForSeconds(.4f);
        glassJar.enabled = true;
        triggeredJarClose = false;
    }
    }
