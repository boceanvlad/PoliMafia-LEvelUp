using UnityEngine;
using System.Collections;

public class AreaSpawner : MonoBehaviour
{
    // Number of times the spawner will try to find a position for the actor to be spawned
    private const int SPAWN_ATTEMPTS = 10;
    // The collision area that must be available for the new Actor to spawn
    public float spawnRadius;
    // How often (in seconds) the Spawner will attempt to spawn a new actor
    //
    public float spawnFrequencyInSeconds;
    public float speedMultiplier;
    // An array of all Actors to be Spawned
    public Movable[] actorsToSpawn;
    public Vector3 directie;
    // Keep the next element to spawn until we successfully spawn it so the spawning chances stay fair even when some spawn attempts fail
    private Movable nextElementToSpawn;
    // The rectangle inside of which elements are spawned.
    private RectTransform spawningArea;
    // The time until the next element should spawn
    private float timeToNextSpawn;

    // Use this for initialization
    void Start ()
    {

        spawningArea = GetComponent<RectTransform>();
        if (spawningArea == null)
        {
            Debug.LogError("A spawner required a RectTransform components as a spawning area!");
        }
        timeToNextSpawn = spawnFrequencyInSeconds;
        if (actorsToSpawn.Length == 0)
        {
            Debug.LogError("A Spawner needs at least one Actor in the spawn list");
        }
    }
	
    // Update is called once per frame
    void Update ()
    {
        timeToNextSpawn -= Time.deltaTime;
        if (timeToNextSpawn < 0)
        {
            // If there is no Actor queued to be spawned, generate one -- otherwise attempt to spawn the queued Actor
            if (nextElementToSpawn == null)
            {
                nextElementToSpawn = GenerateActorToSpawn();
                nextElementToSpawn = GenerateActorToSpawn();
            }
            AttemptSpawn();
        }
    }

    private void AttemptSpawn ()
    {
        for (int i = SPAWN_ATTEMPTS; i > 0; --i)
        {
            float spawnPosX = Random.Range(spawningArea.rect.position.x, spawningArea.rect.position.x + spawningArea.rect.size.x);
            float spawnPosY = Random.Range(spawningArea.rect.position.y, spawningArea.rect.position.y + spawningArea.rect.size.y);
            Vector2 pos = new Vector2(spawnPosX, spawnPosY);
            if (ValidPosition(pos))
            {
                timeToNextSpawn = spawnFrequencyInSeconds;
                Spawn(pos);
                nextElementToSpawn = GenerateActorToSpawn();
                break;
            }
        }
    }


    #region Protected - These methods can be overwritten in extending classes for more specific spawners

    protected Movable GenerateActorToSpawn ()
    {        
        // Randomly return any element in the elementsToSpawn array
        return actorsToSpawn[Random.Range(0, actorsToSpawn.Length)];
    }

    protected bool ValidPosition (Vector2 pos)
    {        
        Collider2D collider = Physics2D.OverlapCircle(pos, spawnRadius);
        return (collider == null);
    }

    protected void Spawn (Vector2 pos)
    {   
        Movable newActor = Instantiate(nextElementToSpawn) as Movable;
        newActor.speed *= speedMultiplier;
        newActor.transform.SetParent(transform);
        newActor.transform.localPosition = pos;
        newActor.direction = directie;
        if (directie.x == -1)
            newActor.transform.localScale *= -1;
    }

    #endregion
}
