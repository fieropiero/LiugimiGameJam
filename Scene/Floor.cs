using Godot;
using System;
using System.Collections.Generic;

public partial class Floor : StaticBody2D
{	
	private Node _floorParent;
	private int framesPassed = 0;	

	[Export] private PackedScene _platform;
	Random rnd = new Random();

	List<int> h_platforms = new List<int>(){-20, -140, -240, -340, -440};
	int PLATFORMS_SPAWN_POINT_X = 750;

	int spawnPlatformEveryTheseFrames = 60;

	int lastSpawnPositionH = -400;

	public override void _Ready()
	{
		_floorParent = GetNode<Node>("../Floor");
		GD.Print(_floorParent);	
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		framesPassed++;

		List<int> tmp_h_platforms = new List<int>(h_platforms);
		tmp_h_platforms.Remove(lastSpawnPositionH);
		GD.Print("h_platforms " + h_platforms.Count);	
		GD.Print("tmp_h_platforms " + tmp_h_platforms.Count);
		GD.Print("lastSpawnPositionH " + lastSpawnPositionH);	
		lastSpawnPositionH = tmp_h_platforms[rnd.Next(tmp_h_platforms.Count)];
		generatePlatform(spawnPlatformEveryTheseFrames, lastSpawnPositionH);
		// generatePlatform(spawnPlatformEveryTheseFrames, h_platforms[rnd.Next(4)]);
	}

	private void generatePlatform(int frames, int H_PLATFORM){
		Position += new Vector2(-1, 0);
		PLATFORMS_SPAWN_POINT_X += 1;

		if (framesPassed % frames == 0){
			Platform newPlatform = _platform.Instantiate<Platform>();
			newPlatform.Position = new Vector2(PLATFORMS_SPAWN_POINT_X, H_PLATFORM);
			_floorParent.AddChild(newPlatform);
		}

		//reset the variable to avoid overflow
		if(frames % 1000 == 0){
			framesPassed = 0;
		}

	}
}