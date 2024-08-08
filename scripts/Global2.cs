using Godot;
using System;

public partial class Global2 : Node
{
	[Signal]
	public delegate void ScoreGoalEventHandler(String winner);
	
	public static float windowWidth;
	public static float windowHeight;
	
	public override void _Ready() {
		Vector2 windowSize = GetWindow().Size;
		windowWidth = windowSize[0];
		windowHeight = windowSize[1];
	}
}
