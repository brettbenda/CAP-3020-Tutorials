using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    public Image dog;
    // Start is called before the first frame update
    void Start()
    {

    }

    public float timer;
    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        Color t = dog.color;
        t.a = Mathf.Abs(Mathf.Cos(timer));
        dog.color = t;

        Vector3 pos = dog.transform.position;
        pos.x += 0.01f;
        dog.transform.position = pos;
    }


}
