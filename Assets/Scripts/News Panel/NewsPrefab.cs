using TMPro;
using UnityEngine;

public class NewsPrefab : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI titleText;
    [SerializeField]
    private TextMeshProUGUI bodyText;

    public void SpawnPrefab(string title, string body)
    {
        titleText.text = title;
        bodyText.text = body;
    }
}
