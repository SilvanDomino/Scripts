using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class MySQLTest : MonoBehaviour
{
    private string setScoreUrl = "http://hers.hosts.ma-cloud.nl/StoreData.php";
    private string getScoreUrl = "http://hers.hosts.ma-cloud.nl/GetData.php";

    [SerializeField]
    public List<Data> data = new List<Data>();

    void Start()
    {
        StartCoroutine(HandleEnterScore(123331, 12));
    }

    IEnumerator HandleEnterScore(int score, int playerID)
    {
        Debug.Log("Start Couroutine");

        //Create the url of the script with the variables that will be written to the database.
        string score_url = setScoreUrl + "?score=" + score + "&playerID=" + playerID + "&playerID=" + checkSum(score, playerID);

        //Go to the url and get whatever the url is printing out
        WWW webRequest = new WWW(score_url);

        //wait until the site is done loading before continueing.
        //Zet deze Yield return maar aan het einde van deze functie en zie wat er gebeurt. 
        yield return webRequest;

        //Display the output. 
        //Waarom is dit geen goede error handeling?
        if (webRequest.text != "")
        {
            Debug.Log("PHP Success: " + webRequest.text);
        }
        else
        {
            Debug.Log("PHP Fail ");
        }
        
    }
    int checkSum(int score, int playerID)
    {
        return score*playerID-score+playerID / 10;
    }
}
