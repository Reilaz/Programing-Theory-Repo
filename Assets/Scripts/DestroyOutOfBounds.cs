using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    [SerializeField] private float sideBoundry = 18;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
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
