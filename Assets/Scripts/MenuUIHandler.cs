using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class MenuUIHandler : MonoBehaviour
{
    public TMP_InputField _InputField;
    public TMP_Text BestScoreText;
    // Start is called before the first frame update
    void Start()
    {
        BestScoreText.text = $"Best Score: {NameManager.Instance.bestScore.Name} : {NameManager.Instance.bestScore.Score}";
        _InputField.placeholder.GetComponent<TMP_Text>().text = NameManager.Instance.bestScore.Name;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartButton()
    {
        NameManager.Instance.Name = _InputField.text;
        SceneManager.LoadScene(1);
    }

    public void QuitButton()
    {
        Application.Quit();
    }
}
