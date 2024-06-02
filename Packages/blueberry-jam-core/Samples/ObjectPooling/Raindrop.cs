using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raindrop : MonoBehaviour
{
    /**
     * @brief Speed at which the rain will move down
     */
    [SerializeField]
    private float speed = 1.0f;

    private void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);
    }
}
