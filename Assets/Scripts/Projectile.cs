using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed;
    public float lifetime;
    public GameObject particles;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, lifetime); 
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }

    private void OnDestroy()
    {
        Instantiate(particles, transform.position, Quaternion.identity);
    }
}
