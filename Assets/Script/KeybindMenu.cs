using UnityEngine;

using UnityEngine.UI;

public class KeybindMenu : MonoBehaviour
{
    [SerializeField]
    private InputHandler inputHandler;

    [SerializeField]
    private GameObject KeybindMenuElement;

    private GameObject[] menuElements;
    private Text[, ] menuElementText;
    private InputField[] menuElementKeybind;

    private void Start()
    {
        InitialiseArrays();

        int i = 0;
        foreach (Command elemet in inputHandler.commands)
        {
            menuElementText[i, 0].text = elemet.ToString();
            menuElementText[i, 1].text = elemet.keyCode.ToString();
            i++;
        }
    }

    private void InitialiseArrays()
    {
        int numberOfInputs = inputHandler.commands.Length;

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
