using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lettuceRun : MonoBehaviour
{
    public SphereCollider trigger;


    public Rigidbody rb;
    public Transform player;

    public float Speed = 60;
    public float topSpeed = 12;

    public float Drag = 0.98f;

    public float Traction = 1;

    public float steerAngle = 45;

    private Vector3 moveForce;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        StartCoroutine(enableTrigger());
    }

    // Update is called once per frame
    void Update()
    {
        float scaleSpeed = 10/(-Vector3.Distance(transform.position, player.position) + 1);

        moveForce += transform.forward * Speed * scaleSpeed * Time.deltaTime;

        rb.position += moveForce * Time.deltaTime;

        transform.LookAt(new Vector3(player.position.x, transform.position.y, player.position.z));

        moveForce *= Drag;
        moveForce = Vector3.ClampMagnitude(moveForce, topSpeed);

        moveForce = Vector3.Lerp(moveForce.normalized, transform.forward, Traction * Time.deltaTime) * moveForce.magnitude;

    }
    IEnumerator enableTrigger()
    {
        yield return new WaitForSeconds(1);
        trigger.enabled = true;
        yield return new WaitForSeconds(5);
        Destroy(this.gameObject);
    }
}
