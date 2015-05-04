using UnityEngine;
using System.Collections;

public class FightEvent : EncounterEvent {

    public EncounterEvent rootEvent;

    bool isCleared = false;

    public bool temporaryWinState = false;

    public CameraMovement cameraMovement;

    public Transform battleCamera;

    void Update()
    {
        switch (currentState)
        {
            case State.STARTING:
                Starting();
                break;
            case State.FIGHTING:
                Fighting();
                break;
        }
    }

    void Starting()
    {
        SetCamera();
        currentState = State.FIGHTING;
    }

    void Fighting()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            FightOver(temporaryWinState);
            Debug.Log("Fighting occurs.");
            //Put code that checks to see if the player wins or not.
        }
    }

    public override void Play()
    {
        currentState = State.STARTING;
    }

    public void FightOver(bool playerWon)
    {
        if(playerWon)
        {
            isCleared = true;
            currentState = State.CLEARED;
            WinEvent();
        }
        else
        {
            Reset();
            LoseEvent();
        }
        ResetCamera();
    }

    public override void Reset()
    {
        currentState = State.SLEEPING;
    }

    void SetCamera()
    {
        cameraMovement.SetNewLocation(battleCamera);
        //Change camera's position
    }

    void ResetCamera()
    {
        cameraMovement.ResetLocation();
        //Reset camera's position
    }

    void WinEvent()
    {
        nextEvent[0].Play();
        rootEvent.currentState = State.CLEARED;
    }

    void LoseEvent()
    {
        nextEvent[1].Play();
    }
}