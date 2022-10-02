using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flash : MonoBehaviour
{
    public float speed;
    public Rigidbody rb;
    public bool canHit=true;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

   
    private void FixedUpdate()
    {
        rb.position += -transform.forward * speed * Time.deltaTime;

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player"&&canHit)
        {
            if (!other.gameObject.GetComponent<lizardController>().isDashing)
            {
                if (GameObject.FindGameObjectWithTag("Manager").GetComponent<lizardManager>().stress < 10)
                {
                    GameObject.FindGameObjectWithTag("Manager").GetComponent<lizardManager>().stress++;
                    GetComponent<AudioSource>().Play();
                }
               
            }
            
            canHit = false;
        }
    }
}
