using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ViewMatchPanel : MonoBehaviour
{
    public static ViewMatchPanel Instance { get; private set; }

    [SerializeField] 
    private TextMeshProUGUI matchNameText;
    [SerializeField] 
    private TextMeshProUGUI dateText;
    [SerializeField]
    private TextMeshProUGUI teamNameText1;
    [SerializeField] 
    private TextMeshProUGUI teamNameText2;
    [SerializeField]
    private TextMeshProUGUI resultText;

    [Space(13)]
    
    [SerializeField] 
    private TextMeshProUGUI teamNameResultText1;
    [SerializeField]
    private TextMeshProUGUI teamNameResultText2;
    [SerializeField]
    private TMP_InputField teamScoreInputField1;
    [SerializeField] 
    private TMP_InputField teamScoreInputField2;
    [SerializeField]
    private Button teamResultButton1;
    [SerializeField] 
    private Button teamResultButton2;
    [SerializeField] 
    private Color winColor;
    [SerializeField]
    private Color defaultColor;

    [Space(13)]
    
    [SerializeField]
    private GameObject betPanel;
    [SerializeField] 
    private TextMeshProUGUI betText;
    [SerializeField]
    private TextMeshProUGUI coefficientText;

    [Space(13)]
    
    [SerializeField]
    private Button closeButton;
    [SerializeField]
    private GameObject lowerPanel;
    [SerializeField] 
    private MainCategoryFilter mainCategoryFilter;
    [SerializeField] 
    private MainCategoryScrollView mainCategoryScrollView;

    private GameData.Result teamResult1;
    private GameData.Result teamResult2;

    private void Awake()
    {
        Instance = this;
        this.gameObject.SetActive(false);
    }

    public void OpenViewPanel(int index)
    {
        this.gameObject.SetActive(true);
        lowerPanel.SetActive(false);
        
        matchNameText.text = MatchData.Instance.GetMatchName(index);
        dateText.text = MatchData.Instance.GetMatchDate(index).ToString("dd/MM/yyyy HH:mm");
        teamNameText1.text = MatchData.Instance.GetTeamName1(index);
        teamNameText2.text = MatchData.Instance.GetTeamName2(index);
        resultText.text = $"{MatchData.Instance.GetTeamScore1(index)}:{MatchData.Instance.GetTeamScore2(index)}";

        teamNameResultText1.text = MatchData.Instance.GetTeamName1(index);
        teamNameResultText2.text = MatchData.Instance.GetTeamName2(index);
        teamScoreInputField1.text = MatchData.Instance.GetTeamScore1(index).ToString();
        teamScoreInputField2.text = MatchData.Instance.GetTeamScore2(index).ToString();

        SetTeamResultButtonColor(index);
        ButtonClickAction(index);
        SetBet(index);
    }

    private void ButtonClickAction(int index)
    {
        if (closeButton != null)
        {
            closeButton.onClick.RemoveAllListeners();
            closeButton.onClick.AddListener(() =>
            {
                if (teamScoreInputField1.text != string.Empty)
                {
                    MatchData.Instance.SetTeamScore1(index, Int32.Parse(teamScoreInputField1.text));
                }

                if (teamScoreInputField2.text != string.Empty)
                {
                    MatchData.Instance.SetTeamScore2(index, Int32.Parse(teamScoreInputField2.text));
                }
                
                mainCategoryScrollView.ResetAllMatches();
                mainCategoryFilter.ResetCategory();
                this.gameObject.SetActive(false);
                lowerPanel.SetActive(true);
            });
        }

        if (teamResultButton1 != null)
        {
            teamResultButton1.onClick.RemoveAllListeners();
            teamResultButton1.onClick.AddListener(() =>
            {
                MatchData.Instance.SetTeamResult1(index, GameData.Result.Win);
                MatchData.Instance.SetTeamResult2(index, GameData.Result.Lose);
                SetTeamResultButtonColor(index);
            });
        }

        if (teamResultButton2 != null)
        {
            teamResultButton2.onClick.RemoveAllListeners();
            teamResultButton2.onClick.AddListener(() =>
            {
                MatchData.Instance.SetTeamResult1(index, GameData.Result.Lose);
                MatchData.Instance.SetTeamResult2(index, GameData.Result.Win);
                SetTeamResultButtonColor(index);
            });
        }
    }
    
    private void SetTeamResultButtonColor(int index)
    {
        teamResult1 = MatchData.Instance.GetTeamResult1(index);
        teamResult2 = MatchData.Instance.GetTeamResult2(index);

        if (teamResult1 == GameData.Result.Draw || teamResult2 == GameData.Result.Draw
                                                || teamResult1 == GameData.Result.Null || teamResult2 == GameData.Result.Null)
        {
            teamResultButton1.GetComponent<Image>().color = defaultColor;
            teamResultButton2.GetComponent<Image>().color = defaultColor;
        }

        if (teamResult1 == GameData.Result.Win)
        {
            teamResultButton1.GetComponent<Image>().color = winColor;
            teamResultButton2.GetComponent<Image>().color = defaultColor;
        }

        if (teamResult2 == GameData.Result.Win)
        {
            teamResultButton1.GetComponent<Image>().color = defaultColor;
            teamResultButton2.GetComponent<Image>().color = winColor;
        }
    }

    private void SetBet(int index)
    {
        switch (MatchData.Instance.GetMatchBet(index))
        {
            case GameData.Bet.Null:
                betPanel.SetActive(false);
                break;
            
            case GameData.Bet.Draw:
                betPanel.SetActive(true);
                betText.text = "Draw";
                coefficientText.text = MatchData.Instance.GetCoefficientBet(index).ToString();
                break;
            
            case GameData.Bet.WinTeam1:
                betPanel.SetActive(true);
                betText.text = "Win Team 1";
                coefficientText.text = MatchData.Instance.GetCoefficientBet(index).ToString();
                break;
            
            case GameData.Bet.WinTeam2:
                betPanel.SetActive(true);
                betText.text = "Win Team 2";
                coefficientText.text = MatchData.Instance.GetCoefficientBet(index).ToString();
                break;
        }
    }
}
