﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotate : MonoBehaviour
{
    public float rotatespeed;
        
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0f,0f,rotatespeed);
    }
}
