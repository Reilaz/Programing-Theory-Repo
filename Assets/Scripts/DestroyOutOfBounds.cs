using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    [SerializeField] private float sideBoundry = 18;
    void Update()
    {
        if (transform.position.x > sideBoundry)
        {
            gameObject.SetActive(false);
        }
        if (transform.position.x < -sideBoundry)
        {
            gameObject.SetActive(false);
        }
    }
}
