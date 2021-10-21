using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public void StartAgain()
    {
        ScoreScript.appleCounter = 0;
        SceneManager.LoadScene("GameWindow");
    }
    public void PlayGame()
    {
        SceneManager.LoadScene("GameWindow");
    }
}