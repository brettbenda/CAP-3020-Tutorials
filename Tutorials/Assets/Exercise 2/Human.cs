using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Human : Entity
{
    Entity Target;

    // Start is called before the first frame update
    void Start()
    {
        base.Start();
        nma.speed = 6.0f;
        MaxHealth = 70;
        Health = MaxHealth;
        Damage = 50;
        AttackSpeed = 2.0f;
    }

    bool doOnce = false;
    bool HuntDeer = false;

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
                HuntDeer = false;
                Deer[] deers = FindObjectsOfType<Deer>();
                Zombie[] zoms = FindObjectsOfType<Zombie>();

                //figure out what to hunt
                float prob = 1.0f - (Health / (float)MaxHealth);

                //If there are deers, see if we hunt one
                if (deers.Length != 0)
                {
                    float r = Random.Range(0, 1);
                    if (r < prob)
                    {
                        HuntDeer = true;
                    }
                }
                //if not, and no zombies, do nothing
                else if(zoms.Length == 0)
                {
                    return;
                }

                //otherwise, pick the closest target
                if (HuntDeer)
                {
                    Target = deers[0];
                    foreach(Deer d in deers)
                    {
                        if (Vector3.Distance(transform.position, d.gameObject.transform.position) < Vector3.Distance(transform.position, Target.gameObject.transform.position))
                            Target = d;
                    }
                }
                else
                {
                    Target = zoms[0];
                    foreach (Zombie z in zoms)
                    {
                        if (Vector3.Distance(transform.position, z.gameObject.transform.position) < Vector3.Distance(transform.position, Target.gameObject.transform.position))
                            Target = z;
                    }
                }
                doOnce = true;
            }

            Debug.Log("Found target" + Target.gameObject.name);
            if(Target != null)
            {
                nma.SetDestination(Target.gameObject.transform.position);
            }

        }
        else
        {
            doOnce = false;
            nma.SetDestination(GameObject.Find("Shelter").transform.position);
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        GameObject g = collision.gameObject;

        Debug.Log("I hit a " + g.name);
        if (g.GetComponent<Entity>())
        {
            Entity e = g.GetComponent<Entity>();
            if (g.GetComponent<Human>()) return;


            Attack(e);
            if (e.Health <= 0)
            {
                if (g.GetComponent<Deer>())
                    Health = MaxHealth;

                Destroy(e.gameObject);
                doOnce = false;
            }
        }
    }
}
