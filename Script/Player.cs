using Godot;
using System;

public partial class Player : CharacterBody2D
{
	public const float Speed = 300.0f;
	public const float JumpVelocity = -650.0f;

	// Get the gravity from the project settings to be synced with RigidBody nodes.
	public float gravity = ProjectSettings.GetSetting("physics/2d/default_gravity").AsSingle();

	public Marker2D hatSpawnPoint;
	public AnimationPlayer anim;
	public AnimatedSprite2D sprite;
	[Export]
	public PackedScene _HatScene;
	public bool hasHat = true;


	public override void _Ready()
	{
		hatSpawnPoint = GetNode<Marker2D>("HatSpawnPoint");
		anim = GetNode<AnimationPlayer>("AnimationPlayer");
		sprite = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
		if(hasHat)
		{
			anim.Play("Idle");
		}
		else
		{
			anim.Play("Idle_bald");
		}
		base._Ready();
		GD.Print(Position);
	}

	public override void _Input(InputEvent @event)
	{
		base._Input(@event);
		anim.Play("Attack");
		if(Input.IsPhysicalKeyPressed(Key.X))
		{
			_spawnHat();
		}
	}

	private void FlipHatSpawnPoint(bool toRight)
	{
		if((toRight && hatSpawnPoint.Position.X < 0)
		||(!toRight && hatSpawnPoint.Position.X > 0))
			hatSpawnPoint.Position *= Transform2D.FlipX;
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
			sprite.FlipH = true;
			FlipHatSpawnPoint(false);
		}
		else if(direction.X > 0)
		{
			sprite.FlipH = false;
			FlipHatSpawnPoint(true);
		}
		
		if (direction != Vector2.Zero)
		{
			velocity.X = direction.X * Speed;
			if(velocity.Y == 0)
			{
				if(hasHat)
				{
					anim.Play("Run");
				}
				else
				{
					anim.Play("Run_bald");
				}
			}
		}
		else
		{
			//Questo rallenta il personaggio
			velocity.X = Mathf.MoveToward(Velocity.X, 0, Speed);
			if(velocity.Y == 0)
			{
				if(hasHat)
				{
					anim.Play("Idle");
				}
				else
				{
					anim.Play("Idle_bald");
				}
			}
		}

		if(velocity.Y < 0)
		{
			if(hasHat)
			{
				anim.Play("Jump");
			}
			else
			{
				anim.Play("Jump_bald");
			}
		}
		if(velocity.Y > 0)
		{
			if(hasHat)
			{
				anim.Play("Fall");
			}
			else
			{
				anim.Play("Fall_bald");
			}
		}

		Velocity = velocity;
		MoveAndSlide();
	}

	private Vector2 SpawnVelocity = new(20,0);
	
	public void _spawnHat()
	{
		if(!hasHat) return;

		Hat hat = _HatScene.Instantiate<Hat>();
		hat.Position = hatSpawnPoint.GlobalPosition;
		hat.target = this;
		if(sprite.FlipH) hat.xdirection = -1;
		Owner.AddChild(hat);
		hasHat = false;
	}
	public void _on_hat_retriever_area_entered(Area2D area)
	{
		if(area.IsInGroup("Limit"))
		{
			die();
		}

		if(area.IsInGroup("Hat") && ((Hat)area).boomerang)
		{
			hasHat = true;
			area.QueueFree();
		}
	}

	public async void die()
	{
		this.QueueFree();
		if(hasHat)
		{
			anim.Play("Death");
		}
		else
		{
			anim.Play("Death_bald");
		}
		GetTree().ReloadCurrentScene();
	}
}
