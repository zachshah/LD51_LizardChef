using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doughRoll : MonoBehaviour
{
    public GameObject dough;
    public Animator anim;
    public int doughRollAmnt = 0;
    public Material redZone;
    public Material yellowZone;
    public Material greenZone;
    public GameObject indicator;
    bool canRoll = true;
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
            if (doughRollAmnt == 2)
            {
                lizardFood lf = other.gameObject.GetComponent<lizardFood>();
                if (lf.foodOne == null)
                {
                    lf.foodOne = dough;
                }
                else if (lf.foodTwo == null)
                {
                    lf.foodTwo = dough;
                }
                else if (lf.foodThree == null)
                {
                    lf.foodThree = dough;
                }
                else
                {
                    lf.triggerReset(dough);
                }
                doughRollAmnt = 0;
                indicator.GetComponent<Renderer>().material = redZone;
                anim.SetBool("roll", true);
                StartCoroutine(GiveDough());
              
            }
            else 
            {
                if (canRoll)
                {
                    anim.SetBool("roll", true);
                    StartCoroutine(Roll());
                    
                    canRoll = false;
                }
                
            }
        }
       
    }
    IEnumerator Roll()
    {
        yield return new WaitForSeconds(.1f);
        anim.SetBool("roll", false);
        doughRollAmnt++;
        canRoll = true;
       
        if (doughRollAmnt == 1)
        {
            indicator.GetComponent<Renderer>().material = yellowZone;
        }
        if (doughRollAmnt == 2)
        {
            indicator.GetComponent<Renderer>().material = greenZone;
        }
    }
    IEnumerator GiveDough()
    {
        yield return new WaitForSeconds(.1f);
        anim.SetBool("roll", false);
    }
    }
