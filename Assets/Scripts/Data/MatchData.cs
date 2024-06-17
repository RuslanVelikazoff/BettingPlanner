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
    public List<int> _teamScore1;
    public List<GameData.Result> _teamResult1;
    public List<string> _teamName2;
    public List<int> _teamScore2;
    public List<GameData.Result> _teamResult2;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        Load();
        ConvertStringToDate();
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
        _teamScore1 = data.teamScore1;
        _teamResult1 = data.teamResult1;
        _teamName2 = data.teamName2;
        _teamScore2 = data.teamScore2;
        _teamResult2 = data.teamResult2;

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
            teamScore1 = _teamScore1,
            teamResult1 = _teamResult1,
            teamName2 = _teamName2,
            teamScore2 = _teamScore2,
            teamResult2 = _teamResult2
        };

        return data;
    }

    private void ConvertStringToDate()
    {
        for (int i = 0; i < _matchDateString.Count; i++)
        {
            if (DateTime.TryParse(_matchDateString[i], out DateTime result))
            {
                _matchDate.Add(result);
            }
        }
    }

    #region GetMethods

    public string GetMatchName(int index)
    {
        return _matchName[index];
    }

    public string GetTeamName1(int index)
    {
        return _teamName1[index];
    }

    public string GetTeamName2(int index)
    {
        return _teamName2[index];
    }

    public int GetTeamScore1(int index)
    {
        return _teamScore1[index];
    }

    public int GetTeamScore2(int index)
    {
        return _teamScore2[index];
    }

    public GameData.Result GetTeamResult1(int index)
    {
        return _teamResult1[index];
    }

    public GameData.Result GetTeamResult2(int index)
    {
        return _teamResult2[index];
    }

    public DateTime GetMatchDate(int index)
    {
        return _matchDate[index];
    }

    public List<int> GetMatchCategoryIndexList(GameData.TypeOfSport category)
    {
        List<int> indexList = new List<int>();

        for (int i = 0; i < _matchType.Count; i++)
        {
            if (_matchType[i] == category)
            {
                indexList.Add(i);
            }
        }

        return indexList;
    }

    public List<int> GetSearchMatchIndexList(string searchMatch)
    {
        List<int> indexList = new List<int>();

        for (int i = 0; i < _matchName.Count; i++)
        {
            if (_matchName[i] == searchMatch)
            {
                indexList.Add(i);
            }
        }

        return indexList;
    }

    #endregion

    #region SetMethods

    public void SetTeamScore1(int index, int score)
    {
        _teamScore1[index] = score;
        Save();
    }

    public void SetTeamScore2(int index, int score)
    {
        _teamScore2[index] = score;
        Save();
    }

    public void SetTeamResult1(int index, GameData.Result result)
    {
        _teamResult1[index] = result;
        Save();
    }

    public void SetTeamResult2(int index, GameData.Result result)
    {
        _teamResult2[index] = result;
        Save();
    }

    #endregion
}
