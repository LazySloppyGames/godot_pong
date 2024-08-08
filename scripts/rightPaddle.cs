using Godot;
using System;

public partial class rightPaddle : CharacterBody2D
{
	private Vector2 Direction = Vector2.Zero;
	private const float Speed = 500.0f;

	public override void _PhysicsProcess(double delta)
	{
		if (Input.IsActionPressed("RightPaddleUp"))
		{
			Direction = Vector2.Up;
		}
		else if (Input.IsActionPressed("RightPaddleDown"))
		{
			Direction = Vector2.Down;
		}
		else
		{
			Direction = Vector2.Zero;
		}
		Velocity = Direction * Speed;
		MoveAndSlide();
	}
}
