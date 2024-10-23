using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommonEnemy : MonoBehaviour
{
    //体力
    public int _hp;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //HPが0になったら
        if(_hp <= 0)
        {
            //破壊する
            Destroy(this.gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Bullet")
        {
            _hp = _hp - CommonWeapon.Damage;
        }
    }
}
