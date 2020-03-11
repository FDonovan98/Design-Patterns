using UnityEngine;

public class AgentInputHandler : MonoBehaviour
{
    [SerializeField]
    private CommandObject[] commandList;

    private void Update()
    {
        foreach (CommandObject element in commandList)
        {
            if (Input.GetKeyDown(element.Keycode))
            {
                element.Execute(this);
            }
        }
    }
}
