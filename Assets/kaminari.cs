using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kaminari : MonoBehaviour
{
    public float aida; 
    public float kesu; 
    public float dasu; 
    public GameObject Thunder;
    
    // Start is called before the first frame update
    public void Start()
    {
        // 
        aida=Random.Range(1.3f,1.5f);
        kesu=Random.Range(0.7f,1.0f);
        dasu=Random.Range(0.3f,0.5f);
        Thunder.gameObject.SetActive(false);
    }
    // Update is called once per frame
    public void OnClick()
    {
        if(dasu>aida){
            dasu=Random.Range(0.3f,0.5f);;

            Thunder.gameObject.SetActive(true);
        }
    
    }
    public void Update() {
        dasu+=Time.deltaTime;
        if(dasu>kesu){
            kesu=Random.Range(0.7f,1.0f);
            Thunder.gameObject.SetActive(false);
        }
    }
}
