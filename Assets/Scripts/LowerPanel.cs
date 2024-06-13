using UnityEngine;
using UnityEngine.UI;

public class LowerPanel : MonoBehaviour
{
    [SerializeField] private Button menuButton;
    [SerializeField] private Sprite menuActiveSprite;
    [SerializeField] private Sprite menuInactiveSprite;

    [Space(13)]
    
    [SerializeField] private Button matchButton;
    [SerializeField] private Sprite matchActiveSprite;
    [SerializeField] private Sprite matchInactiveSprite;

    [Space(13)]
    
    [SerializeField] private Button betButton;
    [SerializeField] private Sprite betActiveSprite;
    [SerializeField] private Sprite betInactiveSprite;

    [Space(13)]
    
    [SerializeField] private GameObject menuPanel;
    [SerializeField] private GameObject matchPanel;
    [SerializeField] private GameObject betPanel;

    private void Start()
    {
        SetStartConfiguration();
        ButtonClickAction();
    }

    private void SetStartConfiguration()
    {
        menuButton.GetComponent<Image>().sprite = menuActiveSprite;
        matchButton.GetComponent<Image>().sprite = matchInactiveSprite;
        betButton.GetComponent<Image>().sprite = betInactiveSprite;
        
        menuPanel.SetActive(true);
        matchPanel.SetActive(false);
        betPanel.SetActive(false);
    }

    private void ButtonClickAction()
    {
        if (menuButton != null)
        {
            menuButton.onClick.RemoveAllListeners();
            menuButton.onClick.AddListener(OpenMenuPanel);
        }

        if (matchButton != null)
        {
            matchButton.onClick.RemoveAllListeners();
            matchButton.onClick.AddListener(OpenMatchPanel);
        }

        if (betButton != null)
        {
            betButton.onClick.RemoveAllListeners();
            betButton.onClick.AddListener(OpenBetPanel);
        }
    }

    private void OpenMenuPanel()
    {
        menuButton.GetComponent<Image>().sprite = menuActiveSprite;
        matchButton.GetComponent<Image>().sprite = matchInactiveSprite;
        betButton.GetComponent<Image>().sprite = betInactiveSprite;
                
        menuPanel.SetActive(true);
        matchPanel.SetActive(false);
        betPanel.SetActive(false);
    }

    private void OpenMatchPanel()
    {
        menuButton.GetComponent<Image>().sprite = menuInactiveSprite;
        matchButton.GetComponent<Image>().sprite = matchActiveSprite;
        betButton.GetComponent<Image>().sprite = betInactiveSprite;
                
        menuPanel.SetActive(false);
        matchPanel.SetActive(true);
        betPanel.SetActive(false);
    }

    private void OpenBetPanel()
    {
        menuButton.GetComponent<Image>().sprite = menuInactiveSprite;
        matchButton.GetComponent<Image>().sprite = matchInactiveSprite;
        betButton.GetComponent<Image>().sprite = betActiveSprite;
                
        menuPanel.SetActive(false);
        matchPanel.SetActive(false);
        betPanel.SetActive(true);
    }
}
