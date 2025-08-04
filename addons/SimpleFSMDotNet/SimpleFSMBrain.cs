using Godot;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Visnicio.SimpleFSMDotNet;

[GlobalClass]
[Icon("res://addons/SimpleFSMDotNet/icons/IconGodotNode/node/icon_brain.png")]
public partial class SimpleFSMBrain : Node {

	private Dictionary<string, SimpleFSMState> states = new Dictionary<string, SimpleFSMState>();
	public SimpleFSMState currentState { get; private set; } = null;

	[Export] public SimpleFSMState initialState;

	public override void _Ready() {
		foreach (var child in GetChildren()) {
			if (child is SimpleFSMState state) {
				string key = state.GetType().Name;
				state.ChangeState += OnStateChanged;

				states.Add(key, state);
			}
		}
		
		// initial state if not null, else first state on dict
		currentState = initialState ?? states.First().Value;
		
		currentState.OnEnter();
		
	}

	public override void _Process(double delta) {
		if (currentState != null) {
			currentState.OnProcess(delta);
		}
	}

	public override void _PhysicsProcess(double delta) {
		if (currentState != null) {
			currentState.OnPhysicsProcess(delta);
		}
		
		GD.Print(currentState);
	}

	private void OnStateChanged(string newStateName) {
		if (!states.ContainsKey(newStateName)) {
			throw new NoSuchStateException();
		}

		if (states.TryGetValue(newStateName, out SimpleFSMState state)) {
			if (state == currentState) {
				return;
			}
			
			currentState.OnExit();
			currentState = state;
			currentState.OnEnter();
		}
	}
}
