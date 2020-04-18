using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private float _timeLeft = 60;

    [SerializeField]
    private float _distanceLeft = 500;
    
    [SerializeField]
    private UIController _ui;
    
    private bool _gameStarted = false;

    void Start()
    {
        _gameStarted = false;
        _ui.UpdateTime(_timeLeft);
        _ui.UpdateDistance(_distanceLeft);
    }

    public void DistanceTravelled(float dist)
    {
        _distanceLeft -= (dist/2);

        if (_distanceLeft <= 0)
        {
            //TODO win
        }
        
        _ui.UpdateDistance(_distanceLeft);
    }

    void Update()
    {
        if (_gameStarted)
        {
            _timeLeft -= Time.deltaTime;
            _ui.UpdateTime(_timeLeft);

            if (_timeLeft <= 0)
            {
                //TODO lose
            }
            
        }

        if (Input.GetMouseButtonDown(0))
        {
            _gameStarted = true;
            _ui.StartGame();
        }
    }
}
