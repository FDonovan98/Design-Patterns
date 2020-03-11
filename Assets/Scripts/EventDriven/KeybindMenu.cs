using UnityEngine;

using UnityEngine.UI;

public class KeybindMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject player;
    private AgentInputHandler inputHandler;

    [SerializeField]
    private GameObject KeybindMenuElement;

    private GameObject[] menuElements;
    private Text[, ] menuElementText;
    private InputField[] menuElementKeybind;

    private void Start()
    {
        InitialiseArrays();

        int i = 0;
        foreach (CommandObject elemet in inputHandler.commandList)
        {
            menuElementText[i, 0].text = elemet.ToString();
            menuElementText[i, 1].text = elemet.keycode.ToString();
            i++;
        }
    }

    private void InitialiseArrays()
    {
        inputHandler = player.GetComponent<AgentInputHandler>();
        int numberOfInputs = inputHandler.commandList.Length;

        menuElements = new GameObject[numberOfInputs];
        menuElementText = new Text[numberOfInputs, 2];
        menuElementKeybind = new InputField[numberOfInputs];

        KeybindElementFactory keybindElementFactory = new KeybindElementFactory(KeybindMenuElement, this.transform);

        for (int i = 0; i < numberOfInputs; i++)
        {
            menuElements[i] = keybindElementFactory.GetNewInstance();
            
            Text[] tempTextHolder = menuElements[i].GetComponentsInChildren<Text>();
            for (int j = 0; j < 2; j++)
            {
                menuElementText[i, j] = tempTextHolder[j];
            }
        }
    }
}
