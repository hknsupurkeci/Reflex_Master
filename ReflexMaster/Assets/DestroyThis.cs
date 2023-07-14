using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyThis : MonoBehaviour
{
    void Start()
    {
        Invoke("DestroyObject", 1f);
    }

    private void DestroyObject()
    {
        Destroy(this.gameObject);
    }
}
