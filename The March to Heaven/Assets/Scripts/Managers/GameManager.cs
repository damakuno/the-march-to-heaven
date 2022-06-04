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

    // game variables
    public int acceptance { get; private set; }
    public int money { get; private set; }
    public int stress { get; private set; }
    public Ending currentEnding;
    public int currDay = 0; // days start from 1 in-game. 0 means game not started.

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
        money = 0;
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
    public void IncreaseAcceptance(int amt)
    {
        acceptance += amt;
        if (onStatsChangeEvents != null)
        {
            onStatsChangeEvents();
        }
    }
    public void DecreaseAcceptance(int amt)
    {
        acceptance -= amt;
        if (onStatsChangeEvents != null)
        {
            onStatsChangeEvents();
        }
    }

    public void EarnMoney(int amt)
    {
        money += amt;
        if (onStatsChangeEvents != null)
        {
            onStatsChangeEvents();
        }
    }
    public void DeductMoney(int amt)
    {
        money -= amt;
        if (onStatsChangeEvents != null)
        {
            onStatsChangeEvents();
        }
    }

    public void IncreaseStress(int amt)
    {
        stress += amt;
        if (onStatsChangeEvents != null)
        {
            onStatsChangeEvents();
        }
    }
    public void DecreaseStress(int amt)
    {
        stress -= amt;
        if (onStatsChangeEvents != null)
        {
            onStatsChangeEvents();
        }
    }
    #endregion

    #region DEBUG FUNCTIONS
    public void RandomlyChangeStats()
    {
        IncreaseStress(Random.Range(0, 50));
        DeductMoney(Random.Range(0, 50));
        EarnMoney(Random.Range(100, 300));
    }
    #endregion
}
