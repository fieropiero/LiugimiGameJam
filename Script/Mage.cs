using Godot;
using System;

public partial class Mage : Area2D
{
	AnimationPlayer anim;
	[Export]
	public short hp = 10;
	public Vector2 speedVec = new(0, 5);
	public float direction = 1;
	TimeSpan hitTime = DateTime.Now.AddSeconds(1).TimeOfDay;
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
			anim.Play("Hit");
		}
		if(hp <= 0)
		{
			this.QueueFree();
		}
	}

	public void _on_body_entered(Node2D body){
		if (body.Name == "Player"){
			((Player) body).die();
		}
	}

	public void _on_animation_player_animation_finished(string anim_name)
	{
		if(anim_name == "Hit")
			anim.Play("Idle");
	}

}
