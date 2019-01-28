
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FishFeed : Feed
{
    Fish fish;
    Display display;
    Text t;
    bool pause=false;
  //  GameObject go;

    void Start()
    {
        fish = GetComponent<Fish>();
     //   go = GameObject.FindGameObjectWithTag("Finish");
        //fish.display.GetComponent<Timer>().timer = 10;
        //fish.display.GetComponent<Timer>().StartTimer();


    }



    new void Update()
    {
        //    if (pause)
        //       GameObject.Find("Timer").GetComponent<Text>().text = "";

        ////    if (base.Update()&& pause==false)
        ////    {
        ////        pause = true;
        ////        GameObject.Find("Timer").GetComponent<Text>().text = "";
        ////        //fish.display.GetComponent<Timer>().timer = 10; 
        ////        fish.speechBubble.SetActive(false);
        ////      //  fish.display.timer.text = "X";
        ////        GameObject.Find("Timer").GetComponent<Text>().text = "X";
        ////        // fish.display.GetComponent<Timer>().StartTimer();
        ////         
        ////        this.enabled = false;
        ///

       


    }
       



    ////}
    
    void OnMouseDown()
    {
        
        fish.speechBubble.SetActive(false);
        StartCoroutine(GetNewAction());
        this.enabled = false;
    }


   


    //   }
    public IEnumerator GetNewAction()
    {

       // go = GameObject.FindGameObjectWithTag("Finish");
        if(fish.go!=null)
        fish.go.SetActive(false);
       
        yield return new WaitForSeconds(5);
        if (fish.go != null)
            fish.go.SetActive(true);
        
        fish.display.GetComponent<Timer>().timer = 10;
        GameObject.Find("Timer").GetComponent<Text>().text = fish.display.GetComponent<Timer>().timer.ToString();
        fish.Feed();
    }
   

}
