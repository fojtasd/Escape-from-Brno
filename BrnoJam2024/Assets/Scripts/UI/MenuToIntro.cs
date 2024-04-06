using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuToIntro : MonoBehaviour
{
    void Update()
    {
    }

    public void StartNewGame()
    {
        SceneManager.LoadScene("IntroScreen");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
