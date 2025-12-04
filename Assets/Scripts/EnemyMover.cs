using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    public float enemySpeed = 3f;

    void Update()
    {
        // Mueve el enemigo constantemente hacia la izquierda
        transform.Translate(Vector2.left * enemySpeed * Time.deltaTime);
    }
}