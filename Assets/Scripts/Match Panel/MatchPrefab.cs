using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MatchPrefab : MonoBehaviour
{
    [SerializeField] 
    private TextMeshProUGUI matchNameText;
    [SerializeField] 
    private TextMeshProUGUI dateText;

    [Space(13)]
    
    [SerializeField] 
    private TextMeshProUGUI teamNameText1;
    [SerializeField]
    private TextMeshProUGUI teamNameText2;

    [Space(13)]
    
    [SerializeField]
    private Button matchButton;

    public void SpawnPrefab(int index)
    {
        matchNameText.text = MatchData.Instance.GetMatchName(index);
        dateText.text = MatchData.Instance.GetMatchDate(index).ToString("dd/MM/yyyy HH:mm");

        teamNameText1.text = MatchData.Instance.GetTeamName1(index);
        teamNameText2.text = MatchData.Instance.GetTeamName2(index);

        ButtonClickAction(index);
    }

    private void ButtonClickAction(int index)
    {
        if (matchButton != null)
        {
            matchButton.onClick.RemoveAllListeners();
            matchButton.onClick.AddListener(() =>
            {
                EditMatchPanel.Instance.OpenEditMatchPanel(index);
            });
        }
    }
}
