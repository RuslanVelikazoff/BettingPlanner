using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MainSearch : MonoBehaviour
{
    [SerializeField] 
    private Button searchButton;

    [SerializeField] 
    private TMP_InputField searchInputField;

    [SerializeField] 
    private MainCategoryScrollView matchScrollView;
    [SerializeField]
    private MainCategoryFilter categoryFilter;

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
                matchScrollView.ResetAllMatches();
                matchScrollView.SetScrollViewSearch(searchString);
            });
        }
    }
}
