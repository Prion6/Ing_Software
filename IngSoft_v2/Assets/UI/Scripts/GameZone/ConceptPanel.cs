using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConceptPanel : MonoBehaviour
{
    public List<Text> concepts;
    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    public void Init()
    {
        List<string> list = GameManager.Instance.FetchConcepts(concepts.Count);
        for(int i = 0; i < concepts.Count; i++)
        {
            concepts[i].text = list[i];
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
