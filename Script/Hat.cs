using Godot;
using System;

public partial class Hat : Area2D
{
  public float speed = 20;
	public Vector2 speedVec;
	public float xdirection = 1;
  private float toTravel = 400000;
  private Vector2? startingPosition = null;
  public Node2D target = null;
  public bool boomerang = false;


  public override void _PhysicsProcess(double delta)
  {
      if(boomerang)
      {
        homing();
        return;
      }
		  Position += Transform.X * speedVec.X * xdirection;
      if(Position.DistanceSquaredTo(startingPosition.Value) > toTravel)
      {
        boomerang = true;
      }
  }

  public void homing()
  {
    Vector2 direction = Position.DirectionTo(target.Position);
    Position += direction * speed;
  }

  public override void _Ready()
	{
    startingPosition = new(Position.X, Position.Y);
    speedVec = new(speed, 0);
	}

}
