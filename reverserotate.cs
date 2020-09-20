using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class reverserotate : MonoBehaviour
{
    public float rotatespeed;
    void Update()
    {
        transform.Rotate(0f, 0f, -rotatespeed);
        
}
}
