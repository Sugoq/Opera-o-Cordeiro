using UnityEngine;
using TMPro;

public class TextLanguage : MonoBehaviour
{
    public TranslateText textTranslate;
    public TMP_Text uiText;

    

    private void Start()
    {
        print((int)LanguageKey.PT);
        print((int)LanguageKey.EN);
        print((int)LanguageKey.ES);
        uiText = GetComponentInChildren<TMP_Text>();
        
    }

}
