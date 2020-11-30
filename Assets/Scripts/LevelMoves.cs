using UnityEngine;
using System.Collections;

public class LevelMoves : Level {

	public int numMoves;
	public int targetScore;

	private int movesUsed = 0;
	public bool infinity = false;

	// Use this for initialization
	void Start () {
		type = LevelType.MOVES;

		hud.SetLevelType (type);
		hud.SetScore (currentScore);
		hud.SetTarget (targetScore);
		hud.SetRemaining (numMoves);
	}
	

	public override void OnMove ()
	{
		if(!infinity)
		{
			movesUsed++; 
			hud.SetRemaining(numMoves - movesUsed);

			if (numMoves - movesUsed == 0)
			{
				if (currentScore >= targetScore)
				{
					GameWin();
				}
				else
				{
					GameLose();
				}
			}
			else
			{
				if (currentScore >= targetScore)
				{
					GameWin();
				}
			}
		}
	}
}
