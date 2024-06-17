using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CreateMatchPanel : MonoBehaviour
{
    public static CreateMatchPanel Instance { get; private set; }

    [SerializeField]
    private TMP_InputField matchNameInputField;
    
    [Space(13)]
    
    [SerializeField]
    private TMP_InputField dayInputField;
    [SerializeField] 
    private TMP_InputField monthInputField;
    [SerializeField] 
    private TMP_InputField yearInputField;
    [SerializeField]
    private TMP_InputField hourInputField;
    [SerializeField]
    private TMP_InputField minuteInputField;
    
    [Space(13)]
    
    [SerializeField] 
    private TMP_InputField teamInputField1;
    [SerializeField] 
    private TMP_InputField teamInputField2;

    [Space(13)]
    
    [SerializeField] 
    private TMP_InputField[] allInputFields;

    [Space(13)]
    
    [SerializeField] 
    private Button createButton;
    [SerializeField] 
    private Button closeButton;
    [SerializeField]
    private MatchCategoryFilter matchCategoryFilter;
    [SerializeField]
    private MatchCategoryScrollView matchScrollView;
    [SerializeField]
    private GameObject lowerPanel;

    private string matchName;
    private int day;
    private int month;
    private int year;
    private int hour;
    private int minute;
    private int second = 0;
    private string teamName1;
    private string teamName2;

    private DateTime date;
    private GameData.TypeOfSport category;

    private void Awake()
    {
        Instance = this;
        this.gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        OnEnableConfiguration();
    }

    public void OpenCreateMatchPanel(GameData.TypeOfSport category)
    {
        this.category = category;
        this.gameObject.SetActive(true);
        lowerPanel.SetActive(false);

        ButtonClickAction();
    }

    private void ButtonClickAction()
    {
        if (closeButton != null)
        {
            closeButton.onClick.RemoveAllListeners();
            closeButton.onClick.AddListener(() =>
            {
                matchCategoryFilter.ResetCategory();
                matchScrollView.ResetAllMatches();
                this.gameObject.SetActive(false);
                lowerPanel.SetActive(true);
            });
        }

        if (createButton != null)
        {
            createButton.onClick.RemoveAllListeners();
            createButton.onClick.AddListener(() =>
            {
                CreateNewMatch();
            });
        }
    }

    private void CreateNewMatch()
    {
        if (!IsEmptyInputField())
        {
            matchName = matchNameInputField.text;
            day = Int32.Parse(dayInputField.text);
            month = Int32.Parse(monthInputField.text);
            year = Int32.Parse(yearInputField.text);
            hour = Int32.Parse(hourInputField.text);
            minute = Int32.Parse(minuteInputField.text);
            teamName1 = teamInputField1.text;
            teamName2 = teamInputField2.text;

            if (IsTrueDate())
            {
                date = new DateTime(year, month, day, hour, minute, second);
                
                MatchData.Instance.CreateMatchName(matchName);
                MatchData.Instance.CreateMatchDate(date);
                MatchData.Instance.CreateTeamName1(teamName1);
                MatchData.Instance.CreateTeamName2(teamName2);
                MatchData.Instance.CreateMatchType(category);
                MatchData.Instance.CreateTeamScore1(0);
                MatchData.Instance.CreateTeamScore2(0);
                MatchData.Instance.CreateTeamResult1(GameData.Result.Null);
                MatchData.Instance.CreateTeamResult2(GameData.Result.Null);
                
                matchCategoryFilter.ResetCategory();
                matchScrollView.ResetAllMatches();
                this.gameObject.SetActive(false);
                lowerPanel.SetActive(true);
            }
        }
    }

    private bool IsEmptyInputField()
    {
        for (int i = 0; i < allInputFields.Length; i++)
        {
            if (allInputFields[i].text == string.Empty)
            {
                return true;
            }
        }

        return false;
    }
    
    private bool IsTrueDate()
    {
        string dateString = $"{year}.{month}.{day} {hour}:{minute}:{second}";

        if (DateTime.TryParse(dateString, out DateTime result))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void OnEnableConfiguration()
    {
        matchName = string.Empty;
        matchNameInputField.text = matchName;
        
        day = 0;
        dayInputField.text = string.Empty;

        month = 0;
        monthInputField.text = string.Empty;

        year = 0;
        yearInputField.text = string.Empty;

        hour = 0;
        hourInputField.text = string.Empty;

        minute = 0;
        minuteInputField.text = string.Empty;

        teamName1 = string.Empty;
        teamInputField1.text = teamName1;

        teamName2 = string.Empty;
        teamInputField2.text = teamName2;
    }
}
