// Code credit: https://www.habrador.com/tutorials/programming-patterns/1-command-pattern/

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InputHandler : MonoBehaviour
{
    //The box we control with keys
    public Transform boxTrans;
    public Transform UICanvas;
    //The different keys we need
    public Command[] commands = new Command[8];
    //Stores all commands for replay and undo
    public static List<Command> oldCommands = new List<Command>();
    //Box start position to know where replay begins
    private Vector3 boxStartPos;
    //To reset the coroutine
    private Coroutine replayCoroutine;
    //If we should start the replay
    public static bool shouldStartReplay;
    //So we cant press keys while replaying
    private bool isReplaying;

    void Awake()
    {   
        //Bind keys with commands
        commands[0] = new DoNothing(KeyCode.B);
        commands[1] = new MoveForward(KeyCode.W);
        commands[2] = new MoveReverse(KeyCode.S);
        commands[3] = new MoveLeft(KeyCode.A);
        commands[4] = new MoveRight(KeyCode.D);
        commands[5] = new UndoCommand(KeyCode.Z);
        commands[6] = new ReplayCommand(KeyCode.R);
        commands[7] = new ToggleUI(KeyCode.Space);

        boxStartPos = boxTrans.position;
    }



    void Update()
    {
        if (!isReplaying)
        {
            HandleInput();
        }

        StartReplay();
    }


    //Check if we press a key, if so do what the key is binded to 
    public void HandleInput()
    {
        foreach (Command element in commands)
        {
            if (Input.GetKeyDown(element.keyCode))
            {
                if (element.GetType().Equals(typeof(ToggleUI)))
                {
                    element.Execute(UICanvas, element);
                }
                else
                {
                    element.Execute(boxTrans, element);
                }
            }
        }
    }


    //Checks if we should start the replay
    void StartReplay()
    {
        if (shouldStartReplay && oldCommands.Count > 0)
        {
            shouldStartReplay = false;

            //Stop the coroutine so it starts from the beginning
            if (replayCoroutine != null)
            {
                StopCoroutine(replayCoroutine);
            }

            //Start the replay
            replayCoroutine = StartCoroutine(ReplayCommands(boxTrans));
        }
    }


    //The replay coroutine
    IEnumerator ReplayCommands(Transform boxTrans)
    {
        //So we can't move the box with keys while replaying
        isReplaying = true;
        
        //Move the box to the start position
        boxTrans.position = boxStartPos;

        for (int i = 0; i < oldCommands.Count; i++)
        {
            //Move the box with the current command
            oldCommands[i].Move(boxTrans);

            yield return new WaitForSeconds(0.3f);
        }

        //We can move the box again
        isReplaying = false;
    }
}