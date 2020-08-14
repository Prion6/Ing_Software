using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TokenController : MonoBehaviour
{
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
    }

    public void Init(GameObject go)
    {
        GameObject g = Instantiate(go,transform.position,go.transform.rotation);
        g.transform.SetParent(transform);
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void Move()
    {
        StartCoroutine(RMove());
    }

    IEnumerator RMove()
    {
        Vector3 pos = transform.position + transform.forward;
        pos = new Vector3(transform.position.x, transform.position.y, pos.z);
        while(Vector3.Distance(pos,transform.position) > 0.1)
        {
            transform.position = Vector3.Lerp(transform.position, pos, speed*Time.deltaTime);
            yield return new WaitForFixedUpdate();
        }
    }
}
