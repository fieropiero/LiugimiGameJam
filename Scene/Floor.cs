using Godot;
using System;

public partial class Floor : StaticBody2D
{	

	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		Position += new Vector2(-1, 0);
	}
}