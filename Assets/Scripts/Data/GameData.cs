using System;
using System.Collections.Generic;

[System.Serializable]
public class GameData
{
    public enum TypeOfSport
    {
        Soccer,
        Basketball,
        Volleyball,
        Baseball,
        Football,
        Cricket,
        Null
    }

    public List<string> matchName;
    public List<TypeOfSport> matchType;
    public List<DateTime> matchDate;
    public List<string> matchDateString;
    public List<string> teamName1;
    public List<int> teamGoals1;
    public List<string> teamName2;
    public List<int> teamGoals2;
    public List<int> teamWinIndex;

    public GameData()
    {
        matchName = new List<string>();
        matchType = new List<TypeOfSport>();
        matchDate = new List<DateTime>();
        matchDateString = new List<string>();
        teamName1 = new List<string>();
        teamGoals1 = new List<int>();
        teamName2 = new List<string>();
        teamGoals2 = new List<int>();
        teamWinIndex = new List<int>();
    }
}
