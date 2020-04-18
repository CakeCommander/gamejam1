using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private float _timeLeft = 60;

    [SerializeField]
    private UIController _ui;
    
    private bool _gameStarted = false;
    
    
    void Start()
    {
        _gameStarted = false;
        _ui.UpdateTime(_timeLeft);
    }

    void Update()
    {
        if (_gameStarted)
        {
            _timeLeft -= Time.deltaTime;
            _ui.UpdateTime(_timeLeft);
        }

        if (Input.GetMouseButtonUp(0))
        {
            _gameStarted = true;
        }
    }
}
