using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class EndingManager : MonoBehaviour
{
    [SerializeField] private Canvas[] _endings;
    void Start()
    {
         DisplayEnding(GameManager.Instance.CurrentSanityLevel+2);  
    }

    void DisplayEnding(int finalState)
    {
        if (finalState < _endings.Length && finalState >= 0)
            _endings[finalState].gameObject.SetActive(true);
        else 
            throw new ArgumentOutOfRangeException(nameof(finalState), finalState, null);
    }
}
