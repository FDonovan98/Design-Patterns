using UnityEngine;

public class KeybindMenu : MonoBehaviour
{
    [SerializeField]
    private InputHandler inputHandler;

    [SerializeField]
    private GameObject KeybindMenuElement;

    private GameObject[] menuElements;

    private void Start()
    {
        int numberOfInputs = inputHandler.commands.Length;

        menuElements = new GameObject[numberOfInputs];

        KeybindElementFactory keybindElementFactory = new KeybindElementFactory(KeybindMenuElement);

        for (int i = 0; i < numberOfInputs - 1; i++)
        {
            menuElements[i] = keybindElementFactory.GetNewInstance();
        }
    }
}
