using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingManager : MonoBehaviour
{
    private bool load = false;

    private float timeLeft;
    private float loadTime = 2f;

    [SerializeField] private Slider loadingSlider;

    private void Update()
    {
        if (load)
        {
            timeLeft += Time.deltaTime;
            loadingSlider.value = timeLeft;
            
            if (timeLeft >= loadTime)
            {
                SceneManager.LoadScene(1);
            }
        }
    }

    public void StartLoading()
    {
        load = true;
    }
}
