using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour {

    public static GameControl control;
    public Dictionary<string, int> players = new Dictionary<string, int>();

    private int score1;
    private int score2;
    private int score3;
    private int score4;
    public ArrayList musicButtonState = new ArrayList();
    public ArrayList pictureButtonState = new ArrayList();
    public ArrayList questionButtonState = new ArrayList();

    void Awake () {
	    if(control == null)
            {
                DontDestroyOnLoad(gameObject);
                control = this;
            }
        else if(control != this)
            {
                Destroy(gameObject);
            }
    }

    public int GetScore(int n)
    {
        switch (n)
        {
            case 1:
                return score1;
            case 2:
                return score2;
            case 3:
                return score3;
            case 4:
                return score4;
            default:
                return 0;
        }
    }

    public void SaveButtonState()
    {
        var uiRoot = GameObject.Find("CategoryButtons");
        ArrayList buttonState = new ArrayList();
        if (uiRoot != null)
        {
            bool includeInactiveGameobjects = true;
            var buttons = uiRoot.GetComponentsInChildren<Button>(includeInactiveGameobjects);
            foreach (Button uibutton in buttons)
            {
                buttonState.Add(uibutton.IsInteractable());
            }
        }
        if (SceneManager.GetActiveScene().name == "music")
        {
            musicButtonState = buttonState;
        }
        else if (SceneManager.GetActiveScene().name == "picture")
        {
            pictureButtonState = buttonState;
        }
        else if (SceneManager.GetActiveScene().name == "question")
        {
            questionButtonState = buttonState;
        }
    }

    public void LoadButtonState()
    {
        var uiRoot = GameObject.Find("CategoryButtons");
        ArrayList buttonState = new ArrayList();
        if (SceneManager.GetActiveScene().name == "music")
        {
            buttonState = musicButtonState;
        }
        else if (SceneManager.GetActiveScene().name == "picture")
        {
            buttonState = pictureButtonState;
        }
        else if (SceneManager.GetActiveScene().name == "question")
        {
            buttonState = questionButtonState;
        }

        if (uiRoot != null && buttonState.Count!=0)
        {
            bool includeInactiveGameobjects = true;
            var buttons = uiRoot.GetComponentsInChildren<Button>(includeInactiveGameobjects);
            int i = 0;
            foreach (Button uibutton in buttons)
            {
                uibutton.interactable = (bool)  buttonState[i];
                i++;
            }
        }
        buttonState.Clear();
}

    public void SaveScore(int a, int b, int c, int d)
    {
        score1 = a; score2 = b; score3 = c; score4 = d;
    }

    public void LoadScene(string nextScene)
    {
        control.SaveButtonState();
        SceneManager.LoadScene(nextScene);
    }
}
