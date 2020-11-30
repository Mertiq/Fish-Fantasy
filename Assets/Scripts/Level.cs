using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour {

	public enum LevelType
	{
		TIMER,
		OBSTACLE,
		MOVES,
	};

	public Grid grid;
	public HUD hud;

	public int score1Star;
	public int score2Star;
	public int score3Star;

	protected LevelType type;

	public LevelType Type {
		get { return type; }
	}

	protected int currentScore;

	protected bool didWin;

	// Use this for initialization
	void Start () {
		hud.SetScore (currentScore);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public virtual void GameWin()
	{
		if(SceneManager.GetActiveScene().buildIndex > PlayerPrefs.GetInt("LastIndex"))
		{
			PlayerPrefs.SetInt("LastIndex", SceneManager.GetActiveScene().buildIndex);
		}
		grid.GameOver ();
		didWin = true;
		StartCoroutine (WaitForGridFill ());
	}


	public virtual void GameLose()
	{
		grid.GameOver ();
		didWin = false;
		StartCoroutine (WaitForGridFill ());
	}

	public virtual void OnMove()
	{

	}

	public virtual void OnPieceCleared(GamePiece piece)
	{
		currentScore += piece.score;
		hud.SetScore (currentScore);
	}

	protected virtual IEnumerator WaitForGridFill()
	{
		while (grid.IsFilling) {
			yield return 0;
		}

		if (didWin) {
			hud.OnGameWin (currentScore);
		} else {
			hud.OnGameLose ();
		}
	}
}
