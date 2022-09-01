using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

[CreateAssetMenu(fileName = "Text", menuName = "UI/Text", order = 0)]
public class TranslateText : ScriptableObject
{
    [InfoBox("First is English and Second Portuguese")]
    public List<string> texts;
}

public enum LanguageKey
{
    EN = 0, PT = 1, ES = 15
}

