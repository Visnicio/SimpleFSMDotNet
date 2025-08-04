using Godot;
using System;
using Visnicio.SimpleFSMDotNet;

public partial class Player : CharacterBody2D {
	[Export] private Label currentStateLabel;
	[Export] private SimpleFSMBrain aiBrain;

	public override void _PhysicsProcess(double delta) {
		currentStateLabel.Text = aiBrain.currentState.Name;
	}
}
