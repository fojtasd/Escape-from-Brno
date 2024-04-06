using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuToIntro : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            SceneManager.LoadScene("IntroScreen");
        }
    }
}
