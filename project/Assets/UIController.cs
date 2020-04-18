using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _TimeLeft;
    [SerializeField] private TextMeshProUGUI _distanceLeft;

    [SerializeField] private GameObject _instructions;
    
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
}
