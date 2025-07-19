using System.Collections;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    private Vector2 enemyPosition;
    

    void Start()
    {
        
        StartCoroutine(SpawnEnemyLoop());
    }

    IEnumerator SpawnEnemyLoop()
    {
        while (true)
        {
            UpdateEnemyPosition(); 
            Instantiate(enemyPrefab, enemyPosition,Quaternion.Euler(0,0,-180));
            yield return new WaitForSeconds(2.5f); 
        }
    }

    void UpdateEnemyPosition()
    {
        Vector2 playerPosition = transform.position;
        enemyPosition = playerPosition + Vector2.right * 20f;
    }
}
