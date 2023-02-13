using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnCoroutine : MonoBehaviour
{
    public float angle; //how much to turn
    public float time; //how long to turn
    public float rate; //delay between animation turns

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //when the key is pressed, we start the Coroutine
        if (Input.GetKeyDown(KeyCode.T))
        {
            StartCoroutine(TurnX());
        }
        if (Input.GetKeyDown(KeyCode.Y))
        {
            StartCoroutine(TurnY());
        }
        if (Input.GetKeyDown(KeyCode.U))
        {
            StartCoroutine(TurnZ());
        }
    }

    //Handles turning around the Y axis
    IEnumerator TurnY()
    {
        int num = (int) (time / rate); //total number of turns needed
        float dTheta = angle / num; //how much we want to turn each iteration of the loop
        
        //loom num times
        for(int i = 0; i < num; i++)
        {
            //rotate by dTheta (a small amount) each iteration
            gameObject.transform.Rotate(Vector3.up, dTheta, Space.World);

            //have the coroutine wait a certain amount before the continuing the function
            yield return new WaitForSeconds(rate);
        }
    }

    IEnumerator TurnX()
    {
        int num = (int)(time / rate);
        float dTheta = angle / num;
        for (int i = 0; i < num; i++)
        {
            gameObject.transform.Rotate(Vector3.left, dTheta, Space.World);
            yield return new WaitForSeconds(rate);
        }
    }

    IEnumerator TurnZ()
    {
        int num = (int)(time / rate);
        float dTheta = angle / num;
        for (int i = 0; i < num; i++)
        {
            gameObject.transform.Rotate(Vector3.forward, dTheta, Space.World);
            yield return new WaitForSeconds(rate);
        }
    }
}
