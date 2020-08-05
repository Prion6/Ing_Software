using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TokenController : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Init(GameObject go)
    {
        Instantiate(go,transform.position,go.transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Move(Vector3 v)
    {
        transform.position = Vector3.Lerp(transform.position, v, Time.deltaTime);
    }

    public Vector3 GetStep()
    {
        return transform.position + transform.forward;
    }
}
