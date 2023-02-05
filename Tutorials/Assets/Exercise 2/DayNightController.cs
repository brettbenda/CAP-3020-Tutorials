using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightController : MonoBehaviour
{
    public Entity[] entities;
    public float timer = 0.0f;
    public Light sun;

    // Start is called before the first frame update
    void Start()
    {
        entities = GameObject.FindObjectsOfType<Entity>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer > 10)
        {
            entities = GameObject.FindObjectsOfType<Entity>();
            foreach (Entity e in entities)
            {
                e.ToggleTime();
            }
            timer = 0;
        }
        sun.transform.Rotate(new Vector3((360 / 20.0f)*Time.deltaTime, 0, 0));
    }
}
