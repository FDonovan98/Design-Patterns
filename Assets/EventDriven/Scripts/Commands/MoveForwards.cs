using UnityEngine;

[CreateAssetMenu(fileName = "DefaultMoveForwards", menuName = "Commands/Move Forward")]
public class MoveForwards : CommandObject
{
    public override void Execute(GameObject agent, MovementValues movementValues)
    {
        if (Input.GetKey(keycode))
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
}
