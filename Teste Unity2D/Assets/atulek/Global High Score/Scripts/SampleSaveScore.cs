using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class SampleSaveScore : MonoBehaviour {
    
     [Space (10)]
    [Header ("User Settings")]

    //uploaded php files url
    public string myUrl ="www.your_domain_name.com/";
    
    [Space (10)]
    [Header ("Fields")]

    public InputField playerName;

    public InputField playerScore;

    public Button saveButton;
    
    //Server side urls
    private string insertUrl = "insert.php";    

    private string playerExistUrl ="isplayerexist.php";


    void Start() {
        // Add listener to Save button
        Button btnN = saveButton.GetComponent<Button> ();
        btnN.onClick.AddListener (saveScore);

        //Testar ak 03/02 as 10:48
        StartCoroutine (getPlayerisExist ("Samuel"));
        //Testar acima
    }

    // send data to server
    IEnumerator Insert (string player, int score) {
        WWWForm form = new WWWForm ();
        form.AddField ("player", player);
        form.AddField ("score", score);

        //send post request to server
        UnityWebRequest www = UnityWebRequest.Post (myUrl + insertUrl, form);
        yield return www.SendWebRequest ();

        if (www.isNetworkError || www.isHttpError) {
            Debug.Log (www.error);
        } else {
            Debug.Log ("Form insert complete!");
        }
    }

    // example is how to sent player's data
    // player's name and player's score 
    // player's score date time create by automatically
    public void saveScore () {
        StartCoroutine (Insert (playerName.text, int.Parse (playerScore.text)));
        clearMessages ();
    }

    // clear fields text
    private void clearMessages () {
        playerName.text = "";
        playerScore.text = "";
    }     

    //players highest score
    private bool isExist = false;
    private string playerInfo = "";

    // you can use this method for player is exist     
    IEnumerator getPlayerisExist (string player) {
        using (UnityWebRequest webRequest = UnityWebRequest.Get (myUrl + playerExistUrl + "?player=" + player)) {

            yield return webRequest.SendWebRequest ();            

            if (webRequest.isNetworkError || webRequest.isHttpError) {
                // You can use Debug logs 
                //Debug.Log ("Error: " + webRequest.error);
                //Debug.Log(player);
            } else {
                //received player is exist from database         
                playerInfo = "" + webRequest.downloadHandler.text.Trim ();
                if (!playerInfo.Equals("") && playerInfo != null)
                    isExist = true;
            }
            
        }
        // You can use Debug logs 
        Debug.Log ("Player is exist = " + isExist);
    }

   
}