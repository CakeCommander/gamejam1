using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float _speed;
    
   


    void Update()
    {
        if (!Input.GetMouseButton(0))
        {
            return;
        }
        
        var mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hitInfo;
        
        if (!Physics.Raycast(mouseRay, out hitInfo))
        {
            return;
        }

        var mousePos = hitInfo.point;
        mousePos.y = 0;
        
        Vector3 currentPos = transform.position;
        currentPos.y = 0;

        var dir = (mousePos - currentPos).normalized;

        transform.Translate(dir*_speed*Time.deltaTime);
    }
}
