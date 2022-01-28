using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack : MonoBehaviour
{
    Vector3 ReturnPosition;
    Quaternion ReturnRotation;
    public bool UsePos;
    public bool UseRot;
    public bool ReturnOnCollision;
    public ProgressHandler progress;
    // Start is called before the first frame update
    void Start()
    {
        ReturnPosition = gameObject.transform.position;
        ReturnRotation = gameObject.transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Return()
    {
        if (UsePos) gameObject.transform.position = ReturnPosition;
        if (UseRot) gameObject.transform.rotation = ReturnRotation;
        gameObject.SetActive(false);
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Boss Attack"))
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                progress.Reset();
            }
            else if (ReturnOnCollision)
            {
                Return();
            }
        }
    }
}
