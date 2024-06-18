using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BetSearch : MonoBehaviour
{
    [SerializeField] 
    private Button searchButton;

    [SerializeField] 
    private TMP_InputField searchInputField;

    [SerializeField] 
    private BetCategoryScrollView betScrollView;
    [SerializeField]
    private BetCategoryFilter categoryFilter;

    private string searchString;

    private void OnEnable()
    {
        ButtonClickAction();
    }

    private void ButtonClickAction()
    {
        if (searchButton != null)
        {
            searchButton.onClick.RemoveAllListeners();
            searchButton.onClick.AddListener(() =>
            {
                categoryFilter.ResetCategory();
                searchString = searchInputField.text;
                betScrollView.ResetAllMatches();
                betScrollView.SetScrollViewSearch(searchString);
            });
        }
    }
}
