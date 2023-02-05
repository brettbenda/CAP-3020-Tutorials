using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Animations;

public class Entity : MonoBehaviour
{
    public bool IsNight = false;
    public int MaxHealth, Health, Damage;
    public float AttackSpeed;
    public NavMeshAgent nma;
    public Rigidbody rb;
    public GameObject hb_prefab;

    // Start is called before the first frame update
    public void Start()
    {
        if (GetComponent<NavMeshAgent>() == null)
        {
            gameObject.AddComponent<NavMeshAgent>();
        }

        if (GetComponent<Rigidbody>() == null)
        {
            gameObject.AddComponent<Rigidbody>();
        }

        nma = gameObject.GetComponent<NavMeshAgent>();
        rb = gameObject.GetComponent<Rigidbody>();
        rb.isKinematic = true;
    }

    // Update is called once per frame
    public void Update()
    {
        attackTimer += Time.deltaTime;
    }

    public void ToggleTime()
    {
        IsNight = !IsNight;
    }

    public float attackTimer = 0.0f;
    public void Attack(Entity other)
    {
        if (attackTimer > AttackSpeed)
        {
            other.Health -= Damage;
            attackTimer = 0;
        }
    }
}
