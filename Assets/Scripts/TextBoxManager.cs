using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Yarn.Unity;

public class TextBoxManager : MonoBehaviour
{
    [SerializeField] Image characterPortrait;
    [SerializeField] TextMeshProUGUI text_dialogue, text_CharName;
    
    public DialogueUI di;

    public DialogueRunner dr {get; private set;}
    Dictionary<string, UnityEditor.U2D.Animation.CharacterData> characterDatabase = new Dictionary<string, UnityEditor.U2D.Animation.CharacterData>();

    private void Start() {
        dr = GetComponent<DialogueRunner>();
    }
    
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
            di.MarkLineComplete();
    }

}
