using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CowScripts : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;

    private Vector2 pos;
    public int _speed;

    public int num = 1;

    [SerializeField]
    private int _turnPointL
               ,_turnPointR;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!GetComponent<Renderer>().isVisible) return;

        pos = transform.position;
        transform.Translate(transform.right * Time.deltaTime * _speed * num);

        if(pos.x > _turnPointR)
        {
            num = -1;
        }
        if(pos.x < _turnPointL) 
        {
            num = 1;
        }
    }
}
