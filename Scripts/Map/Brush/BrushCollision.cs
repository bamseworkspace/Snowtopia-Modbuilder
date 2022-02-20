using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrushCollision : MonoBehaviour
{
    public MapMeshGenerator mapmesh;

    private void OnTriggerEnter(Collider collision)
    {
        if (Input.GetMouseButton(0))
        {
            Debug.Log("Hited");

            Index index = collision.GetComponent<Index>();

            Debug.Log(index.thisindex.ToString());

            mapmesh.PointEx(index.thisindex);
        }

    }
}
