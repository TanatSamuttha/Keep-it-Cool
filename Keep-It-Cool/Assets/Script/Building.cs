using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    public float duability;
    public Building protector;
    float hitTime;
    public HitManager hitManager;

    // Start is called before the first frame update
    void Start()
    {
        protector = transform.parent.GetComponent<Building>();
    }

    // Update is called once per frame
    void Update()
    {
        if (hitTime <= hitManager.hitCooldown) hitTime += Time.deltaTime;
    }

    void Hit(float damage)
    {
        if ((protector != null && protector.duability > 0) || hitTime <= hitManager.hitCooldown) return;
        hitTime = 0;
        duability -= damage;
    }
}
