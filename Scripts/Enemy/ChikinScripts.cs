using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChikinScripts : MonoBehaviour
{
    private Vector2 pos;
    public float _speed;

    public int num = 1;

    [SerializeField]
    private float _turnPointLD
                 ,_turnPointRU;

    [SerializeField]
    private bool _widthHeightChange;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!GetComponent<Renderer>().isVisible) return;

        pos = transform.position;

        if(_widthHeightChange == true)
        {
            transform.Translate(transform.right * Time.deltaTime * _speed * num);

            if (pos.x > _turnPointRU)
            {
                num = -1;
            }
            if (pos.x < _turnPointLD)
            {
                num = 1;
            }
        }
        else if(_widthHeightChange == false) 
        { 
            transform.Translate(transform.up * Time.deltaTime * _speed * num);

            if (pos.y > _turnPointRU)
            {
                num = -1;
            }
            if (pos.y < _turnPointLD)
            {
                num = 1;
            }
        }
    }
}
