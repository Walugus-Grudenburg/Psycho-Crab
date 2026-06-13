using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaParent : MonoBehaviour
{
    public GameObject[] ObjectToSpawn;
    public bool AvoidSpawningOnTopOfCollision;
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
            TryToSpawnChild();
            objectsSpawnedThisFrame++;
        }
    }

    void TryToSpawnChild()
    {
        float spawnX = Random.Range(SpawnXMin, SpawnXMax);
        float spawnY = Random.Range(SpawnYMin, SpawnYMax);
        ContactFilter2D contactFilter = new ContactFilter2D();
        contactFilter.useTriggers = false;
        Collider2D[] nothing = new Collider2D[0];
        contactFilter.useTriggers = false;
        if (!AvoidSpawningOnTopOfCollision)
        {
            SpawnChild(spawnX, spawnY);
        }
        else if (Physics2D.OverlapPoint(new Vector2(spawnX, spawnY), contactFilter, nothing) == 0)
        {
            SpawnChild(spawnX, spawnY);
        }
    }

    void SpawnChild(float spawnX, float spawnY)
    {
        GameObject newchild = GameObject.Instantiate<GameObject>(ObjectToSpawn[Random.Range(0, ObjectToSpawn.Length)]);
        newchild.transform.parent = transform;
        newchild.transform.localPosition = new Vector3(spawnX, spawnY, 0f);
    }
}
