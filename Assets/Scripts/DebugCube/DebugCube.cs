using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugCube : MonoBehaviour
{
    [Range(0.0f, 90.0f)]
    [SerializeField]
    public float rotationSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Havi ikki váttað tað enn; ger so at objektið roterar við "rotationSpeed" gradum per sekund.
        transform.Rotate(rotationSpeed * Time.deltaTime, rotationSpeed * Time.deltaTime, rotationSpeed * Time.deltaTime);
    }
}
