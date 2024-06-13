using UnityEngine;
using UnityEngine.UI;

public class CategoryFilter : MonoBehaviour
{
    [SerializeField] 
    private Button soccerButton;
    [SerializeField] 
    private Sprite soccerActiveSprite;
    [SerializeField] 
    private Sprite soccerInactiveSprite;
    
    [Space(13)]

    [SerializeField] 
    private Button basketballButton;
    [SerializeField] 
    private Sprite basketballActiveSprite;
    [SerializeField] 
    private Sprite basketballInactiveSprite;
    
    [Space(13)]

    [SerializeField] 
    private Button volleyballButton;
    [SerializeField]
    private Sprite volleyballActiveSprite;
    [SerializeField]
    private Sprite volleyballInactiveSprite;
    
    [Space(13)]

    [SerializeField] 
    private Button baseballButton;
    [SerializeField] 
    private Sprite baseballActiveSprite;
    [SerializeField] 
    private Sprite baseballInactiveSprite;
    
    [Space(13)]

    [SerializeField] 
    private Button footballButton;
    [SerializeField] 
    private Sprite footballActiveSprite;
    [SerializeField] 
    private Sprite footballInactiveSprite;
    
    [Space(13)]

    [SerializeField] 
    private Button cricketButton;
    [SerializeField] 
    private Sprite cricketActiveSprite;
    [SerializeField] 
    private Sprite cricketInactiveSprite;

    private GameData.TypeOfSport selectedCategory;

    private Vector2 selectedSize = new Vector2(350, 150);
    private Vector2 standartSize = new Vector2(150, 150);

    private void OnEnable()
    {
        selectedCategory = GameData.TypeOfSport.Null;
        SetButtonSize();
        SetButtonSize();
        ButtonClickAction();
    }

    private void ButtonClickAction()
    {
        if (soccerButton != null)
        {
            soccerButton.onClick.RemoveAllListeners();
            soccerButton.onClick.AddListener(() =>
            {
                selectedCategory = GameData.TypeOfSport.Soccer;
                SetButtonSprite();
                SetButtonSize();
            });
        }

        if (basketballButton != null)
        {
            basketballButton.onClick.RemoveAllListeners();
            basketballButton.onClick.AddListener(() =>
            {
                selectedCategory = GameData.TypeOfSport.Basketball;
                SetButtonSprite();
                SetButtonSize();
            });
        }

        if (volleyballButton != null)
        {
            volleyballButton.onClick.RemoveAllListeners();
            volleyballButton.onClick.AddListener(() =>
            {
                selectedCategory = GameData.TypeOfSport.Volleyball;
                SetButtonSprite();
                SetButtonSize();
            });
        }

        if (baseballButton != null)
        {
            baseballButton.onClick.RemoveAllListeners();
            baseballButton.onClick.AddListener(() =>
            {
                selectedCategory = GameData.TypeOfSport.Baseball;
                SetButtonSprite();
                SetButtonSize();
            });
        }

        if (footballButton != null)
        {
            footballButton.onClick.RemoveAllListeners();
            footballButton.onClick.AddListener(() =>
            {
                selectedCategory = GameData.TypeOfSport.Football;
                SetButtonSprite();
                SetButtonSize();
            });
        }

        if (cricketButton != null)
        {
            cricketButton.onClick.RemoveAllListeners();
            cricketButton.onClick.AddListener(() =>
            {
                selectedCategory = GameData.TypeOfSport.Cricket;
                SetButtonSprite();
                SetButtonSize();
            });
        }
    }

    private void SetButtonSprite()
    {
        switch (selectedCategory)
        {
            case GameData.TypeOfSport.Null:
                soccerButton.GetComponent<Image>().sprite = soccerInactiveSprite;
                basketballButton.GetComponent<Image>().sprite = basketballInactiveSprite;
                volleyballButton.GetComponent<Image>().sprite = volleyballInactiveSprite;
                baseballButton.GetComponent<Image>().sprite = baseballInactiveSprite;
                footballButton.GetComponent<Image>().sprite = footballInactiveSprite;
                cricketButton.GetComponent<Image>().sprite = cricketInactiveSprite;
                break;
            case GameData.TypeOfSport.Soccer:
                soccerButton.GetComponent<Image>().sprite = soccerActiveSprite;
                basketballButton.GetComponent<Image>().sprite = basketballInactiveSprite;
                volleyballButton.GetComponent<Image>().sprite = volleyballInactiveSprite;
                baseballButton.GetComponent<Image>().sprite = baseballInactiveSprite;
                footballButton.GetComponent<Image>().sprite = footballInactiveSprite;
                cricketButton.GetComponent<Image>().sprite = cricketInactiveSprite;
                break;
            case GameData.TypeOfSport.Basketball:
                soccerButton.GetComponent<Image>().sprite = soccerInactiveSprite;
                basketballButton.GetComponent<Image>().sprite = basketballActiveSprite;
                volleyballButton.GetComponent<Image>().sprite = volleyballInactiveSprite;
                baseballButton.GetComponent<Image>().sprite = baseballInactiveSprite;
                footballButton.GetComponent<Image>().sprite = footballInactiveSprite;
                cricketButton.GetComponent<Image>().sprite = cricketInactiveSprite;
                break;
            case GameData.TypeOfSport.Volleyball:
                soccerButton.GetComponent<Image>().sprite = soccerInactiveSprite;
                basketballButton.GetComponent<Image>().sprite = basketballInactiveSprite;
                volleyballButton.GetComponent<Image>().sprite = volleyballActiveSprite;
                baseballButton.GetComponent<Image>().sprite = baseballInactiveSprite;
                footballButton.GetComponent<Image>().sprite = footballInactiveSprite;
                cricketButton.GetComponent<Image>().sprite = cricketInactiveSprite;
                break;
            case GameData.TypeOfSport.Baseball:
                soccerButton.GetComponent<Image>().sprite = soccerInactiveSprite;
                basketballButton.GetComponent<Image>().sprite = basketballInactiveSprite;
                volleyballButton.GetComponent<Image>().sprite = volleyballInactiveSprite;
                baseballButton.GetComponent<Image>().sprite = baseballActiveSprite;
                footballButton.GetComponent<Image>().sprite = footballInactiveSprite;
                cricketButton.GetComponent<Image>().sprite = cricketInactiveSprite;
                break;
            case GameData.TypeOfSport.Football:
                soccerButton.GetComponent<Image>().sprite = soccerInactiveSprite;
                basketballButton.GetComponent<Image>().sprite = basketballInactiveSprite;
                volleyballButton.GetComponent<Image>().sprite = volleyballInactiveSprite;
                baseballButton.GetComponent<Image>().sprite = baseballInactiveSprite;
                footballButton.GetComponent<Image>().sprite = footballActiveSprite;
                cricketButton.GetComponent<Image>().sprite = cricketInactiveSprite;
                break;
            case GameData.TypeOfSport.Cricket:
                soccerButton.GetComponent<Image>().sprite = soccerInactiveSprite;
                basketballButton.GetComponent<Image>().sprite = basketballInactiveSprite;
                volleyballButton.GetComponent<Image>().sprite = volleyballInactiveSprite;
                baseballButton.GetComponent<Image>().sprite = baseballInactiveSprite;
                footballButton.GetComponent<Image>().sprite = footballInactiveSprite;
                cricketButton.GetComponent<Image>().sprite = cricketActiveSprite;
                break;
        }
    }

