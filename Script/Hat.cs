using Godot;
using System;

public partial class Hat : Area2D
{
	public Vector2 speedVec = new(20, 0);
	public float direction = 1;

    public override void _PhysicsProcess(double delta)
    {
		Position += Transform.X * speedVec.X * direction;
    }

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
	{
	}

}
