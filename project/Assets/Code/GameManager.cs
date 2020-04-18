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
    private bool _gameComplete = false;

    void Start()
    {
        _gameStarted = false;
        _ui.UpdateTime(_timeLeft);
        _ui.UpdateDistance(_distanceLeft);
    }

    public void DistanceTravelled(float dist)
    {
        if (_gameComplete)
        {
            return;
        }
        _distanceLeft -= (dist*0.6f);

        if (_distanceLeft <= 0)
        {
            _gameComplete = true;
            _ui.OnGameWon();
        }
        
        _ui.UpdateDistance(_distanceLeft);
    }

    void Update()
    {
        if (_gameComplete)
        {
            return;
        }
        if (_gameStarted)
        {
            _timeLeft -= Time.deltaTime;
            _ui.UpdateTime(_timeLeft);

            if (_timeLeft <= 0)
            {
                _gameComplete = true;
                _ui.OnGameLost();
            }
        }

        if (!_gameStarted && Input.GetMouseButtonDown(0))
        {
            var cops = GameObject.FindObjectsOfType<Cop>();

            for (int i = 0; i < cops.Length; ++i)
            {
                cops[i].StartGame();
            }
            
            var characters = GameObject.FindObjectsOfType<Character>();

            for (int i = 0; i < characters.Length; ++i)
            {
                characters[i].StartGame();
            }

            _gameStarted = true;
            _ui.StartGame();
        }
    }

    public void OnCaught()
    {
        _gameComplete = true;
        _ui.OnGameLost();
    }
}
