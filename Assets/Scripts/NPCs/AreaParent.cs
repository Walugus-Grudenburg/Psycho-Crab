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
    private int maximumObjectsToSpawnInOneFrame;

    // Start is called before the first frame update
    void Start()
    {
        if (!Target)
        {
            Target = ProgressHandler.maininstance.gameObject;
        }
        maximumObjectsToSpawnInOneFrame = (DesiredChildCount / 100) + 1;
    }

    // Update is called once per frame
    void Update()
    {
        int objectsSpawnedThisFrame = 0;
        while (gameObject.transform.childCount < DesiredChildCount && Vector3.Distance(transform.position, Target.transform.position) < DeactivationDistance && objectsSpawnedThisFrame < maximumObjectsToSpawnInOneFrame)
        {
            SpawnChild();
            objectsSpawnedThisFrame++;
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
