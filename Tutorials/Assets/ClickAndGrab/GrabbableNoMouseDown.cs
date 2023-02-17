using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabbableNoMouseDown : MonoBehaviour
{
    public bool grabbed;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //If mouse was pressed, do the raycast
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100))
            {
                GameObject go = hit.collider.gameObject;
                Debug.Log(go.name);
                if (go == gameObject)
                {
                    grabbed = true;
                    GetComponent<Collider>().enabled = false;
                }
            }
        }
        //else, if released, disable grab
        else if (Input.GetMouseButtonUp(0))
        {
            grabbed = false;
            GetComponent<Collider>().enabled = true;
        }

        
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
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 100))
        {
        GameObject go = hit.collider.gameObject;
        Debug.Log(go.name);
        if (go == gameObject)
        {
            grabbed = true;
            GetComponent<Collider>().enabled = false;
        }

        }
    }
}
