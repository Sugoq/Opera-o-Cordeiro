using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using Sirenix.OdinInspector;

public class UIController : MonoBehaviour
{
    public static UIController instance;

    
    [InfoBox("Put Here all UI texts to be translated")]
    [PropertySpace(SpaceAfter = 10)]
    [SerializeField] List<TextLanguage> uiTexts = new List<TextLanguage>();
    
    
    [SerializeField] GameObject invocationGroup;
    
    [SerializeField] GameObject invocationSprite;
    [SerializeField] int invocationBlinkTime;
    List<GameObject> invocationsSprites = new List<GameObject>();

    [SerializeField] GameObject pausePanel;


    [SerializeField] bool isEnglish;
    private bool isPaused;

    private void Awake() => instance = this;

    private void OnDestroy() => instance = null;

    private void Start()
    {
        ChangeLanguage();
    }

    private void Update()
    {        
        
        if (Input.GetKeyDown(KeyCode.P)){
            if (SceneManager.GetActiveScene().buildIndex != 1)
                return;
            if (!isPaused)
                PauseGame();
            else UnpauseGame();
        }
      
    }




    public void NewGame()
    {
        PlayerPrefs.SetFloat("Level", 0);
        SceneManager.LoadScene(1);
    }

    public void ContinueGame() => SceneManager.LoadScene(1);

    public void PauseGame()
    {
        Time.timeScale = 0;
        pausePanel.SetActive(true);
        isPaused = true;
        
    }
    public void UnpauseGame()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1;
        isPaused = false;
    }
    public void MainMenu()
    {
        AudioManager.instance.DestroyMe();
        SceneManager.LoadScene(0);
        UnpauseGame();
        
    }
    public void QuitGame() => Application.Quit();

    public void SetMaxInvocationsUI(int maxInvocations)
    {
        for(int i = 0; i < maxInvocations; i++)
        {
            GameObject g = Instantiate(invocationSprite, invocationGroup.transform);
            invocationsSprites.Add(g);            
        }
    }

    public void UpdateInvocations()
    {
        StartCoroutine(UpdateInvocationsRoutine());
    }

    IEnumerator UpdateInvocationsRoutine()
    {
        if (invocationsSprites.Count < 1) StopCoroutine(UpdateInvocationsRoutine());
        bool blink = false;
        GameObject g = invocationsSprites[invocationsSprites.Count - 1];
        invocationsSprites.RemoveAt(invocationsSprites.Count - 1);
        for (float t = 0; t < 1; t += Time.deltaTime/ invocationBlinkTime)
        {
            g.SetActive(blink);
            blink = !blink;
            yield return null;
        }
        Destroy(g);
    }

    public void ChangeLanguage()
    {
        if (isEnglish)
        {
            foreach(TextLanguage x in uiTexts)
            {
                x.uiText.text = x.textTranslate.texts[(int)LanguageKey.PT];
            }
        }

        else 
            foreach (TextLanguage x in uiTexts)
            {
                x.uiText.text = x.textTranslate.texts[(int)LanguageKey.EN];
            }
        isEnglish = !isEnglish;

    }

}
