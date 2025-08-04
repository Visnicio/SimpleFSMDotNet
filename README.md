![scene_demo](https://github.com/Visnicio/SimpleFSMDotNet/blob/master/addons/SimpleFSMDotNet/images/example_agent.png)
![scene_demo](https://github.com/Visnicio/SimpleFSMDotNet/blob/master/addons/SimpleFSMDotNet/images/demogif.gif)

# Installing

 1. Download the .zip file and extract the addons folder to your root project folder `res://`
 2. Enable the addon by ticking the enable checkbox at Project -> Project Settings -> addons

# About
This is a simple rework from [my past fsm implementation for gdscript purists](https://github.com/Visnicio/SimpleFSM), no dedicated editors, just create the script and use it.
I intend to keep adding functionality to this addon but its not supposed to evolve firthuer than just being a "fuck, I need a FSM" solution.
In almost every game I game I need a FSM for something and this always save my butt from having to code it from scratch.


Here's a basic example
``` csharp
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
```
## Known issues
 - When you add a `SimpleFSMState` to the scene and extend the script, Godot will not understant that its supposed to inherit from `SimpleFSMState`, it will try to inherit from `SimpleFsmState`, just fix the class name and dont forget to add the namespace.

## Changing States
To change states you have a signal on the State class (I need to fucking change this, this is not scalable) that you can emit.
```csharp
EmitSignal(SignalName.ChangeState, nameof(WalkingState));
```

## State class
Heres the virtual methods you can implement at the moment

```csharp
    public virtual void OnEnter(){}
    public virtual void OnExit(){}
    public virtual void OnProcess(double delta){}
    public virtual void OnPhysicsProcess(double delta){}
```
