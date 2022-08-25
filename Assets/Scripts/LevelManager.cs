using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Sirenix.OdinInspector;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;

    public bool forceLevel;
    public int levelToLoad;
    
    public List<GameObject> levels = new();
    private int currentLevel;

    private void Awake() => instance = this;

    private void OnDestroy() => instance = null;

    private void Start()
    {
        currentLevel = forceLevel? levelToLoad : PlayerPrefs.GetInt("Level", 0);
        transform.position = Vector3.zero;
        Instantiate(levels[currentLevel], transform.position, Quaternion.identity);
        print($"Level Atual: {levels[currentLevel]}");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
            ResetLevel();
    }

    public void NextLevel()
    {     
        if(!forceLevel)PlayerPrefs.SetInt("Level", (currentLevel + 1) % levels.Count);
        
        SceneManager.LoadScene(1);          
    }

    public void ResetLevel()
    {
        SceneManager.LoadScene(1);
    }

    [PropertySpace(SpaceBefore = 10)]
    [Button]
    private void ChangeSavedLevel(int level)
    {
        PlayerPrefs.SetInt("Level", level % levels.Count);
    }



}
