using UnityEngine;
using System.Collections;

public class LevelTimer : Level {

	public int timeInSeconds;
	public int targetScore;

	private float timer;
	public static bool timeOut = false;

	// Use this for initialization
	void Start () {
		timeOut = false;
		type = LevelType.TIMER;

		hud.SetLevelType (type);
		hud.SetScore (currentScore);
		hud.SetTarget (targetScore);
		hud.SetRemaining (string.Format ("{0}:{1:00}", timeInSeconds / 60, timeInSeconds % 60));
	}

	// Update is called once per frame
	void Update () {
		Debug.Log(timeOut);
		if (!timeOut) {
			timer += Time.deltaTime;
			hud.SetRemaining (string.Format ("{0}:{1:00}", (int)Mathf.Max((timeInSeconds - timer) / 60, 0), (int)Mathf.Max((timeInSeconds - timer) % 60, 0)));

			if (timeInSeconds - timer <= 0) {
				if (currentScore >= targetScore) {
					GameWin ();
				} else {
					GameLose ();
				}

				timeOut = true;
			}
			else
			{
				if (currentScore >= targetScore)
				{
					GameWin();
					timeOut = true;
				}
			}
		}
	}
}
