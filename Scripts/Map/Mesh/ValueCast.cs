using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ValueCast : MonoBehaviour
{
    public MapMeshGenerator mpg;

    public Slider slider;

    void Update()
    {
        mpg.Multi = slider.value;
    }
}
