using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EditMatchPanel : MonoBehaviour
{
    public static EditMatchPanel Instance { get; private set; }

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
    private Button deleteButton;
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
    private int index;

    private void Awake()
    {
        Instance = this;
        this.gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        if (!MatchData.Instance.DataEmpty())
        {
            OnEnableConfiguration();
        }
    }

    public void OpenEditMatchPanel(int index)
    {
        this.index = index;
        
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
                EditMatch();
            });
        }

        if (deleteButton != null)
        {
            deleteButton.onClick.RemoveAllListeners();
            deleteButton.onClick.AddListener(() =>
            {
                matchCategoryFilter.ResetCategory();
                matchScrollView.ResetAllMatches();
                this.gameObject.SetActive(false);
                lowerPanel.SetActive(true);
                MatchData.Instance.DeleteMatch(index);
            });
        }
    }

    private void EditMatch()
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
                
                MatchData.Instance.SetMatchName(index, matchName);
                MatchData.Instance.SetMatchDate(index, date);
                MatchData.Instance.SetTeamName1(index, teamName1);
                MatchData.Instance.SetTeamName2(index, teamName2);

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
        matchName = MatchData.Instance.GetMatchName(index);
        matchNameInputField.text = matchName;

        date = MatchData.Instance.GetMatchDate(index);
        
        day = date.Day;
        dayInputField.text = day.ToString();

        month = date.Month;
        monthInputField.text = month.ToString();

        year = date.Year;
        yearInputField.text = year.ToString();

        hour = date.Hour;
        hourInputField.text = hour.ToString();

        minute = date.Minute;
        minuteInputField.text = minute.ToString();

        teamName1 = MatchData.Instance.GetTeamName1(index);
        teamInputField1.text = teamName1;

        teamName2 = MatchData.Instance.GetTeamName2(index);
        teamInputField2.text = teamName2;
    }
}
