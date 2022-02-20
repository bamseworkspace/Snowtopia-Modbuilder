using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Mouselook : MonoBehaviour
{

    public float sev = 100f;

    public Transform body;

    public bool locked;

    float xRot = 0f;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        float MX = Input.GetAxis("Mouse X") * sev * Time.deltaTime;
        float MY = Input.GetAxis("Mouse Y") * sev * Time.deltaTime;

        xRot -= MY;
        xRot = Mathf.Clamp(xRot, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRot, 0f,0f);

        body.Rotate(Vector3.up * MX);

        if(Input.GetKeyDown(KeyCode.U))
        {
            if(locked == false)
            {
                Cursor.lockState = CursorLockMode.Locked;
                locked = true;
            }
            else
            {
                locked = false;
                Cursor.lockState = CursorLockMode.Confined;
            }
        }
    }

}
