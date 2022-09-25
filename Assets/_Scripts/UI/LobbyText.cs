using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LobbyText : MonoBehaviour
{
    private TextMeshProUGUI text;
    private bool Updated;
    private void Awake() => text = GetComponent<TextMeshProUGUI>();
    private void Start() => Updated = false;
    private void OnDestroy() => Updated = false;

    private void Update()
    {
        if (!Updated)
        {
            if(GameManager.Instance.CurrentEvent != null)
            {
                text.text = $"Event {GameManager.Instance.CurrentLevel} / 5:\n{GameManager.Instance.CurrentEvent.EventName}";
                Updated = true;
            }
            else if(GameManager.Instance.CurrentLevel > 5)
            {
                text.text = $"Ending.\nGo through de door one last time";
                Updated = true;
            }
        }
    }
}
