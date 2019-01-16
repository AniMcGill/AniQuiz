using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class LoadInfo : MonoBehaviour {
    Text output;
	// Use this for initialization
	void Start () {
    }

    public void LoadScene(string nextScene)
    {
        SceneManager.LoadScene(nextScene);
    }
}
