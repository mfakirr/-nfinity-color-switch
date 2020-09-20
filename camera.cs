using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
    public Transform ballposition;
   

    void Update()
    {
        if (ballposition.position.y < transform.position.y)
        {
            transform.position = new Vector3(transform.position.x, ballposition.position.y, transform.position.z);
        }
    }
}
