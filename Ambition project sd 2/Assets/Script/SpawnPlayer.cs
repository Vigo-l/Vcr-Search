using UnityEngine;

public class SpawnPlayer : MonoBehaviour
{
    [SerializeField] private GameObject player;


    void Start()
    {
        Vector3 spawnPosition = new Vector3(11, 1, -1);
        Quaternion spawnRotation = Quaternion.identity;

        SpawnPlayerPrefab(spawnPosition, spawnRotation);
    }

    void Update()
    {

    }

    public void SpawnPlayerPrefab(Vector3 position, Quaternion rotation)
    {
        if (player == null)
        {
            Debug.LogError("Player prefab is not assigned!");
            return;
        }


        Instantiate(player, position, rotation);
    }


}
