﻿using System;
using UnityEngine;
using UnityEngine.AI;
using Random = System.Random;

public class Cop : MonoBehaviour
{
    [SerializeField]
    private NavMeshAgent _agent;

    [SerializeField]
    private float _moveRadius = 25f;

    [SerializeField]
    private float _targetRadius = 15f;
    
    [SerializeField] private float _minWaitDelay = 0.5f;
    
    [SerializeField] private float _maxWaitDelay = 2f;

    [SerializeField] private LayerMask _targetLayer;
    
    private Vector3 _startPos;
    
    private bool _waitingForPath = false;

    private Transform _target;

    [SerializeField] private float _killRadius = 3.0f;
    
    void Start()
    {
        _startPos = transform.position;
        GetNewDesination();
        InvokeRepeating(nameof(CheckForTargets), 1f, 1f);
    }

    // Update is called once per frame
    void Update()
    {

        if (_target != null)
        {
            _agent.SetDestination(_target.position);

            if (_agent.remainingDistance < _killRadius)
            {
                GameObject.Destroy(_target.gameObject);
            }
        }
        else
        {
            if (!_waitingForPath && !_agent.pathPending)
            {
                if (_agent.remainingDistance <= _agent.stoppingDistance)
                {
                    if (!_agent.hasPath || _agent.velocity.sqrMagnitude == 0f)
                    {
                        _waitingForPath = true;
                        Invoke(nameof(GetNewDesination), UnityEngine.Random.Range(_minWaitDelay, _maxWaitDelay));
                    }
                }
            }
        }
    }

    private void CheckForTargets()
    {
        var targets = Physics.OverlapSphere(transform.position, _targetRadius, _targetLayer);

        if (targets.Length <= 0)
        {
            return;
        }

        _target = targets[UnityEngine.Random.Range(0, targets.Length)].transform;
    }
    

    private void GetNewDesination()
    {
        _waitingForPath = false;
        if (_target != null)
        {
            
            return;
        }
        _agent.SetDestination(RandomNavmeshLocation(_moveRadius));
    }
    
    public Vector3 RandomNavmeshLocation(float radius)
    {
        Vector3 randomDirection = UnityEngine.Random.insideUnitSphere * radius;
        randomDirection += _startPos;
        NavMeshHit hit;
        Vector3 finalPosition = Vector3.zero;
        if (NavMesh.SamplePosition(randomDirection, out hit, radius, 1)) {
            finalPosition = hit.position;            
        }
        return finalPosition;
    }
}