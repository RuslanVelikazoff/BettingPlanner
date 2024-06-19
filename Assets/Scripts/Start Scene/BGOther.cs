using UnityEngine;
using UnityEngine.UI;

public class BGOther : MonoBehaviour
{
    [SerializeField] private PolicyManager policyManager;

    [SerializeField] private Button backButton;
    [SerializeField] private Button forwardButton;

    private void OnEnable()
    {
        if (backButton != null)
        {
            backButton.onClick.RemoveAllListeners();
            backButton.onClick.AddListener(() =>
            {
                policyManager.BackButtonAction();
            });
        }

        if (forwardButton != null)
        {
            forwardButton.onClick.RemoveAllListeners();
            forwardButton.onClick.AddListener(() =>
            {
                policyManager.ForwardButtonAction();
            });
        }
    }
}
