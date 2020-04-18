using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _TimeLeft;
    [SerializeField] private TextMeshProUGUI _distanceLeft;

    [SerializeField] private GameObject _instructions;
    
    [SerializeField]
    private GameObject _win;

    [SerializeField]
    private GameObject _lose;


    private void Start()
    {
        _instructions.SetActive(true);
    }

    public void OnGameWon()
    {
        _win.SetActive(true);
    }

    public void OnGameLost()
    {
        _lose.SetActive(true);
    }
    
    public void UpdateTime(float time)
    {
        _TimeLeft.text = string.Format("{0}s", Mathf.RoundToInt(time));
    }
    
    public void UpdateDistance(float dist)
    {
        _distanceLeft.text = string.Format("{0}m", Mathf.RoundToInt(dist));
    }

    public void StartGame()
    {
        _instructions.SetActive(false);
    }

    public void OnRestart()
    {
        SceneManager.LoadScene(0);
    }
    
}
