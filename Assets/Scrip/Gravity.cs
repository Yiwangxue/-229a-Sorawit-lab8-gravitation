using UnityEngine;
using UnityEngine;
using System.Collections.Generic;
public class Gravity : MonoBehaviour
{

    Rigidbody rb;
    const float G = 0.006674f;
    public static List<Gravity> gravityObjectList;
    

    [SerializeField]
    bool planets = false;
    [SerializeField]
    int orbitSpeed = 1000;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();

        if (gravityObjectList == null)
        {
            gravityObjectList = new List<Gravity>();

        }

        gravityObjectList.Add(this);

    }

    private void FixedUpdate()
    {
        foreach (var obj in gravityObjectList)
        {
            if (obj != this)
            {
                Attract(obj);
            }
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Attract(Gravity other)
    {
        Rigidbody otherRb = other.rb;
        Vector3 direction = rb.position - otherRb.position;
        float distance = direction.magnitude;

        float forceMagnitude = G * (rb.mass * otherRb.mass / Mathf.Pow(distance, 2));
        Vector3 gravityForce = forceMagnitude * direction.normalized;

        otherRb.AddForce(gravityForce);
    }

     

   
}
