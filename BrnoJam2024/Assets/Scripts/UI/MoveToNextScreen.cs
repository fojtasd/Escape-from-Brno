using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScreenNavigator : MonoBehaviour
{
    public GameObject imagePanelFirst;
    public GameObject imagePanelSecond;
    private int enterPressCounter = 0;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            imagePanelFirst.SetActive(false);
            imagePanelSecond.SetActive(true);
            enterPressCounter++;
        }
        if ((Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter)) && enterPressCounter >= 2)
        {
            SceneManager.LoadScene("Game");
        }
    }
}
