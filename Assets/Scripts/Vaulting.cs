using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vaulting : MonoBehaviour
{
    private int vaultLayer;
    private float playerHeight = 1.76f;
    private float playerRadius = 0.5f;

    void Start()
    {
        vaultLayer = LayerMask.NameToLayer("VaultLayer");
        vaultLayer = ~vaultLayer;
    }

    void Update()
    {
        Vault();
    }

    private void Vault()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (Physics.Raycast(transform.position + Vector3.up * playerHeight, transform.forward, out var firstHit, 1f, vaultLayer))
            {
                Debug.DrawRay(transform.position + Vector3.up * playerHeight, transform.forward * firstHit.distance, Color.green); // Rysuje raycast w kierunku forward
                print("vaultable in front");

                Vector3 vaultStart = firstHit.point + (transform.forward * playerRadius) + (Vector3.up * 0.6f * playerHeight);
                if (Physics.Raycast(vaultStart, Vector3.down, out var secondHit, playerHeight))
                {
                    Debug.DrawRay(vaultStart, Vector3.down * playerHeight, Color.blue); // Rysuje raycast w kierunku down
                    print("found place to land");
                    GetComponent<Animator>().SetTrigger("Climb");
                    StartCoroutine(LerpVault(secondHit.point, 0.5f));
                }
            }
        }
    }

    IEnumerator LerpVault(Vector3 targetPosition, float duration)
    {
        float time = 0;
        Vector3 startPosition = transform.position;

        while (time < duration)
        {
            transform.position = Vector3.Lerp(startPosition, targetPosition, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        transform.position = targetPosition;
    }

    private void OnDrawGizmos()
    {
        // Rysuje linie raycastów w widoku sceny podczas edycji
        Gizmos.color = Color.green;
        Gizmos.DrawRay(transform.position + Vector3.up * playerHeight, transform.forward * 1f);

        Vector3 vaultStart = transform.position + Vector3.up * playerHeight + (transform.forward * playerRadius) + (Vector3.up * 0.6f * playerHeight);
        Gizmos.color = Color.blue;
        Gizmos.DrawRay(vaultStart, Vector3.down * playerHeight);
    }
}
