using Godot;
using System;

public partial class Firebomb : Node2D
{
	Random rnd = new Random();
	int velocity = 0;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		velocity = rnd.Next(-6, -3);
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		Position += new Vector2(velocity, 0);
	}
}
