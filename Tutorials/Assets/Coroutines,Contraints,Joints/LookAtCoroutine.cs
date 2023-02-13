using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class LookAtCoroutine : MonoBehaviour
{
    LookAtConstraint lac;
    public int duration;

    // Start is called before the first frame update
    void Start()
    {
        //get a reference to the LookAtConstraint on the attached gameobject
        lac = GetComponent<LookAtConstraint>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.L))
        {
            StartCoroutine(LookAt());
        }
    }

    IEnumerator LookAt()
    {
        //turn it on; it will follow the player
        lac.constraintActive = true;           
        //wait for the set duration before executing the code further
        yield return new WaitForSeconds(duration);
        //turn off the constraint
        lac.constraintActive = false;       
    }
}
