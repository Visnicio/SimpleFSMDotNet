using Godot;
using System;
using Visnicio.SimpleFSMDotNet;

public partial class WalkingState : SimpleFSMState
{
    [Export] private AnimationPlayer animPlayer;
    [Export] private Sprite2D sprite;
    [Export] private CharacterBody2D node;
    
    public override void OnEnter() {
        animPlayer.Play("running");
    }
    
    public override void OnPhysicsProcess(double delta) {
        Vector2 direction = Vector2.Zero;
        direction.X = Input.GetActionStrength("right") - Input.GetActionStrength("left");
        direction.Y = Input.GetActionStrength("down") - Input.GetActionStrength("up");

        if (direction == Vector2.Zero) {
            EmitSignal(SignalName.ChangeState, nameof(IdleState));
        }

        if (direction.X < 0) {
            sprite.FlipH = true;
        } else if (direction.X > 0) {
            sprite.FlipH = false;
        }

        node.Velocity = direction.Normalized() * 100;
        node.MoveAndSlide();
    }
}
