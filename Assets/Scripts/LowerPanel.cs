using UnityEngine;
using UnityEngine.UI;

public class LowerPanel : MonoBehaviour
{
    [SerializeField] 
    private Button menuButton;
    [SerializeField] 
    private Sprite menuActiveSprite;
    [SerializeField] 
    private Sprite menuInactiveSprite;

    [Space(13)]
    
    [SerializeField] 
    private Button matchButton;
    [SerializeField] 
    private Sprite matchActiveSprite;
    [SerializeField] 
    private Sprite matchInactiveSprite;

    [Space(13)]
    
    [SerializeField] 
    private Button betButton;
    [SerializeField] 
    private Sprite betActiveSprite;
    [SerializeField] 
    private Sprite betInactiveSprite;

    [Space(13)]
    
    [SerializeField] 
    private Button newsButton;
    [SerializeField] 
    private Sprite newsActiveSprite;
    [SerializeField] 
    private Sprite newsInactiveSprite;

    [Space(13)]
    
    [SerializeField] 
    private Button recordsButton;
    [SerializeField] 
    private Sprite recordsActiveSprite;
    [SerializeField] 
    private Sprite recordsInactiveSprite;
    
    [Space(13)]
    
    [SerializeField]
    private GameObject menuPanel;
    [SerializeField] 
    private GameObject matchPanel;
    [SerializeField] 
    private GameObject betPanel;
    [SerializeField] 
    private GameObject newsPanel;
    [SerializeField] 
    private GameObject recordsPanel;

    private void Start()
    {
        SetStartConfiguration();
        ButtonClickAction();
    }

    private void OnEnable()
    {
        SetOnEnableConfiguration();
    }

    private void SetStartConfiguration()
    {
        menuButton.GetComponent<Image>().sprite = menuActiveSprite;
        matchButton.GetComponent<Image>().sprite = matchInactiveSprite;
        betButton.GetComponent<Image>().sprite = betInactiveSprite;
        newsButton.GetComponent<Image>().sprite = newsInactiveSprite;
        recordsButton.GetComponent<Image>().sprite = recordsInactiveSprite;
        
        menuPanel.SetActive(true);
        matchPanel.SetActive(false);
        betPanel.SetActive(false);
        newsPanel.SetActive(false);
        recordsPanel.SetActive(false);
    }

    private void SetOnEnableConfiguration()
    {
        if (menuPanel.activeInHierarchy)
        {
            menuButton.GetComponent<Image>().sprite = menuActiveSprite;
            matchButton.GetComponent<Image>().sprite = matchInactiveSprite;
            betButton.GetComponent<Image>().sprite = betInactiveSprite;
            newsButton.GetComponent<Image>().sprite = newsInactiveSprite;
            recordsButton.GetComponent<Image>().sprite = recordsInactiveSprite;
        }

        if (matchPanel.activeInHierarchy)
        {
            menuButton.GetComponent<Image>().sprite = menuInactiveSprite;
            matchButton.GetComponent<Image>().sprite = matchActiveSprite;
            betButton.GetComponent<Image>().sprite = betInactiveSprite;
            newsButton.GetComponent<Image>().sprite = newsInactiveSprite;
            recordsButton.GetComponent<Image>().sprite = recordsInactiveSprite;
        }

        if (betPanel.activeInHierarchy)
        {
            menuButton.GetComponent<Image>().sprite = menuInactiveSprite;
            matchButton.GetComponent<Image>().sprite = matchInactiveSprite;
            betButton.GetComponent<Image>().sprite = betActiveSprite;
            newsButton.GetComponent<Image>().sprite = newsInactiveSprite;
            recordsButton.GetComponent<Image>().sprite = recordsInactiveSprite;
        }

        if (newsPanel.activeInHierarchy)
        {
            menuButton.GetComponent<Image>().sprite = menuInactiveSprite;
            matchButton.GetComponent<Image>().sprite = matchInactiveSprite;
            betButton.GetComponent<Image>().sprite = betInactiveSprite;
            newsButton.GetComponent<Image>().sprite = newsActiveSprite;
            recordsButton.GetComponent<Image>().sprite = recordsInactiveSprite;
        }

        if (recordsPanel.activeInHierarchy)
        {
            menuButton.GetComponent<Image>().sprite = menuInactiveSprite;
            matchButton.GetComponent<Image>().sprite = matchInactiveSprite;
            betButton.GetComponent<Image>().sprite = betInactiveSprite;
            newsButton.GetComponent<Image>().sprite = newsInactiveSprite;
            recordsButton.GetComponent<Image>().sprite = recordsActiveSprite;
        }
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

        if (newsButton != null)
        {
            newsButton.onClick.RemoveAllListeners();
            newsButton.onClick.AddListener(OpenNewsPanel);
        }

        if (recordsButton != null)
        {
            recordsButton.onClick.RemoveAllListeners();
            recordsButton.onClick.AddListener(OpenRecordsPanel);
        }
    }

