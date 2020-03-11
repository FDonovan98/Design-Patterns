using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class AgentInputHandler : MonoBehaviour
{
    public CommandObject[] commandList;

    private void Update()
    {
        foreach (CommandObject element in commandList)
        {
            if (Input.GetKey(element.keycode))
            {
                element.Execute(this.gameObject);
            }
        }
    }
}
