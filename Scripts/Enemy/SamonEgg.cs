using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SamonEgg : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        //��ʊO�ɏo����e������
        if (!GetComponent<Renderer>().isVisible)
        {
            Destroy(this.gameObject);
        }
    }
}
