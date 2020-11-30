using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class HUD : MonoBehaviour {

	public Level level;
	public GameOver gameOver;

	public UnityEngine.UI.Text remainingText;
	public UnityEngine.UI.Text remainingSubtext;
	public UnityEngine.UI.Text targetText;
	public UnityEngine.UI.Text targetSubtext;
	public UnityEngine.UI.Text scoreText;
	public UnityEngine.UI.Text levelText;
	public UnityEngine.UI.Image[] stars;

	private int starIdx = 0;

	// Use this for initialization
	void Start () {
		for (int i = 0; i < stars.Length; i++) {
			if (i == starIdx) {
				stars [i].enabled = true;
			} else {
				stars [i].enabled = false;
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void SetScore(int score)
	{
		scoreText.text = score.ToString ();

		int visibleStar = 0;

		if (score >= level.score1Star && score < level.score2Star) {
			visibleStar = 1;
		} else if (score >= level.score2Star && score < level.score3Star) {
			visibleStar = 2;
		} else if (score >= level.score3Star) {
			visibleStar = 3;
		}

		for (int i = 0; i < stars.Length; i++) {
			if (i == visibleStar) {
				stars [i].enabled = true;
			} else {
				stars [i].enabled = false;
			}
		}

		starIdx = visibleStar;
	}

	public void SetTarget(int target)
	{
		targetText.text = target.ToString ();
	}

	public void SetRemaining(int remaining)
	{
		remainingText.text = remaining.ToString ();
	}

	public void SetRemaining(string remaining)
	{
		remainingText.text = remaining;
	}

	public void SetLevelType(Level.LevelType type)
	{
		levelText.text = "LEVEL " + SceneManager.GetActiveScene().buildIndex; 
		if (Dropdown.eng)
		{
			if (type == Level.LevelType.MOVES)
			{
				remainingSubtext.text = "moves remaining";
				targetSubtext.text = "target score";
			}
			else if (type == Level.LevelType.OBSTACLE)
			{
				remainingSubtext.text = "moves remaining";
				targetSubtext.text = "bubbles remaining";
			}
			else if (type == Level.LevelType.TIMER)
			{
				remainingSubtext.text = "time remaining";
				targetSubtext.text = "target score";
			}
		}
		else
		{
			if (type == Level.LevelType.MOVES)
			{
				remainingSubtext.text = "kalan hamle";
				targetSubtext.text = "hedef puan";
			}
			else if (type == Level.LevelType.OBSTACLE)
			{
				remainingSubtext.text = "kalan hamle";
				targetSubtext.text = "kalan baloncuk";
			}
			else if (type == Level.LevelType.TIMER)
			{
				remainingSubtext.text = "kalan zaman";
				targetSubtext.text = "hedef puan";
			}
		}

		
	}

	public void OnGameWin(int score)
	{
		gameOver.ShowWin (score, starIdx);
		if (starIdx > PlayerPrefs.GetInt (UnityEngine.SceneManagement.SceneManager.GetActiveScene ().name, 0)) {
			PlayerPrefs.SetInt (UnityEngine.SceneManagement.SceneManager.GetActiveScene ().name, starIdx);
		}
	}

	public void OnGameLose()
	{
		gameOver.ShowLose ();
	}
}
