using UnityEngine;

public abstract class CommandObject : ScriptableObject
{
    [SerializeField]
    public KeyCode keycode;

    public abstract void Execute(GameObject agent, MovementValues movementValues);
}
