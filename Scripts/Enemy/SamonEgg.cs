using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SamonEgg : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        //‰æ–ÊŠO‚Éo‚½‚ç’e‚ğÁ‚·
        if (!GetComponent<Renderer>().isVisible)
        {
            Destroy(this.gameObject);
        }
    }
}
