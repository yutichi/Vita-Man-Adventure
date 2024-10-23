using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommonEnemy : MonoBehaviour
{
    //‘Ì—Í
    public int _hp;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //HP‚ª0‚É‚È‚Á‚½‚ç
        if(_hp <= 0)
        {
            //”j‰ó‚·‚é
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
