using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameObject hexagonPiecePrefab;

    public float speed = 5;
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, Vector2.zero, speed * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "FingerDetector")
        {
            BreakHexagon();
            Camera.main.GetComponent<ScreenShake>().ShakeScreen();
        }
    }
    private void BreakHexagon()
    {
        if (hexagonPiecePrefab == null)
        {
            Debug.LogError("Hexagon Piece Prefab tan�mlanmam��.");
            return;
        }

        // Hexagonun merkezini al�n
        Vector2 hexagonCenter = transform.position;

        // Hexagonun alt� kenar�n� par�alara b�lelim
        int numPieces = 20;
        float angleIncrement = 360f / numPieces;

        // Her bir par�a i�in d�nerken yeni bir par�a olu�turun
        for (int i = 0; i < numPieces; i++)
        {
            // Yeni bir par�a olu�turun
            GameObject hexagonPiece = Instantiate(hexagonPiecePrefab, hexagonCenter, Quaternion.identity);

            // Par�aya bir g�� uygulayarak par�alar� da��t�n
            Rigidbody2D pieceRigidbody = hexagonPiece.GetComponent<Rigidbody2D>();
            float forceMagnitude = 5f;
            Vector2 forceDirection = Quaternion.Euler(0f, 0f, i * angleIncrement) * Vector2.up;
            pieceRigidbody.AddForce(forceDirection * forceMagnitude, ForceMode2D.Impulse);
        }

        // Orijinal hexagonu yok edin
        Destroy(gameObject);
    }
}
