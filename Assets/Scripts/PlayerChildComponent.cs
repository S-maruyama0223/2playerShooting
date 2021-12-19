using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerChildComponent : MonoBehaviour
{
    GameObject parent;
    // Start is called before the first frame update
    void Start()
    {
        parent = transform.root.gameObject;
        Debug.Log(parent.tag);
    }

    // Update is called once per frame
    void Update()
    {
        transform.SetParent(parent.transform, true);

    }
}
