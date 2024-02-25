// using Godot;
// using System;

// public partial class Panel : Godot.Panel
// {

// 	// Define the platform's movement properties
//     private Vector2 direction = new Vector2(1, 0); // Change direction as needed
//     private float speed = 70f;
//     private float distance = 200f; // Distance the platform should travel

//     // Keep track of the platform's initial position
//     private Vector2 initialPosition;

// 	public const float Speed = 80.0f;
// 	// Called when the node enters the scene tree for the first time.
// 	public override void _Ready()
// 	{
// 		// Store the initial position of the platform
//         initialPosition = Position;
// 	}

// 	// Called every frame. 'delta' is the elapsed time since the previous frame.
// 	public override void _Process(double delta)
// 	{
// 		 // Move the platform back and forth
//         // double velocity =  speed * delta;

// 		// position += Vector2(move_x, move_y);
//         // Translate(velocity);

//         // // Check if the platform has traveled the desired distance
//         // if (Position.DistanceTo(initialPosition) >= distance)
//         // {
//         //     // Reverse direction
//         //     direction *= -1;
//         // }

// 		// Move the platform back and forth
//         // Vector2 velocity 
// 		// direction.X = (float)(direction.X * speed * delta);
//         // Position += direction;

//         // // Check if the platform has traveled the desired distance
//         // if (Position.DistanceTo(initialPosition) >= distance)
//         // {
//         //     // Reverse direction
//         //     direction *= -1;
//         // }
// 	}

// 	// public override void _PhysicsProcess(double delta)
// 	// {
// 	// 	Vector2 velocity = Velocity;
// 	// 	CharacterBody2D player = GetNode<CharacterBody2D>("../Player");
// 	// 	AnimatedSprite2D enemyAnimatedSprite = GetNode<AnimatedSprite2D>("../Frog/AnimatedSprite2D");

// 	// 	// Add the gravity.
// 	// 	if (!IsOnFloor())
// 	// 		velocity.Y += gravity * (float)delta;

// 	// 	if (chase == true){
// 	// 		Vector2 direction = player.Position - this.Position;
// 	// 		GD.Print(direction);
// 	// 		if (direction.X > 0){
// 	// 			GD.Print("chase right");
// 	// 			velocity.X = Speed;
// 	// 			enemyAnimatedSprite.FlipH = true;
// 	// 		} else {
// 	// 			GD.Print("left");
// 	// 			velocity.X = -Speed;
// 	// 			enemyAnimatedSprite.FlipH = false;	
// 	// 		}
// 	// 	}
// 	// 	if (chase == false){
// 	// 		velocity.X = 0;
// 	// 	}

// 	// 	Velocity = velocity;
// 	// 	MoveAndSlide();
// 	// }

// }
