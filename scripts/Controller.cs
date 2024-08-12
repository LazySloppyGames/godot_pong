using Godot;
using System;

public partial class Controller : Node2D
{
	private int leftScore = 0;
	private int rightScore = 0;
	private Global2 global;
	
	public override void _Ready()
	{
		// Set up the global script
		global = GetNode<Global2>("/root/Global2");
		// Add the signal function and give it a local function name
		global.ScoreGoal += UpdateScore;
	}
	
	private void UpdateScore(String winner)
	{
		if (winner == "left")
		{
			leftScore++;
			GetNode<Label>("LeftScore").Text = leftScore.ToString();
		}
		else
		{
			rightScore++;
			GetNode<Label>("RightScore").Text = rightScore.ToString();
		}
	}
}
