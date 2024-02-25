using Godot;
using System;
using System.Collections.Generic;

public partial class World : Node
{

	[Export] private PackedScene _firebomb;
	[Export] private PackedScene _frog;

	private int framesPassed = 0;	
	Random rnd = new Random();

	List<int> h_platforms = new List<int>(){200, 400, 600};
	int PLATFORMS_SPAWN_POINT_X = 1300;

	int FROG_SPAWN_POINT_DELTA_X = -70;
	int FROG_SPAWN_POINT_DELTA_Y = -10;

	int spawnObjectEveryTheseFrames = 120;

	int SPAWN_FROGS_EVERE_THESE_FRAMES;

	int lastSpawnPositionH = -400;

	//platforms
	private Node _floorParent;	

	[Export] private PackedScene _platform;

	int spawnPlatformEveryTheseFrames = 60;

	int spawnExtraBottomPlatformEveryTheseFrames;

	int platformLastSpawnPositionH = -400;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_floorParent = GetNode<Node>("../Floor");

		SPAWN_FROGS_EVERE_THESE_FRAMES = spawnPlatformEveryTheseFrames*4;
		spawnExtraBottomPlatformEveryTheseFrames = spawnPlatformEveryTheseFrames*3;
		
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		framesPassed++;
		List<int> tmp_h_firebomb = new List<int>(h_platforms);
		tmp_h_firebomb.Remove(lastSpawnPositionH);	
		lastSpawnPositionH = tmp_h_firebomb[rnd.Next(tmp_h_firebomb.Count)];
		
		if (framesPassed % spawnObjectEveryTheseFrames == 0){
			generateFirebomb(lastSpawnPositionH);
		}

		List<int> tmp_h_platforms = new List<int>(h_platforms);
		tmp_h_platforms.Remove(platformLastSpawnPositionH);	
		platformLastSpawnPositionH = tmp_h_platforms[rnd.Next(tmp_h_platforms.Count)];
		
		if (framesPassed % spawnPlatformEveryTheseFrames == 0){
			generatePlatform(spawnPlatformEveryTheseFrames, platformLastSpawnPositionH);
		}

		if (framesPassed % spawnExtraBottomPlatformEveryTheseFrames == 0){
			generatePlatform(spawnExtraBottomPlatformEveryTheseFrames, platformLastSpawnPositionH);
		}

		if (framesPassed % SPAWN_FROGS_EVERE_THESE_FRAMES == 0){
			generateFrog(SPAWN_FROGS_EVERE_THESE_FRAMES, platformLastSpawnPositionH);
		}
		//reset the variable to avoid overflow
		if(framesPassed % 1000 == 0){
			framesPassed = 0;
		}
	}

	private void generateFirebomb(int lastSpawnPositionH){
		Firebomb newFirebomb = _firebomb.Instantiate<Firebomb>();
		newFirebomb.Position = new Vector2(PLATFORMS_SPAWN_POINT_X, lastSpawnPositionH);
		this.AddChild(newFirebomb);
	}

	private void generatePlatform(int frames, int lastSpawnPositionH){
		Platform newPlatform = _platform.Instantiate<Platform>();
		newPlatform.Position = new Vector2(PLATFORMS_SPAWN_POINT_X, lastSpawnPositionH);
		this.AddChild(newPlatform);
		GD.Print("newPlatform.Position " + newPlatform.Position);	
	}

	private void generateFrog(int frames, int lastSpawnPositionH){
		Frog newFrog = _frog.Instantiate<Frog>();
		newFrog.Position = new Vector2(PLATFORMS_SPAWN_POINT_X + FROG_SPAWN_POINT_DELTA_X , lastSpawnPositionH + FROG_SPAWN_POINT_DELTA_Y);
		this.AddChild(newFrog);
		GD.Print("newFrog.Position  " + newFrog.Position );	
	}
}
