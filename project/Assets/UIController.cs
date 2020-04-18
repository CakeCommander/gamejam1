using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _TimeLeft;
    
    public void UpdateTime(float time)
    {
        _TimeLeft.text = string.Format("{0}s", Mathf.RoundToInt(time));
    }
}
