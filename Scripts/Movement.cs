using Godot;
using System;
using System.Diagnostics;

public partial class Movement : CharacterBody3D
{
    [Export]
    private Camera camera;

    private float moveSpeed = 10.0f;
    private Vector2 moveDirection = Vector2.Zero;

    public override void _PhysicsProcess(double delta)
    {
        moveDirection = Input.GetVector("move_left", "move_right", "move_front", "move_back").Rotated(-camera.CurrentYaw);
        Velocity = new Vector3(moveDirection.X * moveSpeed, Velocity.Y, moveDirection.Y * moveSpeed);
        MoveAndSlide();
    }
}
