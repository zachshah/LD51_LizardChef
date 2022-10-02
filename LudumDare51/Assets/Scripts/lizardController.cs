using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lizardController : MonoBehaviour
{
    public Rigidbody rb;

    public float Speed = 60;
    public float topSpeed = 12;

    public float Drag = 0.98f;

    public float Traction = 1;

    public float steerAngle = 45;

    public float dashTime = .3f;
    public float dashCooldown = 1.5f;
    public float dashMultiplier = 4;

    private Vector3 moveForce;

    public bool isDashing;
    private bool canDash=true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
      
        if (Input.GetKeyDown(KeyCode.Space)&&canDash==true)
        {
            StartCoroutine(Dash());
        }
    }
    private void FixedUpdate()
    {
        if (isDashing)
            moveForce += transform.forward * Speed * dashMultiplier * Time.fixedDeltaTime;
        else
            moveForce += transform.forward * Speed * Input.GetAxis("Vertical") * Time.fixedDeltaTime;


        rb.position += moveForce * Time.fixedDeltaTime;

        if (!isDashing)
            transform.Rotate(Vector3.up * Input.GetAxis("Horizontal") * moveForce.magnitude * steerAngle * Time.fixedDeltaTime);


        moveForce *= Drag;
        moveForce = Vector3.ClampMagnitude(moveForce, topSpeed);

        moveForce = Vector3.Lerp(moveForce.normalized, transform.forward, Traction * Time.fixedDeltaTime) * moveForce.magnitude;

       
    }
    IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;
        yield return new WaitForSeconds(dashTime);
        isDashing = false;
        yield return new WaitForSeconds(dashCooldown);
        canDash = true;
    }
}
