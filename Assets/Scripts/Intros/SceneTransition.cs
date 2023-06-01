using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneTransition : MonoBehaviour
{
    public Text LoadingPercentage;
    public Image LoadingProgressBar;

    private static SceneTransition instance;
    private static bool shouldPlayOpeningAnimation = false; 
    
    private Animator componentAnimator;
    private AsyncOperation loadingSceneOperation;
    
    private static GameObject introBackground;
    
    public static void SwitchToScene(string sceneName)
    {
        if (instance.loadingSceneOperation is { isDone: false })
            return;
        
        introBackground.SetActive(true);
        
        if (instance != null) instance.transform.SetAsLastSibling();
        instance.componentAnimator.SetTrigger("sceneClosing");

        //
        instance.loadingSceneOperation = SceneManager.LoadSceneAsync(sceneName);
        
        // Чтобы сцена не начала переключаться пока играет анимация closing:
        instance.loadingSceneOperation.allowSceneActivation = false;
        
        instance.LoadingProgressBar.fillAmount = 0;
    }
    
    private void Start()
    {
        introBackground = GameObject.FindGameObjectWithTag("IntroBackground");
        instance = this;
        
        componentAnimator = GetComponent<Animator>();
        
        if (shouldPlayOpeningAnimation) 
        {
            instance.transform.SetAsLastSibling();
            componentAnimator.SetTrigger("sceneOpening");
            instance.LoadingProgressBar.fillAmount = 1;
            
            // Чтобы если следующий переход будет обычным SceneManager.LoadScene, не проигрывать анимацию opening:
            shouldPlayOpeningAnimation = false;
        }
        else
            introBackground?.SetActive(false);
    }

    public void SetBackgroundInactive()
    {
        introBackground?.SetActive(false);
    }

    public void OnOpeningAnimationOver()
    {
        instance.transform.SetAsFirstSibling();
    }

    public void OnClosingAnimationOver()
    {
        instance.transform.SetAsLastSibling();
        // Чтобы при открытии сцены, куда мы переключаемся, проигралась анимация opening:
        shouldPlayOpeningAnimation = true;
        loadingSceneOperation.allowSceneActivation = true;
    }
}