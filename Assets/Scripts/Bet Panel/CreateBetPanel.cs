using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CreateBetPanel : MonoBehaviour
{
    public static CreateBetPanel Instance { get; private set; }

    [SerializeField] 
    private TextMeshProUGUI teamNameText1;
    [SerializeField]
    private TMP_InputField teamScoreInputField1;
    [SerializeField]
    private Image teamResultImage1;

    [Space(13)]
    
    [SerializeField]
    private TextMeshProUGUI teamNameText2;
    [SerializeField] 
    private TMP_InputField teamScoreInputField2;
    [SerializeField]
    private Image teamResultImage2;

    [Space(13)]
    
    [SerializeField]
    private Button betWinTeamButton1;
    [SerializeField]
    private Button betDrawButton;
    [SerializeField]
    private Button betWinTeamButton2;

    [Space(13)]
    
    [SerializeField]
    private TMP_InputField coefficientInputField;

    [Space(13)]
    
    [SerializeField]
    private Button createButton;
    [SerializeField] 
    private Button closeButton;

    [Space(13)]
    
    [SerializeField]
    private Color winColor;
    [SerializeField]
    private Color loseColor;

    [Space(13)]
    
    [SerializeField]
    private Color selectedColor;
    [SerializeField]
    private Color defaultColor;

    [Space(13)]
    
    [SerializeField]
    private GameObject lowerPanel;
    [SerializeField]
    private BetCategoryScrollView betScrollView;
    [SerializeField]
    private BetCategoryFilter categoryFilter;

    private int index;
    private GameData.Bet selectedBet;

    private void Awake()
    {
        Instance = this;
        this.gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        if (!MatchData.Instance.DataEmpty())
        {
            selectedBet = MatchData.Instance.GetMatchBet(index);
            OnEnableConfiguration();
        }
    }

    public void OpenCreateBetPanel(int index)
    {
        this.index = index;
        
        this.gameObject.SetActive(true);
        lowerPanel.SetActive(false);
    }

    private void OnEnableConfiguration()
    {
        teamNameText1.text = MatchData.Instance.GetTeamName1(index);
        teamNameText2.text = MatchData.Instance.GetTeamName2(index);

        teamScoreInputField1.text = MatchData.Instance.GetTeamScore1(index).ToString();
        teamScoreInputField2.text = MatchData.Instance.GetTeamScore2(index).ToString();
        
        SetResultColor();
        SetBetButtonColor();
        ButtonClickAction();
    }

    private void ButtonClickAction()
    {
        if (closeButton != null)
        {
            closeButton.onClick.RemoveAllListeners();
            closeButton.onClick.AddListener(() =>
            {
                betScrollView.ResetAllMatches();
                categoryFilter.ResetCategory();
                this.gameObject.SetActive(false);
                lowerPanel.SetActive(true);
            });
        }

        if (createButton != null)
        {
            createButton.onClick.RemoveAllListeners();
            createButton.onClick.AddListener(() =>
            {
                CreateBet();
            });
        }

        if (betWinTeamButton1 != null)
        {
            betWinTeamButton1.onClick.RemoveAllListeners();
            betWinTeamButton1.onClick.AddListener(() =>
            {
                selectedBet = GameData.Bet.WinTeam1;
                SetBetButtonColor();
            });
        }

        if (betDrawButton != null)
        {
            betDrawButton.onClick.RemoveAllListeners();
            betDrawButton.onClick.AddListener(() =>
            {
                selectedBet = GameData.Bet.Draw;
                SetBetButtonColor();
            });
        }

        if (betWinTeamButton2 != null)
        {
            betWinTeamButton2.onClick.RemoveAllListeners();
            betWinTeamButton2.onClick.AddListener(() =>
            {
                selectedBet = GameData.Bet.WinTeam2;
                SetBetButtonColor();
            });
        }
    }

    private void CreateBet()
    {
        if (!IsInputFieldEmpty() && selectedBet != GameData.Bet.Null)
        {
            float coefficient = float.Parse(coefficientInputField.text);
            int teamScore1 = Int32.Parse(teamScoreInputField1.text);
            int teamScore2 = Int32.Parse(teamScoreInputField2.text);
            
            MatchData.Instance.SetCoefficientBet(index, coefficient);
            MatchData.Instance.SetMatchBet(index, selectedBet);
            MatchData.Instance.SetTeamScore1(index, teamScore1);
            MatchData.Instance.SetTeamScore2(index, teamScore2);
            
            betScrollView.ResetAllMatches();
            categoryFilter.ResetCategory();
            this.gameObject.SetActive(false);
            lowerPanel.SetActive(true);
        }
        
    }

    private bool IsInputFieldEmpty()
    {
        if (teamScoreInputField1.text == string.Empty
            || teamScoreInputField2.text == string.Empty
            || coefficientInputField.text == string.Empty)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void SetBetButtonColor()
    {
        switch (selectedBet)
        {
            case GameData.Bet.Null:
                betWinTeamButton1.GetComponent<Image>().color = defaultColor;
                betDrawButton.GetComponent<Image>().color = defaultColor;
                betWinTeamButton2.GetComponent<Image>().color = defaultColor;
                break;
            
            case GameData.Bet.Draw:
                betWinTeamButton1.GetComponent<Image>().color = defaultColor;
                betDrawButton.GetComponent<Image>().color = selectedColor;
                betWinTeamButton2.GetComponent<Image>().color = defaultColor;
                break;
            
            case GameData.Bet.WinTeam1:
                betWinTeamButton1.GetComponent<Image>().color = selectedColor;
                betDrawButton.GetComponent<Image>().color = defaultColor;
                betWinTeamButton2.GetComponent<Image>().color = defaultColor;
                break;
            
            case GameData.Bet.WinTeam2:
                betWinTeamButton1.GetComponent<Image>().color = defaultColor;
                betDrawButton.GetComponent<Image>().color = defaultColor;
                betWinTeamButton2.GetComponent<Image>().color = selectedColor;
                break;
        }
    }

    private void SetResultColor()
    {
        switch (MatchData.Instance.GetTeamResult1(index))
        {
            case GameData.Result.Null:
                teamResultImage1.color = loseColor;
                teamResultImage2.color = loseColor;
                break;
            case GameData.Result.Draw:
                teamResultImage1.color = loseColor;
                teamResultImage2.color = loseColor;
                break;
            case GameData.Result.Win:
                teamResultImage1.color = winColor;
                teamResultImage2.color = loseColor;
                break;
            case GameData.Result.Lose:
                teamResultImage1.color = loseColor;
                teamResultImage2.color = winColor;
                break;
        }
    }
}
