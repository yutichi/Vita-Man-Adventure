using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SamonEgg : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        //画面外に出たら弾を消す
        if (!GetComponent<Renderer>().isVisible)
        {
            Destroy(this.gameObject);
        }
    }
}
