using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyInstantiator : MonoBehaviour
{
    [SerializeField]
    protected Transform prefab; //the given prefab that will used as a target
    [SerializeField]
    protected Camera cam; //camera for viewing
    [SerializeField]
    protected int AmountofTargets; //sets the size of the list called Targets (sets the amount of targets)
    [SerializeField]
    protected int targetWorth; //sets the amount each target is worth
    [SerializeField]
    public GameState gamestate; // Call to Gamestate script for playstate enumeration and funcitons
    [SerializeField]
    public MyTrigger mytrigger; // Call to Mytrigger for the missed integer


    List<Transform> targets;
    protected int score; //keeps track of score, later printed in the Debug.Log
    public int shotDown = 0; // keeps track of how many targest have been hit.

    //initializing targets, setting score to 0
    void Start()
    {
        score = 0;
        targets = new List<Transform>();
        for (int i = 0; i < AmountofTargets; ++i)
        {
            AddToTargets();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && gamestate.state == Playstate.Playing) //If game state is playing you can shoot blocks
        {
            Vector2 mousePos = Input.mousePosition;
            Ray ray = cam.ScreenPointToRay(mousePos);
            RaycastHit rch;
            if (Physics.Raycast(ray, out rch))
            {
                //Debug.Log("Player click on on '" + rch.transform.name + "'");
                RemoveTarget(rch.transform);
                UpdateScore();
                ++shotDown;
                //Debug.Log("Player's Score: " + score.ToString());
            }
        }

        //gamestate discisions 
        if(gamestate.state == Playstate.Paused)
        {
            TargetPause();
        }
        if (mytrigger.missed >= 50)
        {
            gamestate.state = Playstate.Gameover;
            TargetPause();
        }
        else
        {
            TargetUnpause();
        }
    }
    
    //Removes a transform from targets, Destorys the game object attached to transform 
    //Calls AddToTargets to maintain list size
    public void RemoveTarget(Transform t)
    {
        targets.Remove(t);
        Destroy(t.gameObject);
        AddToTargets();

    }

    //Instatnitate the given prefab and puts it in the transform temp
    //gives it a limited random position for 
    //Adds the temp to targets list
    public void AddToTargets()
    {
        Transform temp = Instantiate(prefab);
        temp.position = new Vector3(Random.Range(-10.0f, 10.0f), 8, 0);
        targets.Add(temp);
    }

    //increments score with given targetworth
    public void UpdateScore()
    {
        score += targetWorth;
    }
    
    //Goes throught the list of targest and sets isKenimatic to true (targest now freeze)
    public void TargetPause() 
    {
        foreach (var t in targets)
        {
            t.gameObject.GetComponent<Rigidbody>().isKinematic = true;
        }
    }
    //Goes throught the list of targest and sets isKenimatic to false (targest now move)
    public void TargetUnpause()
    {
        foreach (var t in targets)
        {
            t.gameObject.GetComponent<Rigidbody>().isKinematic = false;
        }
    }
}
