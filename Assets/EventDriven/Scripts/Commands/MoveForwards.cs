using UnityEngine;

[CreateAssetMenu(fileName = "DefaultMoveForwards", menuName = "Commands/Move Forward")]
public class MoveForwards : CommandObject
{
    public MovementValues movementValues;
    public override void Execute(GameObject agent)
    {
        if (movementValues.isSprinting)
        {
            agent.GetComponent<Rigidbody>().velocity += movementValues.moveSpeed * movementValues.sprintMultiplier * agent.transform.forward;
        }
        else
        {
            agent.GetComponent<Rigidbody>().velocity += movementValues.moveSpeed * agent.transform.forward;
        }
    }
}
