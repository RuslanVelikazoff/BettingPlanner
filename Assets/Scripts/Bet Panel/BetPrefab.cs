using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BetPrefab : MonoBehaviour
{
    [SerializeField] 
    private Button betButton;

    [Space(13)]
    
    [SerializeField]
    private TextMeshProUGUI matchNameText;

    [Space(13)]
    
    [SerializeField]
    private TextMeshProUGUI teamNameText1;
    [SerializeField] 
    private TextMeshProUGUI scoreText1;
    [SerializeField]
    private TextMeshProUGUI teamNameText2;
    [SerializeField]
    private TextMeshProUGUI scoreText2;

    [Space(13)]
    
    [SerializeField]
    private TextMeshProUGUI betText;
    [SerializeField]
    private TextMeshProUGUI coefficientText;
    [SerializeField] 
    private Image betImage;

    [Space(13)]
    
    [SerializeField]
    private Color winColor;
    [SerializeField] 
    private Color loseColor;

    public void SpawnPrefab(int index)
    {
        matchNameText.text = MatchData.Instance.GetMatchName(index);

        teamNameText1.text = MatchData.Instance.GetTeamName1(index);
        teamNameText2.text = MatchData.Instance.GetTeamName2(index);

        scoreText1.text = MatchData.Instance.GetTeamScore1(index).ToString();
        scoreText2.text = MatchData.Instance.GetTeamScore2(index).ToString();

        SetBet(index);
        ButtonClickAction(index);
    }

    private void ButtonClickAction(int index)
    {
        if (betButton != null)
        {
            betButton.onClick.RemoveAllListeners();
            betButton.onClick.AddListener(() =>
            {
                CreateBetPanel.Instance.OpenCreateBetPanel(index);
            });
        }
    }

    private void SetBet(int index)
    {
        switch (MatchData.Instance.GetMatchBet(index))
        {
            case GameData.Bet.Null:
                betImage.gameObject.SetActive(false);
                betText.gameObject.SetActive(false);
                coefficientText.gameObject.SetActive(false);
                break;
            
            case GameData.Bet.Draw:
                if (MatchData.Instance.GetTeamResult1(index) == GameData.Result.Draw
                    || MatchData.Instance.GetTeamResult2(index) == GameData.Result.Draw)
                {
                    betImage.color = winColor;
                    betText.text = "Won";
                    coefficientText.text = MatchData.Instance.GetCoefficientBet(index).ToString();
                    coefficientText.color = winColor;
                }
                else
                {
                    betImage.color = loseColor;
                    betText.text = "Lose";
                    coefficientText.text = MatchData.Instance.GetCoefficientBet(index).ToString();
                    coefficientText.color = loseColor;
                }
                break;
            
            case GameData.Bet.WinTeam1:
                if (MatchData.Instance.GetTeamResult1(index) == GameData.Result.Win)
                {
                    betImage.color = winColor;
                    betText.text = "Won";
                    coefficientText.text = MatchData.Instance.GetCoefficientBet(index).ToString();
                    coefficientText.color = winColor;
                }
                else
                {
                    betImage.color = loseColor;
                    betText.text = "Lose";
                    coefficientText.text = MatchData.Instance.GetCoefficientBet(index).ToString();
                    coefficientText.color = loseColor;
                }
                break;
            
            case GameData.Bet.WinTeam2:
                if (MatchData.Instance.GetTeamResult2(index) == GameData.Result.Win)
                {
                    betImage.color = winColor;
                    betText.text = "Won";
                    coefficientText.text = MatchData.Instance.GetCoefficientBet(index).ToString();
                    coefficientText.color = winColor;
                }
                else
                {
                    betImage.color = loseColor;
                    betText.text = "Lose";
                    coefficientText.text = MatchData.Instance.GetCoefficientBet(index).ToString();
                    coefficientText.color = loseColor;
                }
                break;
        }
    }
}
