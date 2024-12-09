using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
public class origin : MonoBehaviour
{
    public GameObject cell;
    public int n = 20;
    Vector3 position1, position2;
    float k = 0, q, initial;
    int j, i, y = 3, T;
    public bool running,pause;
   public List<cell> kill;
    public List<cell> born;
    public int x=1, w=1;
    public static origin instance;
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

        if (running == false)
        {
            T = grid(y);
            y = grid(T);
        }
        if (pause == false)
        {
         destroy();
         create();
        }
       

        if (pause == true)
        {
            Time.timeScale = 0;

        }
        else
        {
            Time.timeScale = 1;
        }
             
        

    }
        int grid(int d)
        {
            running = true;
            for (i = d; i < n; i += 2)
            {

                k += 1;
                position1 = new Vector3(-k, k, 0);
                position2 = new Vector3(-k, -k, 0);
                for (j = 0; j < i; j++)
                {


                    Instantiate(cell, position1, Quaternion.identity);
                    Instantiate(cell, position2, Quaternion.identity);
                    position1 += new Vector3(1, 0, 0);
                    position2 += new Vector3(1, 0, 0);


                }
                q = k - 1;
                for (int m = 0; m < (j - 2); m++)
                {



                    Instantiate(cell, new Vector3(-k, q, 0), Quaternion.identity);
                    Instantiate(cell, new Vector3(k, q, 0), Quaternion.identity);
                    q -= 1;

                }
            }

            running = false;

            return i;
        }
    void destroy() 
    {
        foreach (cell p in kill)
        {
            p.alive = false;
            x += 1;
            if (x >= kill.Count)
            {
                kill.Clear();
                x = 0;
                break;
            }
        }
    }
    void create()
    {
        foreach (cell v in born)
        {
            v.alive = true;
            w += 1;
            if (w >= born.Count)
            {
                born.Clear();
                w = 0;
                break;
            }
        }
    }

        
    
}
