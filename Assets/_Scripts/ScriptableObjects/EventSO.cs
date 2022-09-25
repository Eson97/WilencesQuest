using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "NewEvent", menuName ="ScriptableObjects/Event")]
public class EventSO : ScriptableObject
{
    [SerializeField] private int _Level = 0;
    [SerializeField] private string _EventName = "";
    [SerializeField] private string _EventDescription = "";
    [SerializeField] private string _GoodEndingEvent = "";
    [SerializeField] private string _BadEndingEvent = "";

    public int Level => _Level;
    public string EventName => _EventName;
    public string EventDescription => _EventDescription;
    public string GoodEndingEvent => _GoodEndingEvent;
    public string BadEndingEvent => _BadEndingEvent;
}
