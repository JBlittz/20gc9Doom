using Godot;
using System;

public partial class Camera : Camera3D
{
    private float mouseSensitivity = 0.002f;
    public float CurrentPitch { get; private set; } = 0.0f;
    public float CurrentYaw { get; private set; } = 0.0f;

    public override void _Ready()
    {
        Input.MouseMode = Input.MouseModeEnum.Captured;
    }

    public override void _Input(InputEvent @event)
    {
        if (@event is InputEventMouseMotion mouseMotion && Input.MouseMode == Input.MouseModeEnum.Captured)
        {
            CurrentYaw = CurrentYaw - mouseMotion.Relative.X * mouseSensitivity;
            CurrentPitch = Mathf.Clamp(CurrentPitch - (mouseMotion.Relative.Y * mouseSensitivity), -Mathf.Pi / 2.0f, Mathf.Pi / 2.0f);
            Rotation = new Vector3(CurrentPitch, CurrentYaw, Rotation.Z);
        }

        // TODO: Transform in signal \/ \/ \/
        if (Input.IsActionJustPressed("ui_cancel"))
        {
            if (Input.MouseMode == Input.MouseModeEnum.Captured)
            {
                Input.MouseMode = Input.MouseModeEnum.Visible;
            }
        }
        if (Input.IsActionJustPressed("ui_accept"))
        {
            if (Input.MouseMode == Input.MouseModeEnum.Visible)
            {
                Input.MouseMode = Input.MouseModeEnum.Captured;
            }
        }
    }
}
