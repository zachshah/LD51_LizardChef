using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cam : MonoBehaviour
{
    public float camSpeed;
    public float fireTime;
    public GameObject flashToShoot;
    public Transform cameraSpawn;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(fireShots());
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, 1, 0) * camSpeed * Time.deltaTime); 
    }

    IEnumerator fireShots()
    {
        while (1 == 1)
        {
            yield return new WaitForSeconds(fireTime);
            Instantiate(flashToShoot, cameraSpawn.position, cameraSpawn.rotation);
            GetComponent<AudioSource>().Play();

        }
    }
}
