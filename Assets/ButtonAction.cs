using UnityEngine;

public class ButtonAction : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject characterPrefab;
    public Transform spawnPoint;

    public string characterTag = "Player";
    void Start()
    {
        
    }

    public void SpawnCharacter()
    {
        KillChars();
         Vector3 position = spawnPoint != null ? spawnPoint.position: characterPrefab.transform.position;

        Instantiate(characterPrefab, position, Quaternion.identity);
    }

    void KillChars()
    {
        GameObject[] existing = GameObject.FindGameObjectsWithTag(characterTag);

        foreach (GameObject go in existing)
        {
            Destroy(go);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
