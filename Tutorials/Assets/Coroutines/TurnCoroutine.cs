using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnCoroutine : MonoBehaviour
{
    public float angle;
    public float time;
    public float rate;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            StartCoroutine(Turn());
        }
    }

    IEnumerator Turn()
    {
        int num = (int) (time / rate);
        float dTheta = angle / num;
        for(int i = 0; i < num; i++)
        {
            gameObject.transform.Rotate(Vector3.up, dTheta);
            Debug.Log(i);
            yield return new WaitForSeconds(rate);
        }
    }
}
