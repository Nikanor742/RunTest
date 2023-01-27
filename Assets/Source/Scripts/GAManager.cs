using UnityEngine;
using GameAnalyticsSDK;

public class GAManager : MonoBehaviour
{
    public static GAManager Instance { get; private set; }


    private void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(this);
    }
    private void Start()
    {
        GameAnalytics.Initialize();
        GameStart();
    }
    public void GameStart()
    {
        GameAnalytics.NewDesignEvent("game_start");
    }
    public void LevelStart(int _level)
    {

        GameAnalytics.NewProgressionEvent(GAProgressionStatus.Start, "level_start " + _level.ToString());
    }
    public void LevelWin(int _level)
    {
        GameAnalytics.NewProgressionEvent(GAProgressionStatus.Complete, "level_win " + _level.ToString());
    }
}