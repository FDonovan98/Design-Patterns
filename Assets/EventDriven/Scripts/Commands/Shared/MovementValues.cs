using UnityEngine;

[CreateAssetMenu(fileName = "DefaultMovementValues", menuName = "Commands/Movement Values")]
public class MovementValues : ScriptableObject
{
    public float moveSpeed;
    public bool sprintingIsAToggle;
    public bool isSprinting;
    public float sprintMultiplier;

    public void Initialise()
    {
        isSprinting = false;
    }
}
