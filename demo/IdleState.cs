using Godot;
using System;
using Visnicio.SimpleFSMDotNet;

public partial class IdleState : SimpleFSMState {
	
	[Export] private AnimationPlayer animPlayer;
	[Export] private CharacterBody2D node;
	public override void OnEnter() {
		animPlayer.Play("idle");
		node.Velocity = Vector2.Zero;
	}

	public override void OnPhysicsProcess(double delta) {
		if (Input.IsActionPressed("down") || Input.IsActionPressed("up") || Input.IsActionPressed("left") ||
		    Input.IsActionPressed("right")) {
			EmitSignal(SignalName.ChangeState, nameof(WalkingState));
		}
	}
}
