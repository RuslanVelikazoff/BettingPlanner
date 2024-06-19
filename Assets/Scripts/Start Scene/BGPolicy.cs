using UnityEngine;
using UnityEngine.UI;

public class BGPolicy : MonoBehaviour
{
    [SerializeField] private PolicyManager policyManager;

    [SerializeField] private Button acceptButton;

    private void OnEnable()
    {
        if (acceptButton != null)
        {
            acceptButton.onClick.RemoveAllListeners();
            acceptButton.onClick.AddListener(() =>
            { 
                policyManager.OnUserPolicyConfirmed();  
            });
        }
    }
}
