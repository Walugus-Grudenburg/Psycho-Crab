using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JetPack : MonoBehaviour
{
    public Rigidbody2D rigidBody;
    public float speed;
    public bool isSuperJetpack;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnEnable()
    {
        speed = 1f + (10 * (isSuperJetpack ? 1 : 0));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        rigidBody.AddForce(gameObject.transform.up * speed * 10000 * Time.fixedDeltaTime);
        speed += Time.fixedDeltaTime / 2f / speed;
    }
}
