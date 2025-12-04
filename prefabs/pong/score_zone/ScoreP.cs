using Godot;
using System;

public partial class ScoreP : Area2D
{
    [Export]
    public PongLevel PongLevelNode;

    [Export]
    public int points = 1;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        BodyEntered += ScreenCleared;
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
    {
    }

    private void ScreenCleared(Node2D body)
    {
        if (body.IsInGroup("PongBall"))
        {
            PongLevelNode.ScoreInfo(points);

            PongBall Ball = (PongBall)body;
        }
    }
}
