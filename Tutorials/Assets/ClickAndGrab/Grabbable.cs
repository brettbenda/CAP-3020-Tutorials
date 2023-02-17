using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grabbable : MonoBehaviour
{
    public bool grabbed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (grabbed)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100))
            {
                transform.position = hit.point;
            }
        }
    }

    private void OnMouseDown()
    {
        grabbed = true;
        GetComponent<Collider>().enabled = false;
    }

    public void OnMouseUp()
    {
        grabbed = false;
        GetComponent<Collider>().enabled = true;
    }
}
