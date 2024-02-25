using Godot;
using System;

public partial class Mage : Area2D
{
	AnimationPlayer anim;
	public short hp = 500;
	public Vector2 speedVec = new(0, 5);
	public float direction = 1;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		anim = GetNode<AnimationPlayer>("AnimationPlayer");
		anim.Play("Idle");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{

	}

	
    public override void _PhysicsProcess(double delta)
    {
		Position += Transform.Y * speedVec.Y * direction;
    }

	public void _on_area_entered(Area2D area)
	{
		if(area.IsInGroup("Limit"))
			direction *= -1;
		else if(area.IsInGroup("Hat"))
		{
			hp--;
		}
		if(hp <= 0)
		{
			this.QueueFree();
		}
	}

}
