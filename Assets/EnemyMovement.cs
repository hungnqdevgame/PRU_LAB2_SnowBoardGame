using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    Vector2 enemyPostion;
    [SerializeField] float speed = 5f; // Speed of the enemy movement
    Health health; // Reference to the Health script
    void Start()
    {
        enemyPostion = transform.position; // Store the initial position of the enemy
        health = FindAnyObjectByType<Health>(); // Find the Health script in the scene
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        EnemyRun();
    }

    void EnemyRun()
    {
        transform.Translate(Vector2.right * speed * Time.fixedDeltaTime);
    }

   

}
