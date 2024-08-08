using System;
using Godot;

public partial class Ball : CharacterBody2D
{
	private float BallSpeed = 300.0f;
	private float BallRadius;
	private Vector2 Direction = new Vector2(1, 1).Normalized();
	private StaticBody2D upperBound;
	private StaticBody2D lowerBound;
	private StaticBody2D leftGoal;
	private StaticBody2D rightGoal;
	private CharacterBody2D leftPaddle;
	private CharacterBody2D rightPaddle;
	private Vector2 InitialPosition;
	private Global2 global; // Global script to handle signals

	public override void _Ready()
	{
		BallRadius = GetNode<Sprite2D>("BallGraphics").Texture.GetWidth() / 2.0f;
		upperBound = GetNode<StaticBody2D>("/root/Pong/UpperBound");
		lowerBound = GetNode<StaticBody2D>("/root/Pong/LowerBound");
		leftGoal = GetNode<StaticBody2D>("/root/Pong/LeftGoal");
		rightGoal = GetNode<StaticBody2D>("/root/Pong/RightGoal");
		leftPaddle = GetNode<CharacterBody2D>("/root/Pong/LeftPaddle");
		rightPaddle = GetNode<CharacterBody2D>("/root/Pong/RightPaddle");
		InitialPosition = Position;
		global = GetNode<Global2>("/root/Global2");
	}

	public override void _PhysicsProcess(double delta)
	{
		Velocity = Direction * BallSpeed * (float) delta;
		var collision = MoveAndCollide(Velocity);
		
		if (collision != null)
		{
			var collidingObject = collision.GetCollider();
			if (collidingObject == upperBound || collidingObject == lowerBound)
			{
				Direction[1] *= -1.0f;
			}
			if (collidingObject == leftPaddle || collidingObject == rightPaddle)
			{
				Direction[0] *= -1.0f;
			}
			// Opposite because the goal on the left side is the right player's target
			if (collidingObject == rightGoal)
			{
				AwardPoint("left");
				Direction[0] = 1.0f;
				ResetBall();
			}
			else if (collidingObject == leftGoal)
			{
				AwardPoint("right");
				Direction[0] = -1.0f;
				ResetBall();
			}
		}
	}
	
	// Emit signal so the controller can adjust the score.
	public void AwardPoint(String point)
	{
		GD.Print("Emitting signal...");
		global.EmitSignal(nameof(Global2.ScoreGoal), point);
		GD.Print("Signal sent... maybe.");
	}
	
	public void ResetBall()
	{
		Position = InitialPosition;
	}
}