    private void OpenMenuPanel()
    {
        menuButton.GetComponent<Image>().sprite = menuActiveSprite;
        matchButton.GetComponent<Image>().sprite = matchInactiveSprite;
        betButton.GetComponent<Image>().sprite = betInactiveSprite;
        newsButton.GetComponent<Image>().sprite = newsInactiveSprite;
        recordsButton.GetComponent<Image>().sprite = recordsInactiveSprite;
                
        menuPanel.SetActive(true);
        matchPanel.SetActive(false);
        betPanel.SetActive(false);
        newsPanel.SetActive(false);
        recordsPanel.SetActive(false);
    }

    private void OpenMatchPanel()
    {
        menuButton.GetComponent<Image>().sprite = menuInactiveSprite;
        matchButton.GetComponent<Image>().sprite = matchActiveSprite;
        betButton.GetComponent<Image>().sprite = betInactiveSprite;
        newsButton.GetComponent<Image>().sprite = newsInactiveSprite;
        recordsButton.GetComponent<Image>().sprite = recordsInactiveSprite;
                
        menuPanel.SetActive(false);
        matchPanel.SetActive(true);
        betPanel.SetActive(false);
        newsPanel.SetActive(false);
        recordsPanel.SetActive(false);
    }

    private void OpenBetPanel()
    {
        menuButton.GetComponent<Image>().sprite = menuInactiveSprite;
        matchButton.GetComponent<Image>().sprite = matchInactiveSprite;
        betButton.GetComponent<Image>().sprite = betActiveSprite;
        newsButton.GetComponent<Image>().sprite = newsInactiveSprite;
        recordsButton.GetComponent<Image>().sprite = recordsInactiveSprite;
                
        menuPanel.SetActive(false);
        matchPanel.SetActive(false);
        betPanel.SetActive(true);
        newsPanel.SetActive(false);
        recordsPanel.SetActive(false);
    }

    private void OpenNewsPanel()
    {
        menuButton.GetComponent<Image>().sprite = menuInactiveSprite;
        matchButton.GetComponent<Image>().sprite = matchInactiveSprite;
        betButton.GetComponent<Image>().sprite = betInactiveSprite;
        newsButton.GetComponent<Image>().sprite = newsActiveSprite;
        recordsButton.GetComponent<Image>().sprite = recordsInactiveSprite;
                
        menuPanel.SetActive(false);
        matchPanel.SetActive(false);
        betPanel.SetActive(false);
        newsPanel.SetActive(true);
        recordsPanel.SetActive(false);
    }

    private void OpenRecordsPanel()
    {
        menuButton.GetComponent<Image>().sprite = menuInactiveSprite;
        matchButton.GetComponent<Image>().sprite = matchInactiveSprite;
        betButton.GetComponent<Image>().sprite = betInactiveSprite;
        newsButton.GetComponent<Image>().sprite = newsInactiveSprite;
        recordsButton.GetComponent<Image>().sprite = recordsActiveSprite;
                
        menuPanel.SetActive(false);
        matchPanel.SetActive(false);
        betPanel.SetActive(false);
        newsPanel.SetActive(false);
        recordsPanel.SetActive(true);
    }
}
