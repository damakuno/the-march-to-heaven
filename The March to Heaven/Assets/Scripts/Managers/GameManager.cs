using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Enumerations;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    // delegates and events
    public delegate void OnGameStart();
    public OnGameStart onGameStartEvents;
    public delegate void OnStatsChange();
    public OnStatsChange onStatsChangeEvents;

    #region GAME CONSTANTS
    public const int MAX_ACTIONS = 2;
    public const int MAX_CASH = 9999;
    public const int MAX_STRESS = 100;
    public const int MAX_ACCEPTANCE = 100;
    #endregion

    // game variables
    public int actions { get; private set; }
    public int acceptance { get; private set; }
    public int cash { get; private set; }
    public int stress { get; private set; }
    public Ending currentEnding;
    public int currDay = 0; // days start from 1 in-game. 0 means game not started.

    // JUST PORTED, HAVE NOT ORGANISED, TO REFACTOR MAYBE
    int[] locationActions = { 0, 0, 0 };
    int latePaymentStrikes = 0;

    [SerializeField] TextAsset dataJsonFile;

    // references to other managers

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
        DontDestroyOnLoad(this.gameObject);

        //InitializeGameData();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    /// <summary>
    /// Starts the game (to be called from the title scene)
    /// </summary>
    public void StartGame()
    {
        // TODO 
        onGameStartEvents();
    }
    public void StartGame(Scene scene, LoadSceneMode mode)
    {
        SceneManager.sceneLoaded -= GameManager.Instance.StartGame;
        // TODO 
        if (onGameStartEvents != null)
        {
            onGameStartEvents();
        }

        acceptance = 0;
        cash = 0;
        stress = 0;
    }

    /// <summary>
    /// Restarts the game. To be called during the game scene.
    /// Clears all variables and resets game to day 1
    /// </summary>
    public void RestartGame()
    {
        // TODO
    }

    #region MODIFYING STATS
    public void AddAcceptance(int amt)
    {
        acceptance = Mathf.Min(acceptance + amt, MAX_ACCEPTANCE);

        if (onStatsChangeEvents != null)
        {
            onStatsChangeEvents();
        }
    }
    public void ReduceAcceptance(int amt)
    {
        acceptance = Mathf.Max(acceptance - amt, 0);

        if (onStatsChangeEvents != null)
        {
            onStatsChangeEvents();
        }
    }

    public void AddCash(int amt)
    {
        cash = Mathf.Min(cash + amt, MAX_CASH);

        if (onStatsChangeEvents != null)
        {
            onStatsChangeEvents();
        }
    }
    public void ReduceCash(int amt)
    {
        cash = Mathf.Max(cash - amt, 0);

        if (onStatsChangeEvents != null)
        {
            onStatsChangeEvents();
        }
    }

    public void AddStress(int amt)
    {
        stress = Mathf.Min(stress + amt, MAX_STRESS);

        // TODO REMINDER: onstatschangeevents should probably include a check for whether any of the stats trigger the end game condition
        if (onStatsChangeEvents != null)
        {
            onStatsChangeEvents();
        }
    }
    public void ReduceStress(int amt)
    {
        stress = Mathf.Max(stress - amt, 0);

        if (onStatsChangeEvents != null)
        {
            onStatsChangeEvents();
        }
    }

    public void AddActions(Location loc, int val)
    {
        locationActions[(int)loc] = locationActions[(int)loc] + val;
        actions += val;
    }

    public void ResetActions()
    {
        for (int i = 0; i < locationActions.Length; i++)
        {
            locationActions[i] = 0;
        }
        actions = 0;
    }

    public int GetActionCount(Location loc)
    {
        return locationActions[(int)loc];
    }
    #endregion

    #region DEBUG FUNCTIONS
    public void RandomlyChangeStats()
    {
        AddStress(Random.Range(0, 50));
        ReduceCash(Random.Range(0, 50));
        AddCash(Random.Range(100, 300));
    }
    #endregion
}
