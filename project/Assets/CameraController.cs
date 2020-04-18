using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private Transform _target;

    [SerializeField]
    private Vector3 offset;
    
    
    void Update()
    {
        transform.position = _target.position + offset;
  
        transform.LookAt(_target);
    }
}
