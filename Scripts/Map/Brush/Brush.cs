using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brush : MonoBehaviour
{
    public Transform moveThis;
    //the layers the ray can hit
    public LayerMask hitLayers;

    public bool SetTransform0;

    void Update()
    {
        Vector3 mouse = Input.mousePosition;
        Ray castPoint = Camera.main.ScreenPointToRay(mouse);
        RaycastHit hit;
        if (Physics.Raycast(castPoint, out hit, Mathf.Infinity, hitLayers))
        {
            moveThis.transform.position = hit.point;
            if (SetTransform0)
            {
                moveThis.transform.position = new Vector3(moveThis.transform.position.x, 0, moveThis.transform.position.z);
            }
        }
    }



}
