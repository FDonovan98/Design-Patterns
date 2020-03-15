using UnityEngine;

[CreateAssetMenu(fileName = "DefaultMovementValues", menuName = "Commands/Movement Values")]
public class MovementValues : ScriptableObject
{
    public float moveSpeed;
    public bool isSprinting;
    public float sprintMultiplier;
}
