using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class TextBoxManager : MonoBehaviour
{
    [SerializeField] Yarn.Unity.DialogueUI di;
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
            di.MarkLineComplete();
            Debug.Log("Pressed primary button.");
    }

}
