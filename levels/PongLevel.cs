using Godot;
using System;

public partial class PongLevel : Node2D
{
	[Export]
	public Label Score;
	[Export]
	public Label RespawnLbl;

	[Export]
	public PackedScene BallScene;

	[Export]
	public Node2D Balls;

	Vector2 startPos = new Vector2(296, 400);
	public static int pongScore = 0;
	bool respawn = false;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		RespawnLbl.Hide();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
        Score.Text = $"Current score: {pongScore}";
        RespawnLbl.Visible = respawn;

        if (Input.IsActionJustPressed("pong_continue") && respawn)
        {
            BallRespawn();

            respawn = false;
        }
    }

	public void ScoreInfo(int scoreGain)
	{
        if (!respawn)
        {
            pongScore += scoreGain;
            respawn = true;
        }
    }

	public void BallRespawn()
	{
        PongBall newBall = BallScene.Instantiate<PongBall>();
        newBall.Position = startPos;

        Balls.AddChild(newBall);
    }
}
