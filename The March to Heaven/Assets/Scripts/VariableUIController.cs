using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Enumerations;

public class VariableUIController : MonoBehaviour
{
    // UI references exposed in Unity inspector
    [Header("Stats UI")]
    [SerializeField]
    Image heartbeatLine;
    [SerializeField]
    TextMeshProUGUI stressText, moneyText;
    [Header("Phone UI")]
    [SerializeField]
    TextMeshProUGUI timeText;
    [SerializeField]
    TextMeshProUGUI dayText;

    // Managers holding the variables concerning the UI
    GameManager gm;
    DayEventsManager dayEventsManager;

    // Start is called before the first frame update
    void Start()
    {
        // init references
        gm = GameManager.Instance;
        dayEventsManager = FindObjectOfType<DayEventsManager>();

        gm.onStatsChangeEvents += UpdateStatsUI;
        dayEventsManager.onTimeChangeEvents += UpdateTimeUI;
        UpdateAllUI();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateAllUI()
    {
        timeText.text = dayEventsManager.currTime.ToString();
    }

    public void UpdateStatsUI()
    {
        stressText.text = gm.stress.ToString();
        moneyText.text = "$ " + gm.cash;
    }

    public void UpdateTimeUI()
    {
        timeText.text = dayEventsManager.currTime.ToString();
        dayText.text = "Day " + gm.currDay;
    }
}
