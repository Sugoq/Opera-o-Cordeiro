using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    public void NewGame()
    {
        PlayerPrefs.SetFloat("Level", 0);
        SceneManager.LoadScene(1);
    }

    public void ContinueGame() => SceneManager.LoadScene(1);

    public void QuitGame() => Application.Quit();

}
