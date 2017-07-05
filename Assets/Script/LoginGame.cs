using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoginGame : MonoBehaviour {
    public UnityEngine.UI.Button startBtn;
	// Use this for initialization
	void Start () {
        startBtn.onClick.AddListener(delegate()
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("GameingScene");
            Debug.Log("Test:login Scene");
        });
	}
	
	// Update is called once per frame
	void Update () {

	}

}
