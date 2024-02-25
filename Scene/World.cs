using Godot;
using System;
using System.Collections.Generic;

public partial class World : Node
{

	[Export] private PackedScene _firebomb;

	private int framesPassed = 0;	
	Random rnd = new Random();

	List<int> h_platforms = new List<int>(){200, 400, 600};
	int PLATFORMS_SPAWN_POINT_X = 1300;

	int spawnObjectEveryTheseFrames = 120;

	int lastSpawnPositionH = -400;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		framesPassed++;
		List<int> tmp_h_platforms = new List<int>(h_platforms);
		tmp_h_platforms.Remove(lastSpawnPositionH);
		// GD.Print("h_platforms " + h_platforms.Count);	
		// GD.Print("tmp_h_platforms " + tmp_h_platforms.Count);
		// GD.Print("lastSpawnPositionH " + lastSpawnPositionH);	
		lastSpawnPositionH = tmp_h_platforms[rnd.Next(tmp_h_platforms.Count)];
		
		generateFirebomb(spawnObjectEveryTheseFrames, lastSpawnPositionH);
	}

	private void generateFirebomb(int frames, int lastSpawnPositionH){

		if (framesPassed % frames == 0){
			Firebomb newFirebomb = _firebomb.Instantiate<Firebomb>();
			newFirebomb.Position = new Vector2(PLATFORMS_SPAWN_POINT_X, lastSpawnPositionH);
			this.AddChild(newFirebomb);
		}
		//reset the variable to avoid overflow
		if(frames % 1000 == 0){
			framesPassed = 0;
		}


			
			
			

		// if (framesPassed % frames == 0){
		// 	Firebomb newPlatform = _firebomb.Instantiate<Firebomb>();
		// 	newPlatform.Position = new Vector2(PLATFORMS_SPAWN_POINT_X, H_PLATFORM);
		// 	_floorParent.AddChild(newPlatform);
		// }

		// //reset the variable to avoid overflow
		// if(frames % 1000 == 0){
		// 	framesPassed = 0;
		// }

	}
}
