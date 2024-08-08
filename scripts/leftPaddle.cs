using Godot;
using System;

// TODO: modeandslide and moveandcollide are BROKEN. Don't bother. Either
// upgrade physics engine to Jolt (maybe Box2D in 2D) or hand-code.

public partial class leftPaddle : CharacterBody2D
{
	private Vector2 Direction = Vector2.Zero;
	private const float Speed = 500.0f;

	public override void _PhysicsProcess(double delta)
	{
		if (Input.IsActionPressed("LeftPaddleUp"))
		{
			Direction = Vector2.Up;
		}
		else if (Input.IsActionPressed("LeftPaddleDown"))
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
