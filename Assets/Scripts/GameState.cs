using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Playstate
{
    Paused,
    Playing,
    Gameover

}

public class GameState : MonoBehaviour
{
    [SerializeField]
    protected Playstate _state;

    protected void start()
    {
        //nothing yet
    }

    private void Update()
    {
        switch (_state) 
        {
            case Playstate.Paused:
                state_paused();
                break;
            case Playstate.Playing:
                state_playing();
                break;
            case Playstate.Gameover:
                state_gameOver();
                break;
        }
    }

    protected void state_playing()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _state = Playstate.Paused;
        }
    }
    protected void state_paused()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _state = Playstate.Playing;
        }
    }
    protected void state_gameOver()
    {
        Debug.Log("Gameover");
    }
    public Playstate state
    {
        get { return _state; }
        set { _state = value; }
    }

}
