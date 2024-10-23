using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommonWeapon : MonoBehaviour
{
    //�e�̍U����
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
        //��ʊO�ɏo����e������
        if (!GetComponent<Renderer>().isVisible)
        {
            Debug.Log("Bullet");
            Destroy(this.gameObject);
        }

        //5�b��ɒe������
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
