using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuToIntro : MonoBehaviour
{
    public void StartNewGame()
    {
        SceneManager.LoadScene("IntroScreen");
    }

    public void GoToCredits()
    {
        SceneManager.LoadScene("Credits");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
