using Godot;
using System;

public partial class Player : CharacterBody2D
{
	public const float Speed = 300.0f;
	public const float JumpVelocity = -400.0f;

	// Get the gravity from the project settings to be synced with RigidBody nodes.
	public float gravity = ProjectSettings.GetSetting("physics/2d/default_gravity").AsSingle();
    public AnimatedSprite2D anim;


    public override void _Ready()
    {
		anim = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
		anim.Play("Idle");
        base._Ready();
    }

    public override void _PhysicsProcess(double delta)
	{
		Vector2 velocity = Velocity;

		// Add the gravity.
		if (!IsOnFloor())
		{
			velocity.Y += gravity * (float)delta;
		}

		// Handle Jump.
		if (Input.IsActionJustPressed("ui_accept") && IsOnFloor())
			velocity.Y = JumpVelocity;

		// Get the input direction and handle the movement/deceleration.
		// As good practice, you should replace UI actions with custom gameplay actions.
		Vector2 direction = Input.GetVector("ui_left", "ui_right", "ui_up", "ui_down");
		if(direction.X < 0)
		{
			anim.FlipH = true;
		}
		else if(direction.X > 0)
		{
			anim.FlipH = false;
		}
		
		if (direction != Vector2.Zero)
		{
			velocity.X = direction.X * Speed;
			if(velocity.Y == 0)
			{
				anim.Play("Run");
			}
		}
		else
		{
			//Questo rallenta il personaggio
			velocity.X = Mathf.MoveToward(Velocity.X, 0, Speed);
			if(velocity.Y == 0)
			{
				anim.Play("Idle");
			}
		}

		if(velocity.Y < 0)
		{
			anim.Play("Jump");
		}
		if(velocity.Y > 0)
		{
			anim.Play("Fall");
		}

		Velocity = velocity;
		MoveAndSlide();
	}
}
