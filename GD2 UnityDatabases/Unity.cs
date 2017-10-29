void Start()
{
    StartCoroutine(HandleEnterScore(123331, 12));
    //StartCoroutine(HandleGetScores());
}

IEnumerator HandleEnterScore(int score, int playerID)
{
    Debug.Log("Start Couroutine");

    //Create the url of the script with the variables that will be written to the database.
    //SetScoreUrl is the url to the php script on your website
    string score_url = setScoreUrl + "?score=" + score;

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
