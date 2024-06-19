using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PolicyManager : MonoBehaviour
{
    [SerializeField] 
    private LoadingManager loadingManager;
    [SerializeField]
    private UniWebView webBrowser;
    [SerializeField]
    private string policyUrl;
    [SerializeField]
    private GameObject noConnectionUI;
    [SerializeField]
    private GameObject loadingIndicatorUI;
    [SerializeField]
    private GameObject policyBgUI, alternateBgUI;

    private bool isPolicyPageLoaded = false;

    private void Start()
    {
        InitializeScreenOrientation();
        VerifyInternetConnection();
    }

    private void InitializeScreenOrientation()
    {
        Screen.orientation = ScreenOrientation.Portrait;
    }

    private void VerifyInternetConnection()
    {
        if (IsInternetUnreachable())
        {
            ShowNoConnectionUI();
        }
        else
        {
            HandlePolicyConfirmation();
        }
    }

    private bool IsInternetUnreachable()
    {
        return Application.internetReachability == NetworkReachability.NotReachable;
    }

    private void ShowNoConnectionUI()
    {
        loadingIndicatorUI.SetActive(false);
        noConnectionUI.SetActive(true);
    }

    private IEnumerator AttemptReconnectAndContinue()
    {
        while (IsInternetUnreachable())
        {
            ShowNoConnectionUI();
            yield return new WaitForSeconds(5f);
        }

        LoadPolicyWebPage();
    }

    private void LoadPolicyWebPage()
    {
        noConnectionUI.SetActive(false);
        loadingIndicatorUI.SetActive(true);
        BeginPolicyPageLoading();
    }

    private void BeginPolicyPageLoading()
    {
        webBrowser.OnPageFinished += OnPolicyPageLoadComplete;
        webBrowser.Load(policyUrl);
    }

    private void OnPolicyPageLoadComplete(UniWebView webBrowser, int statusCode, string currentUrl)
    {
        if (isPolicyPageLoaded) return;

        UpdateUIForLoadedPage(currentUrl);
        webBrowser.Show();

        if (policyUrl != currentUrl)
        {
            Destroy(this.gameObject);
        }

        isPolicyPageLoaded = true;
    }

    private void UpdateUIForLoadedPage(string currentUrl)
    {
        bool isPolicyPage = currentUrl == policyUrl;
        GameObject activeBackground = isPolicyPage ? policyBgUI : alternateBgUI;
        activeBackground.SetActive(true);
        Screen.orientation = isPolicyPage ? ScreenOrientation.Portrait : ScreenOrientation.AutoRotation;
        PlayerPrefs.SetString("PolicyConfirmation", isPolicyPage ? "Accepted" : currentUrl);
    }

    public void OnUserPolicyConfirmed()
    {
        HandlePolicyConfirmation();
    }

    private void HandlePolicyConfirmation()
    {
        string confirmationStatus = PlayerPrefs.GetString("PolicyConfirmation", "");
        if (string.IsNullOrEmpty(confirmationStatus))
        {
            StartCoroutine(AttemptReconnectAndContinue());
        }
        else if (confirmationStatus == "Accepted")
        {
            policyBgUI.SetActive(false);
            webBrowser.gameObject.SetActive(false);
            loadingIndicatorUI.SetActive(true);
            loadingManager.StartLoading();
        }
        else
        {
            DisplayPreviouslyLoadedPolicyPage(confirmationStatus);
        }
    }

    private void DisplayPreviouslyLoadedPolicyPage(string url)
    {
        webBrowser.Load(url);
        webBrowser.Show();
        alternateBgUI.SetActive(true);
    }

    public void BackButtonAction()
    {
        if (webBrowser.CanGoBack)
        {
            webBrowser.GoBack();
        }
    }

    public void ForwardButtonAction()
    {
        if (webBrowser.CanGoForward)
        {
            webBrowser.GoForward();
        }
    }
}
