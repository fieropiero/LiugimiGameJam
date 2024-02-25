using Godot;
using System;

public partial class BulletSpawn : Node2D
{
	
        [Export]
        public float moveSpeed = -1500;
		[Export]
		public PackedScene _HatScene;
		public PackedScene _HatParent;


        private Vector2 velocity;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_HatParent = GetNode<PackedScene>("Hat");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if(Input.IsKeyPressed(Key.X))
		{
			_spawnEnemy();
			GD.Print("chase right");
		}
	}

	public void _spawnEnemy(){
		Hat hat = _HatScene.Instantiate<Hat>();
		GetNode("HatSpawner").AddChild(hat);
	}
}
