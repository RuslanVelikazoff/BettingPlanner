using TMPro;
using UnityEngine;

public class RecordHolderPrefab : MonoBehaviour
{
    [SerializeField] 
    private TextMeshProUGUI nameText;
    [SerializeField] 
    private TextMeshProUGUI recordText;

    public void SpawnPrefab(string name, string record)
    {
        nameText.text = name;
        recordText.text = record;
    }
}
