using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyInstantiator : MonoBehaviour
{
    [SerializeField]
    protected Transform prefab;
    [SerializeField]
    protected Camera cam;
    [SerializeField]
    protected int AmountofTargets;
    [SerializeField]
    protected int targetWorth;

    List<Transform> targets;
    protected int score; //keeps track of score, later printed in the Debug.Log
    public int shotDown = 0; // keeps track of how many targest have been hit.

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
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePos = Input.mousePosition;
            Ray ray = cam.ScreenPointToRay(mousePos);
            RaycastHit rch;
            if (Physics.Raycast(ray, out rch))
            {
                Debug.Log("Player click on on '" + rch.transform.name + "'");
                RemoveTarget(rch.transform);
                UpdateScore();
                ++shotDown;
                Debug.Log("Player's Score: " + score.ToString());
            }
        }
    }
    
    public void RemoveTarget(Transform t)
    {
        targets.Remove(t);
        Destroy(t.gameObject);
        AddToTargets();

    }
    public void AddToTargets()
    {
        Transform temp = Instantiate(prefab);
        temp.position = new Vector3(Random.Range(-10.0f, 10.0f), 8, 0);
        targets.Add(temp);
    }
    public void UpdateScore()
    {
        score += targetWorth;
    }
}
