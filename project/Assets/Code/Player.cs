using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float _speed;

    [SerializeField] private GameManager _manager;

    [SerializeField] private Rigidbody _body;

    [SerializeField] private Animator _anim;

    private void Start()
    {
        _anim.SetFloat("Move", 0);
    }

    void Update()
    {
        if (!Input.GetMouseButton(0))
        {
            _anim.SetFloat("Move", 0);
            return;
        }
        
        var mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hitInfo;
        
        if (!Physics.Raycast(mouseRay, out hitInfo))
        {
            _anim.SetFloat("Move", 0);
            return;
        }

        _anim.SetFloat("Move", 1);
        var mousePos = hitInfo.point;
        mousePos.y = 0;
        
        Vector3 currentPos = transform.position;
        currentPos.y = 0;

        var dir = (mousePos - currentPos).normalized;

        
        _body.MovePosition(_body.position + dir*_speed*Time.deltaTime);

        var newPos = _body.position;
        newPos.y = 0;

        
        _manager.DistanceTravelled(Vector3.Distance(currentPos, newPos));

        transform.forward = dir;
    }

    public void OnCaught()
    {
        _manager.OnCaught();
    }
}
