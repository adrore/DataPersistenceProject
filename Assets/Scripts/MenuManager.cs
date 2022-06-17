using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif

[DefaultExecutionOrder(1000)]
public class MenuManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI recordText;
    [SerializeField] TMP_InputField nameText;

    // Start is called before the first frame update
    void Start()
    {
        PersistentManager.instance.LoadRecord();
        recordText.text = PersistentManager.actualRecord;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartNew()
    {
        SceneManager.LoadScene(1);
    }

    public void SetName()
    {
        PersistentManager.actualName = nameText.text;
        Debug.Log(PersistentManager.actualName);
    }

    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
