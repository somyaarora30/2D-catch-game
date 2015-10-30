using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Score : MonoBehaviour {
    public Text scoreText;
    public int ballValue;
    private int score;

	// Use this for initialization
	void Start () {
        score = 0;
        UpdateScore();
	
	}
	
    void OnTriggerEnter2D()
    { score += ballValue;
        UpdateScore();
    }
	// Update is called once per frame
	void UpdateScore () {
        scoreText.text = "Score:" + score;
	
	}
}
