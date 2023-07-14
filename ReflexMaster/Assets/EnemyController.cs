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
            Debug.LogError("Hexagon Piece Prefab tanýmlanmamýþ.");
            return;
        }

        // Hexagonun merkezini alýn
        Vector2 hexagonCenter = transform.position;

        // Hexagonun altý kenarýný parçalara bölelim
        int numPieces = 20;
        float angleIncrement = 360f / numPieces;

        // Her bir parça için dönerken yeni bir parça oluþturun
        for (int i = 0; i < numPieces; i++)
        {
            // Yeni bir parça oluþturun
            GameObject hexagonPiece = Instantiate(hexagonPiecePrefab, hexagonCenter, Quaternion.identity);

            // Parçaya bir güç uygulayarak parçalarý daðýtýn
            Rigidbody2D pieceRigidbody = hexagonPiece.GetComponent<Rigidbody2D>();
            float forceMagnitude = 5f;
            Vector2 forceDirection = Quaternion.Euler(0f, 0f, i * angleIncrement) * Vector2.up;
            pieceRigidbody.AddForce(forceDirection * forceMagnitude, ForceMode2D.Impulse);
        }

        // Orijinal hexagonu yok edin
        Destroy(gameObject);
    }
}
