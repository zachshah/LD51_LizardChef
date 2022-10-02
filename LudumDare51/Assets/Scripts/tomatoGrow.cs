using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class tomatoGrow : MonoBehaviour
{
    public GameObject tomato;
    public Animator anim;
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
            lizardFood lf = other.gameObject.GetComponent<lizardFood>();
            if (lf.foodOne == null)
            {
                lf.foodOne = tomato;
            }
            else if (lf.foodTwo == null)
            {
                lf.foodTwo = tomato;
            }
            else if (lf.foodThree == null)
            {
                lf.foodThree = tomato;
            }
            else
            {
                lf.triggerReset(tomato);
            }
        }
        anim.SetBool("grow",true);
        StartCoroutine(stopGrow());
    }
    IEnumerator stopGrow()
    {
        yield return new WaitForSeconds(.1f);
        anim.SetBool("grow", false);
    }
}
