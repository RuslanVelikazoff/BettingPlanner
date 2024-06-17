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

    public bool DataEmpty()
    {
        if (_matchName.Count <= 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void DeleteMatch(int index)
    {
        _matchName.RemoveAt(index);
        _matchType.RemoveAt(index);
        _matchDate.RemoveAt(index);
        _matchDateString.RemoveAt(index);
        _teamName1.RemoveAt(index);
        _teamName2.RemoveAt(index);
        _teamScore1.RemoveAt(index);
        _teamScore2.RemoveAt(index);
        _teamResult1.RemoveAt(index);
        _teamResult2.RemoveAt(index);
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

    public void SetMatchName(int index, string matchName)
    {
        _matchName[index] = matchName;
        Save();
    }

    public void SetMatchDate(int index, DateTime date)
    {
        _matchDate[index] = date;
        _matchDateString[index] = date.ToString();
        Save();
    }

    public void SetTeamName1(int index, string teamName)
    {
        _teamName1[index] = teamName;
        Save();
    }

    public void SetTeamName2(int index, string teamName)
    {
        _teamName2[index] = teamName;
        Save();
    }

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

    #region CreateMethods

    public void CreateMatchName(string matchName)
    {
        _matchName.Add(matchName);
    }

    public void CreateMatchType(GameData.TypeOfSport category)
    {
        _matchType.Add(category);
    }

    public void CreateMatchDate(DateTime date)
    {
        _matchDate.Add(date);
        _matchDateString.Add(date.ToString());
    }

    public void CreateTeamName1(string teamName)
    {
        _teamName1.Add(teamName);
    }

    public void CreateTeamName2(string teamName)
    {
        _teamName2.Add(teamName);
    }

    public void CreateTeamScore1(int score)
    {
        _teamScore1.Add(score);
    }

    public void CreateTeamScore2(int score)
    {
        _teamScore2.Add(score);
    }

    public void CreateTeamResult1(GameData.Result result)
    {
        _teamResult1.Add(result);
    }

    public void CreateTeamResult2(GameData.Result result)
    {
        _teamResult2.Add(result);
        Save();
    }

    #endregion
}
