using Godot;
using System;

namespace Visnicio.SimpleFSMDotNet;

[GlobalClass]
[Icon("res://addons/SimpleFSMDotNet/icons/IconGodotNode/node/icon_reset.png")]
public partial class SimpleFSMState : Node
{
    [Signal]
    public delegate void ChangeStateEventHandler(string newStateName);
    
    public virtual void OnEnter(){}
    public virtual void OnExit(){}
    public virtual void OnProcess(double delta){}
    public virtual void OnPhysicsProcess(double delta){}
}
