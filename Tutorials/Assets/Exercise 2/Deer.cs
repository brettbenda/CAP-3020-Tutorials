using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Deer : Entity
{
    GameObject Target;
    // Start is called before the first frame update
    void Start()
    {
        base.Start();
        nma.speed = 7.0f;
        MaxHealth = 90;
        Health = MaxHealth;
        Damage = 100;
        AttackSpeed = 4.0f;
    }

    bool doOnce = false;
    // Update is called once per frame
    void Update()
    {
        //do base update
        base.Update();

        if(IsNight)
        {
            //determine what tree to go to
            if (!doOnce)
            {
                GameObject[] trees = GameObject.FindGameObjectsWithTag("Tree");
                int r = Random.Range(0, trees.Length);
                Target = trees[r];
            }

            Debug.Log("Found target" + Target.gameObject.name);
            if (Target != null)
            {
                nma.SetDestination(Target.transform.position);
            }

        }
        else
        {
            Human[] humans = FindObjectsOfType<Human>();
            Zombie[] zoms = FindObjectsOfType<Zombie>();

            GameObject targ;

            if (humans.Length != 0)
                targ = humans[0].gameObject;
            else if (zoms.Length != 0)
                targ = zoms[0].gameObject;
            else
                return;

            foreach (Human h in humans)
            {
                if (Vector3.Distance(transform.position, h.gameObject.transform.position) < Vector3.Distance(transform.position, targ.gameObject.transform.position))
                    targ = h.gameObject;
            }

            foreach (Zombie z in zoms)
            {
                if (Vector3.Distance(transform.position, z.gameObject.transform.position) < Vector3.Distance(transform.position, targ.gameObject.transform.position))
                    targ = z.gameObject;
            }

            Vector3 d = gameObject.transform.position - targ.transform.position;
            nma.SetDestination(gameObject.transform.position + d);
        }
    }
}
