using Godot;
using System;

public partial class FakeWin : Node2D
{
	[Export]
	public Label WinMessage;
	public int Score;
	double duration = 0;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		Score = PlinkoLevel.Score;
		WinMessage.Text = $"You won with {Score} points!";

		SceneDuration(delta);
	}

	public void SceneDuration(double delta)
	{
		duration += delta;
		if (duration > 5) GetTree().ChangeSceneToFile("res://levels/pong_level.tscn");
    }
}
