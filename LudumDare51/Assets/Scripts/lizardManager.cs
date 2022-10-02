using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class lizardManager : MonoBehaviour
{
    public int stress;
    public int maxStress = 10;

    public int Timer = 10;
    public float timerStep=3;
    public Text timerText;

    public string desiredFood;
    public float desiredFoodNum;

    public Animator cardAnim;
    public float blendVal;
    public float blendSpeed;

    public AudioSource clockTick;
    public AudioSource success;
    public AudioSource fail;

    public Image battery;

    public GameObject camShot;

  

    private void Start()
    {
        rollDesiredFood(6);
    }
    void Awake()
    {
        StartCoroutine(startTimer());
    }

    // Update is called once per frame
    void Update()
    {
        timerStep = (2.4f / -10f) * stress+3;
        timerText.text = Timer + "";
        //Animator.StringToHash("whichOrder")
        blendVal=Mathf.Lerp(blendVal, (desiredFoodNum-1f)/5f, blendSpeed * Time.deltaTime);

        cardAnim.SetFloat("whichOrder", blendVal);
        battery.fillAmount = (10f-stress)/10f;

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (other.gameObject.GetComponent<lizardFood>().foodOne != null)
            {
                if (other.gameObject.GetComponent<lizardFood>().foodOne.tag == desiredFood)
                {
                    lizardFood lf = other.gameObject.GetComponent<lizardFood>();
                    lf.foodOne = null;
                    lf.foodTwo = null;
                    lf.foodThree = null;
                    Destroy(lf.madeVisualOne.gameObject);
                    Destroy(lf.madeVisualTwo.gameObject);
                    Destroy(lf.madeVisualThree.gameObject);

                    if (stress < 10)
                    {

                        if (Timer >= 0)
                        {
                            success.Play();
                            if (stress <= 8)
                            {
                                stress -= 2;
                            }
                            else if (stress >= 8)
                            {
                                stress--;
                            }
                            camShot.GetComponent<cam>().camSpeed++;
                            if (camShot.GetComponent<cam>().fireTime >= 2) {
                                camShot.GetComponent<cam>().fireTime--;
                            }
                           
                        }
                        else
                        {
                            fail.Play();
                            stress--;
                        }
                    }
                    Timer = 10;
                    rollDesiredFood(desiredFoodNum);
                }
            }
        }
    }

    void rollDesiredFood(float foodAvoid)
    {
        int randomNum = Random.Range(1, 7);
        while (randomNum == foodAvoid)
        {
            randomNum = Random.Range(1, 7);
        }
        foodAvoid = desiredFoodNum;
        desiredFoodNum = randomNum;
        if (randomNum == 1)
        {
            desiredFood = "Pizza";
        }
        else if (randomNum == 2)
        {
            desiredFood = "Cheeseburger";
        }
        else if (randomNum == 3)
        {
            desiredFood = "GrilledCheese";
        }
        else if (randomNum == 4)
        {
            desiredFood = "Salad";
        }
        else if (randomNum == 5)
        {
            desiredFood = "BLT";
        }
        else if (randomNum == 6)
        {
            desiredFood = "MEAT";
        }
    }


    IEnumerator startTimer()
    {
        while (Timer > -10)
        {
            yield return new WaitForSeconds(timerStep);
            Timer--;
            clockTick.Play();
            if (Timer < 0)
            {
                stress++;
            }
            timerText.text = Timer + "";
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }

}
