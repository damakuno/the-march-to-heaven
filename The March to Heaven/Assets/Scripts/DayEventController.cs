using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DayEventController : MonoBehaviour
{
    public int dayNumber; // start with 1
    [Header("Day Specific Events")]
    public UnityEvent onDayStart;
    public UnityEvent onGoToHospital;
    public UnityEvent onGoToWork;
    public UnityEvent onGoToPark;
    public UnityEvent onDayEnd;

    // Start is called before the first frame update
    void Awake()
    {
        onDayStart.AddListener(() => FindObjectOfType<MailController>().SendAllMailOnDay(dayNumber));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
