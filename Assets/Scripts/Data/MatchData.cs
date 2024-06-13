using System;
using System.Collections.Generic;
using UnityEngine;

public class MatchData : MonoBehaviour
{
    public static MatchData Instance { get; private set; }

    private const string SaveKey = "MainSaveMatch";
    
    public List<string> _matchName;
    public List<GameData.TypeOfSport> _matchType;
    public List<DateTime> _matchDate;
    public List<string> _matchDateString;
    public List<string> _teamName1;
    public List<int> _teamGoals1;
    public List<string> _teamName2;
    public List<int> _teamGoals2;
    public List<int> _teamWinIndex;
    
    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        Load();
    }

    private void OnApplicationQuit()
    {
        Save();
    }

    private void OnApplicationPause(bool pauseStatus)
    {
        if (pauseStatus)
        {
            Save();
        }
    }

    private void OnDisable()
    {
        Save();
    }

    private void Load()
    {
        var data = SaveManager.Load<GameData>(SaveKey);

        _matchName = data.matchName;
        _matchType = data.matchType;
        _matchDate = data.matchDate;
        _matchDateString = data.matchDateString;
        _teamName1 = data.teamName1;
        _teamGoals1 = data.teamGoals1;
        _teamName2 = data.teamName2;
        _teamGoals2 = data.teamGoals2;
        _teamWinIndex = data.teamWinIndex;
        
        Debug.Log("Match data loaded");
    }

    private void Save()
    {
        SaveManager.Save(SaveKey, GetSaveSnapshot());
        PlayerPrefs.Save();
        
        Debug.Log("Match data saved");
    }

    private GameData GetSaveSnapshot()
    {
        var data = new GameData()
        {
            matchName = _matchName,
            matchType = _matchType,
            matchDate = _matchDate,
            matchDateString = _matchDateString,
            teamName1 = _teamName1,
            teamGoals1 = _teamGoals1,
            teamName2 = _teamName2,
            teamGoals2 = _teamGoals2,
            teamWinIndex = _teamWinIndex
        };

        return data;
    }
}
