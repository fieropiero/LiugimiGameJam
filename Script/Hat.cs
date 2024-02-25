using Godot;
using System;
using System.Collections;
using System.Threading;

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
		Monitoring = true;
	}

	private void _on_area_entered(Area2D area)
	{
		if(area.IsInGroup("Enemy"))
			area.QueueFree();
	}

	private void _on_body_entered(Node2D body)
	{
		if(body.IsInGroup("Enemy"))
			body.QueueFree();
	}

}

