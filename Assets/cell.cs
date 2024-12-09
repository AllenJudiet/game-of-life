using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cell : MonoBehaviour
{
    public SpriteRenderer square;
    public bool alive;
   public int neighbour=0,x;
    bool done,running;
    public int cells,n;
     cell instance;
    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }


    // Update is called once per frame
    void Update()
    {


        if (alive == true)
        {
            square.color = Color.black;
        }
        else
        {
            square.color = Color.white;
        }
         x = neighbourcheck();
        if (Input.GetMouseButton(0) == false)
        {
           

            if (done == true && running == false)
            {
                rules(x);

            }

        }
        
    }
    int neighbourcheck()
    {
        done = false;
        neighbour = 0;
        n = 0;
        RaycastHit[] hit = Physics.BoxCastAll(transform.position, transform.localScale / 2, Vector3.back);
        cells = hit.Length-1;
        foreach (RaycastHit i in hit)
        {
            if (i.transform.GetComponent<cell>().alive == true)
            {
                neighbour += 1;
            }

        }
        if (alive == true)
        {
             n = neighbour - 1;
        }
        else
        {
            n = neighbour;
        }
       
        done = true;
        return n;
    }
    
    void rules(int z)
    {
        running = true;
        if (done == true)
        {           
            if (alive == false && z == 3)
            {
                if (origin.instance.born.Contains(instance) == false)
                {
                    origin.instance.born.Add(instance);
                }

            }
           
            if (alive == true && ((z > 3)||(z < 2)))
            {
                if (origin.instance.kill.Contains(instance) == false)
                {
                    origin.instance.kill.Add(instance);
                }

            }

        
        }
        running =false;
      
        
    }
   
}
