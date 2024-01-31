using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public class Graviton : MonoBehaviour
{
    Rigidbody2D rigidBody;
    [SerializeField] bool isAttractor;//field
    public bool IsAttractor//property
    {
        get
        {
            return isAttractor;
        }
        set
        {
            if (value == true)
            {
                if (!GravityHandler.attractors.Contains(this.GetComponent<Rigidbody2D>()))
                    GravityHandler.attractors.Add(rigidBody);
            }
            else if (value == false)
            {
                GravityHandler.attractors.Remove(rigidBody);
            }
            isAttractor = value;
        }
    }
    [SerializeField] bool isAttractee;//field
    public bool IsAttractee//property 
    {
        get
        {
            return isAttractee;
        }
        set
        {
            if (value == true)
            {
                if (!GravityHandler.attractees.Contains(this.GetComponent<Rigidbody2D>()))
                {
                    GravityHandler.attractees.Add(rigidBody);
                }

            }
            else if (value == false)
            {
                GravityHandler.attractees.Remove(rigidBody);
            }
            isAttractee = value;
        }
    }

    [SerializeField] Vector3 initialVelocity;
    [SerializeField] bool applyInitialVelocityOnStart;
    void Awake()
    {
        rigidBody = this.GetComponent<Rigidbody2D>();
        rigidBody.mass = Random.Range(5, 100);
        rigidBody.drag = Random.Range(5, 10);
    }
    void OnEnable()
    {
        IsAttractor = isAttractor;
        IsAttractee = isAttractee;
    }
    void Start()
    {
        //initialVelocity = new Vector3(Random.Range(-10,10), Random.Range(-10,10), 0);
        if (applyInitialVelocityOnStart)
        {
            ApplyVelocity(initialVelocity);
        }
    }
    void OnDisable()
    {
        GravityHandler.attractors.Remove(rigidBody);
        GravityHandler.attractees.Remove(rigidBody);
    }
    void ApplyVelocity(Vector3 velocity)
    {
        rigidBody.AddForce(initialVelocity, ForceMode2D.Impulse);
    }
}
