using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class SalvarScore : MonoBehaviour
{
    [Space(10)]
    [Header("User Settings")]

    //uploaded php files url
    public string myUrl = "http://localhost/scripts2/";

    [Space(10)]
    [Header("Fields")]

    //public InputField playerName;

    //public InputField playerScore;

    public Button saveButton;

    UIManager uiManager;
    GameManager gameManager;

    //Server side urls
    private string insertUrl = "insert.php";

    private string playerExistUrl = "isplayerexist.php";

    Button btPlay;


    void Start()
    {
        // Add listener to Save button
        //Button btnN = saveButton.GetComponent<Button>();
        //btnN.onClick.AddListener(saveScore);

        //Testar ak 03/02 as 10:48
        //StartCoroutine (getPlayerisExist ("Marcio"));
        //Testar acima

        uiManager = GameObject.Find("UIManager").GetComponent<UIManager>();
        gameManager = GameObject.Find("Gerenc").GetComponent<GameManager>();
        //btPlay.onClick.AddListener(VerificarUser);
    }

    // send data to server
    IEnumerator Insert(string player, int score)
    {
        WWWForm form = new WWWForm();
        form.AddField("player", player);
        form.AddField("score", score);

        //send post request to server
        UnityWebRequest www = UnityWebRequest.Post(myUrl + insertUrl, form);
        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);
        }
        else
        {
            Debug.Log("Form insert complete!");
        }
    }

    // example is how to sent player's data
    // player's name and player's score 
    // player's score date time create by automatically
    public void saveScore()
    {
        //Comentar para teste
        StartCoroutine(Insert(uiManager.txtUser.text, gameManager.pontosPlayer));
        //Comentar para teste
        //clearMessages();
    }
    /*public void VerificarUser()
    {
        StartCoroutine(getPlayerisExist(uiManager.txtUser.text));
    }*/

    // clear fields text
    /*private void clearMessages()
    {
        playerName.text = "";
        playerScore.text = "";
    }
    */
    //players highest score
    /*private bool isExist = false;
    private string playerInfo = "";

    // you can use this method for player is exist     
    public IEnumerator getPlayerisExist(string player)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(myUrl + playerExistUrl + "?player=" + player))
        {

            yield return webRequest.SendWebRequest();

            //Debug.Log("Chamou3");
            if (webRequest.isNetworkError || webRequest.isHttpError)
            {
                // You can use Debug logs 
                 //Debug.Log ("Error: " + webRequest.error);
                
            }
            else
            {
                //received player is exist from database         
                playerInfo = "" + webRequest.downloadHandler.text.Trim();
                if (!playerInfo.Equals("") && playerInfo != null)
                {
                    isExist = true;
                    gameManager.btComec = true;
                    uiManager.cvMenu.SetActive(false);
                    Time.timeScale = 1;
                }
            }

        }
        // You can use Debug logs 
        //Debug.Log ("Player is exist = " + isExist);
        if(!isExist)
        {
            uiManager.txtAviso.text = "Nome não encontrado";
            uiManager.txtAviso.color = Color.red;
        }
    }*/
}
