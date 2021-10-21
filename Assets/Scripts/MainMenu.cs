using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartGame()
    {
        ScoreScript.appleCounter = 0;
        SceneManager.LoadScene("GameWindow");
    }

    public void BackInMenu()
    {
        SceneManager.LoadScene("StartWindow");
    }

    public void OpenRulesWindow()
    {
        SceneManager.LoadScene("RulesWindow");
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Qiut!");
    }
}