using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommonWeapon : MonoBehaviour
{
    //弾の攻撃力
    public static int Damage;
    public int _damage;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Awake()
    {
        Damage = _damage;   
    }

    // Update is called once per frame
    void Update()
    {
        //画面外に出たら弾を消す
        if (!GetComponent<Renderer>().isVisible)
        {
            Debug.Log("Bullet");
            Destroy(this.gameObject);
        }

        //5秒後に弾を消す
        Destroy(this, 5f);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Destroy(this.gameObject);
        }
    }
}
