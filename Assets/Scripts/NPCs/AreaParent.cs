using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaParent : MonoBehaviour
{
    public GameObject[] ObjectToSpawn;
    public float SpawnXMin;
    public float SpawnXMax;
    public float SpawnYMin;
    public float SpawnYMax;
    public GameObject Target;
    public int DesiredChildCount;
    public float DeactivationDistance;

    // Start is called before the first frame update
    void Start()
    {
        if (!Target)
        {
            Target = ProgressHandler.maininstance.gameObject;
        }
    }

    // Update is called once per frame
    void Update()
    {
        while (gameObject.transform.childCount < DesiredChildCount && Vector3.Distance(transform.position, Target.transform.position) < DeactivationDistance)
        {
            SpawnChild();
        }
    }

    void SpawnChild()
    {
        float spawnX = Random.Range(SpawnXMin, SpawnXMax);
        float spawnY = Random.Range(SpawnYMin, SpawnYMax);
        GameObject newchild = GameObject.Instantiate<GameObject>(ObjectToSpawn[Random.Range(0, ObjectToSpawn.Length)]);
        newchild.transform.parent = transform;
        newchild.transform.localPosition = new Vector3(spawnX, spawnY, 0f);
    }
}
