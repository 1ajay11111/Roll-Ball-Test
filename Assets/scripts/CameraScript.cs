using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public Transform target;
    void Start()
    {
        
    }

    
    void Update()
    {
        transform.LookAt(target);
    }
}
