using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Sirenix.OdinInspector;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;
    
    public List<GameObject> levels = new List<GameObject>();
    private int currentLevel;

    private void Awake() => instance = this;

    private void OnDestroy() => instance = null;

    private void Start()
    {
        currentLevel = PlayerPrefs.GetInt("Level", 0);
        transform.position = Vector3.zero;
        Instantiate(levels[currentLevel], transform.position, Quaternion.identity);
    }


    public void NextLevel()
    {
        PlayerPrefs.SetInt("Level", (currentLevel+1) % levels.Count);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);       
    }

    public void ResetLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    [Button("Reset Levels")]
    public void ClearPlayerPrefs()
    {
        PlayerPrefs.DeleteAll();
    }

}
