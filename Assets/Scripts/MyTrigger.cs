using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyTrigger : MonoBehaviour
{
    //https://forum.unity.com/threads/calling-function-from-other-scripts-c.57072/

    [SerializeField]
    public GameObject theInstaniator;
    [SerializeField]
    public MyInstantiator scriptlink;
    public int missed = 0;//keeps track of how many the player has missed, will called by 

    private void OnTriggerEnter(Collider c)
    {
        //disableObject(c.gameObject);
        //c.gameObject.SetActive(false);
        //Debug.Log("Triggar entered yay!");
        scriptlink.RemoveTarget(c.transform);
        missed++;
    }

    private void OnCollisionEnter(Collision c)
    {

        Debug.Log("Ouch");
    }
    private void disableObject(GameObject obj)
    {
        obj.SetActive(false);
    }
}
