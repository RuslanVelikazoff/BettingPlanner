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

    public enum Result
    {
        Win,
        Lose,
        Draw,
        Null
    }

    public enum Bet
    {
        WinTeam1,
        WinTeam2,
        Draw,
        Null
    }

    public List<string> matchName;
    public List<TypeOfSport> matchType;
    public List<DateTime> matchDate;
    public List<string> matchDateString;
    public List<string> teamName1;
    public List<int> teamScore1;
    public List<Result> teamResult1;
    public List<string> teamName2;
    public List<int> teamScore2;
    public List<Result> teamResult2;
    public List<Bet> matchBet;
    public List<float> coefficientBet;

    public GameData()
    {
        matchName = new List<string>();
        matchType = new List<TypeOfSport>();
        matchDate = new List<DateTime>();
        matchDateString = new List<string>();
        teamName1 = new List<string>();
        teamScore1 = new List<int>();
        teamResult1 = new List<Result>();
        teamName2 = new List<string>();
        teamScore2 = new List<int>();
        teamResult2 = new List<Result>();
        matchBet = new List<Bet>();
        coefficientBet = new List<float>();
    }
}
