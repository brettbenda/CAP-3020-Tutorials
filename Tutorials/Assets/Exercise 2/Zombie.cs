using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Zombie : Entity
{
    public GameObject prefab;
    Entity Target;
    // Start is called before the first frame update
    void Start()
    {
        base.Start();
        nma.speed = 2.0f;
        MaxHealth = 50;
        Health = MaxHealth;
        Damage = 30;
        AttackSpeed = 2.0f;
    }

    bool doOnce = false;
    // Update is called once per frame
    void Update()
    {
        //do base update
        base.Update();

        if (!IsNight)
        {
            if (Target == null)
                doOnce = false;

            //determine what to hunt
            if (!doOnce)
            {
                Deer[] deers = FindObjectsOfType<Deer>();
                Human[] humans = FindObjectsOfType<Human>();

                if (humans.Length != 0)
                    Target = humans[0];
                else if (deers.Length != 0)
                    Target = deers[0];
                else
                    return;

                foreach (Human h in humans)
                {
                    if (Vector3.Distance(transform.position, h.gameObject.transform.position) < Vector3.Distance(transform.position, Target.gameObject.transform.position))
                        Target = h;
                }

                foreach (Deer d in deers)
                {
                    if (Vector3.Distance(transform.position, d.gameObject.transform.position) < Vector3.Distance(transform.position, Target.gameObject.transform.position))
                        Target = d;
                }

                doOnce = true;
                Debug.Log("Found target" + Target.gameObject.name);
            }

            
            if (Target != null)
            {
                nma.SetDestination(Target.gameObject.transform.position);
            }

        }
        else
        {
            doOnce = false;
            nma.SetDestination(transform.position);
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        GameObject g = collision.gameObject;

        Debug.Log("I hit a " + g.name);
        if (g.GetComponent<Entity>())
        {
            Entity e = g.GetComponent<Entity>();
            if (g.GetComponent<Zombie>()) return;

            Attack(e);
            if (e.Health <= 0)
            {
                GameObject newZom = Instantiate(prefab);
                newZom.transform.position = e.gameObject.transform.position;
                Zombie z = newZom.GetComponent<Zombie>();
                z.MaxHealth = e.MaxHealth;
                z.Health = z.MaxHealth;
                z.prefab = prefab;
                z.IsNight = IsNight;

                Destroy(e.gameObject);
                doOnce = false;
            }
        }
    }
}
