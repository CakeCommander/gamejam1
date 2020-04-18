using System;
using UnityEngine;
using UnityEngine.AI;
using Random = System.Random;

public class Character : MonoBehaviour
{
    [SerializeField]
    private NavMeshAgent _agent;

    [SerializeField]
    private float _moveRadius = 25f;

    [SerializeField] private float _minWaitDelay = 0.5f;
    
    [SerializeField] private float _maxWaitDelay = 2f;

    private Vector3 _startPos;
    
    private bool _waitingForPath = false;
    void Start()
    {
        _startPos = transform.position;
        GetNewDesination();
    }

    // Update is called once per frame
    void Update()
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

    private void GetNewDesination()
    {
        _agent.SetDestination(RandomNavmeshLocation(_moveRadius));
        _waitingForPath = false;
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
