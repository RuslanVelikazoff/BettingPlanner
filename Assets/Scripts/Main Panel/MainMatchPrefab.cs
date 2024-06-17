using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MainMatchPrefab : MonoBehaviour
{
    [SerializeField]
    private Button mainMatchButton;
    
    [Space(13)]
    
    [SerializeField] 
    private TextMeshProUGUI matchNameText;
    [SerializeField]
    private TextMeshProUGUI dateText;

    [Space(13)]
    
    [SerializeField]
    private TextMeshProUGUI teamNameText1;
    [SerializeField] 
    private Image teamWinIndicator1;
    [SerializeField] 
    private TextMeshProUGUI teamScoreText1;
    
    [Space(13)]
    
    [SerializeField]
    private TextMeshProUGUI teamNameText2;
    [SerializeField] 
    private Image teamWinIndicator2;
    [SerializeField] 
    private TextMeshProUGUI teamScoreText2;

    [Space(13)] 
    
    [SerializeField] 
    private Color winColor;
    [SerializeField]
    private Color defaultColor;

    private GameData.Result teamResult1;
    private GameData.Result teamResult2;

    public void SpawnPrefab(int index)
    {
        matchNameText.text = MatchData.Instance.GetMatchName(index);
        dateText.text = MatchData.Instance.GetMatchDate(index).ToString("dd/MM/yyyy HH:mm");

        teamNameText1.text = MatchData.Instance.GetTeamName1(index);
        teamScoreText1.text = MatchData.Instance.GetTeamScore1(index).ToString();

        teamNameText2.text = MatchData.Instance.GetTeamName2(index);
        teamScoreText2.text = MatchData.Instance.GetTeamScore2(index).ToString();
        
        SetTeamWinIndicator(index);
        ButtonClickAction(index);
    }

    private void SetTeamWinIndicator(int index)
    {
        teamResult1 = MatchData.Instance.GetTeamResult1(index);
        teamResult2 = MatchData.Instance.GetTeamResult2(index);

        if (teamResult1 == GameData.Result.Draw || teamResult2 == GameData.Result.Draw
        || teamResult1 == GameData.Result.Null || teamResult2 == GameData.Result.Null)
        {
            teamWinIndicator1.color = defaultColor;
            teamWinIndicator2.color = defaultColor;
        }

        if (teamResult1 == GameData.Result.Win)
        {
            teamWinIndicator1.color = winColor;
            teamWinIndicator2.color = defaultColor;
        }

        if (teamResult2 == GameData.Result.Win)
        {
            teamWinIndicator1.color = defaultColor;
            teamWinIndicator2.color = winColor;
        }
    }

    private void ButtonClickAction(int index)
    {
        if (mainMatchButton != null)
        {
            mainMatchButton.onClick.RemoveAllListeners();
            mainMatchButton.onClick.AddListener(() =>
            {
                ViewMatchPanel.Instance.OpenViewPanel(index);
            });
        }
    }
}
