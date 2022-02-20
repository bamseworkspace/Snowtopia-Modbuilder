using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 12f;
    public float ySpeed = 15f;

    private void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);



        if (Input.GetKey(KeyCode.Q))
        {
            float Ypos = transform.position.y - ySpeed * Time.deltaTime;
            transform.position = new Vector3(transform.position.x, Ypos, transform.position.z);
        }

        if (Input.GetKey(KeyCode.E))
        {
            float Ypos = transform.position.y + ySpeed * Time.deltaTime;
            transform.position = new Vector3(transform.position.x, Ypos, transform.position.z);
        }
    }
}
