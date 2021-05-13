using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class PlayerControl : MonoBehaviour
{
    public float movementSpeed = 10;
    public float turningSpeed = 60;
    public bool isGrounded;
    public static float vertical, horizontal;

    public Transform bull,pivotPos;
  
    void OnCollisionEnter()
    {
        isGrounded = true;
    }
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            isGrounded = false;
            GetComponent<Rigidbody>().AddForce(new Vector3(0, 500, 0));

        }
        float horizontal = Input.GetAxis("Horizontal") * turningSpeed * Time.deltaTime;
        transform.Rotate(0, horizontal, 0);
        vertical = Input.GetAxis("Vertical") * movementSpeed * Time.deltaTime;
        transform.Translate(0, 0, vertical);

        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(bull, pivotPos.position, pivotPos.rotation);
           
        }
    }

 }