    private void SetButtonSize()
    {
        switch (selectedCategory)
        {
            case GameData.TypeOfSport.Null:
                soccerButton.GetComponent<RectTransform>().sizeDelta = standartSize;
                basketballButton.GetComponent<RectTransform>().sizeDelta = standartSize;
                volleyballButton.GetComponent<RectTransform>().sizeDelta = standartSize;
                baseballButton.GetComponent<RectTransform>().sizeDelta = standartSize;
                footballButton.GetComponent<RectTransform>().sizeDelta = standartSize;
                cricketButton.GetComponent<RectTransform>().sizeDelta = standartSize;
                break;
            case GameData.TypeOfSport.Soccer:
                soccerButton.GetComponent<RectTransform>().sizeDelta = selectedSize;
                basketballButton.GetComponent<RectTransform>().sizeDelta = standartSize;
                volleyballButton.GetComponent<RectTransform>().sizeDelta = standartSize;
                baseballButton.GetComponent<RectTransform>().sizeDelta = standartSize;
                footballButton.GetComponent<RectTransform>().sizeDelta = standartSize;
                cricketButton.GetComponent<RectTransform>().sizeDelta = standartSize;
                break;
            case GameData.TypeOfSport.Basketball:
                soccerButton.GetComponent<RectTransform>().sizeDelta = standartSize;
                basketballButton.GetComponent<RectTransform>().sizeDelta = selectedSize;
                volleyballButton.GetComponent<RectTransform>().sizeDelta = standartSize;
                baseballButton.GetComponent<RectTransform>().sizeDelta = standartSize;
                footballButton.GetComponent<RectTransform>().sizeDelta = standartSize;
                cricketButton.GetComponent<RectTransform>().sizeDelta = standartSize;
                break;
            case GameData.TypeOfSport.Volleyball:
                soccerButton.GetComponent<RectTransform>().sizeDelta = standartSize;
                basketballButton.GetComponent<RectTransform>().sizeDelta = standartSize;
                volleyballButton.GetComponent<RectTransform>().sizeDelta = selectedSize;
                baseballButton.GetComponent<RectTransform>().sizeDelta = standartSize;
                footballButton.GetComponent<RectTransform>().sizeDelta = standartSize;
                cricketButton.GetComponent<RectTransform>().sizeDelta = standartSize;
                break;
            case GameData.TypeOfSport.Baseball:
                soccerButton.GetComponent<RectTransform>().sizeDelta = standartSize;
                basketballButton.GetComponent<RectTransform>().sizeDelta = standartSize;
                volleyballButton.GetComponent<RectTransform>().sizeDelta = standartSize;
                baseballButton.GetComponent<RectTransform>().sizeDelta = selectedSize;
                footballButton.GetComponent<RectTransform>().sizeDelta = standartSize;
                cricketButton.GetComponent<RectTransform>().sizeDelta = standartSize;
                break;
            case GameData.TypeOfSport.Football:
                soccerButton.GetComponent<RectTransform>().sizeDelta = standartSize;
                basketballButton.GetComponent<RectTransform>().sizeDelta = standartSize;
                volleyballButton.GetComponent<RectTransform>().sizeDelta = standartSize;
                baseballButton.GetComponent<RectTransform>().sizeDelta = standartSize;
                footballButton.GetComponent<RectTransform>().sizeDelta = selectedSize;
                cricketButton.GetComponent<RectTransform>().sizeDelta = standartSize;
                break;
            case GameData.TypeOfSport.Cricket:
                soccerButton.GetComponent<RectTransform>().sizeDelta = standartSize;
                basketballButton.GetComponent<RectTransform>().sizeDelta = standartSize;
                volleyballButton.GetComponent<RectTransform>().sizeDelta = standartSize;
                baseballButton.GetComponent<RectTransform>().sizeDelta = standartSize;
                footballButton.GetComponent<RectTransform>().sizeDelta = standartSize;
                cricketButton.GetComponent<RectTransform>().sizeDelta = selectedSize;
                break;
        }
    }
}
