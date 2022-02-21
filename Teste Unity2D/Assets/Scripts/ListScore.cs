using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

// data value object of the player's data
namespace ScoreService.Models
{
    public class PlayerScoreDto2
    {
        //player's score
        public int score { get; set; }
        //player's name
        public string PlayerName { get; set; }
        //player's score time
        public string scoretime { get; set; }
    }
}

public class ListScore : MonoBehaviour
{
    [Space(10)]
    [Header("User Settings")]

    //uploaded php files url
    public string myUrl = "http://localhost/scripts2/";

    // display maximum scorerLimit
    // defoult 100
    public int scorerLimit;

    [Space(10)]
    [Header("Form Settings")]

    public GameObject textGenerate;

    public GameObject parent;

    //Server side urls
    private string selectUrl = "select.php";
    private string getPlayerScoreUrl = "getplayerscore.php";
    private string getPlayerRankUrl = "getplayersrank.php";

    //all data from database
    private static string allScores = "";
    //set number of pages
    private static int pageNumber = 10;
    //init count scores
    private static int count = 0;

    // Collection of Scores List 
    private static List<ScoreService.Models.PlayerScoreDto2> myList;

    private void Awake()
    {
        parent = GameObject.Find("ListScore");
    }
    void Start()
    {
        //Get all scores from database 
        StartCoroutine(GetRequest());

        //StartCoroutine(DeleteScore());

    }
    private void Update()
    {
        if(!parent)
        {
            parent = GameObject.Find("ListScore");
            StartCoroutine(GetRequest());
        }
            
    }

    //Get all scores from server        
    IEnumerator GetRequest()
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(myUrl + selectUrl + "?limit=" + scorerLimit))
        {
            yield return webRequest.SendWebRequest();

            if (webRequest.isNetworkError)
            {
                // You can use Debug logs 
                //Debug.Log ("Error: " + webRequest.error);
            }
            else
            {
                //received data from database         
                allScores = "" + webRequest.downloadHandler.text;
            }

            myList = new List<ScoreService.Models.PlayerScoreDto2>();

            if (allScores != "")
            {
                ScoreService.Models.PlayerScoreDto2 dto = null;
                string temp = "";

                int d = 0;
                int l = 0;
                int count = playersCount(allScores);

                // separate from data and add myList collection
                // received data like this => Adrain,2700,2020-01-01 00:00:00;
                // player,score,scoretime;player2,score,scoretime;...
                for (int i = 0; i < count; i++)
                {
                    dto = new ScoreService.Models.PlayerScoreDto2();

                    temp = allScores.Substring(0, allScores.IndexOf(','));
                    d = allScores.IndexOf(',') + 1;
                    /*if(gm.atLista)
                    {
                        l = allScores.Length - d + gm.contCaracteres;
                        gm.atLista = false;
                    }
                        
                    else
                        l = allScores.Length - d;
                    Debug.Log(l);*/
                    l = allScores.Length - d;

                    allScores = allScores.Substring(d, l);
                    dto.PlayerName = temp;

                    temp = allScores.Substring(0, allScores.IndexOf(','));
                    d = allScores.IndexOf(',') + 1;
                    l = allScores.Length - d;

                    allScores = allScores.Substring(d, l);
                    dto.score = int.Parse(temp);

                    temp = allScores.Substring(0, allScores.IndexOf(';'));
                    d = allScores.IndexOf(';') + 1;
                    l = allScores.Length - d;

                    allScores = allScores.Substring(d, l);
                    dto.scoretime = temp;

                    myList.Add(dto);
                    temp = "";
                }

                showScore(myList);
            }
            else
            {
                Debug.Log("No received data");
            }

        }
    }

    //score UI Text fields 
    GameObject rowObj = null; // line number
    GameObject nameObj = null; // player's name
    GameObject scoreObj = null; //player's score

    // Destroy created UI Text fields
    void detroyScoreObjects()
    {
        for (int i = 10; i > 0; i--)
        {
            Destroy(GameObject.Find("rowObj" + i));
            Destroy(GameObject.Find("nameObj" + i));
            Destroy(GameObject.Find("scoreObj" + i));
        }
    }

    //Show scores on the panel    
    private void showScore(List<ScoreService.Models.PlayerScoreDto2> myList)
    {

        int index = pageNumber - 9;

        // Generate the score board on runtime
        for (int i = 1; i < 11; i++)
        {
            //line numbers on the board
            //rowObj = Instantiate(textGenerate, new Vector3(-400, 150 - (i * 30), 0), new Quaternion(0, 0, 0, 0)) as GameObject;
            rowObj = Instantiate(textGenerate, new Vector3(-235, 150 - (i * 30), 0), new Quaternion(0, 0, 0, 0)) as GameObject;
            rowObj.transform.SetParent(parent.transform, false);
            if (i <= count && myList.Count > (index - 1))
            {
                rowObj.GetComponent<UnityEngine.UI.Text>().text = "" + index;
            }
            else
            {
                rowObj.GetComponent<UnityEngine.UI.Text>().text = "";
            }

            rowObj.GetComponent<UnityEngine.UI.Text>().alignment = TextAnchor.MiddleRight;
            rowObj.name = "rowObj" + i;

            //players' names
            //nameObj = Instantiate(textGenerate, new Vector3(-10, 150 - (i * 30), 0), new Quaternion(0, 0, 0, 0)) as GameObject;
            nameObj = Instantiate(textGenerate, new Vector3(130, 150 - (i * 30), 0), new Quaternion(0, 0, 0, 0)) as GameObject;
            nameObj.name = "nameObj" + i;
            nameObj.transform.SetParent(parent.transform, false);
            nameObj.GetComponent<UnityEngine.UI.Text>().rectTransform.sizeDelta = new Vector2(540, 40);
            nameObj.GetComponent<UnityEngine.UI.Text>().alignment = TextAnchor.MiddleLeft;
            if (i <= count && myList.Count > (index - 1))
            {
                nameObj.GetComponent<UnityEngine.UI.Text>().text = myList[index - 1].PlayerName.Trim(); // allScores.Trim();                                
            }
            else
            {
                nameObj.GetComponent<UnityEngine.UI.Text>().text = "";
            }

            //players' scores
            //scoreObj = Instantiate(textGenerate, new Vector3(200, 150 - (i * 30), 0), new Quaternion(0, 0, 0, 0)) as GameObject;
            scoreObj = Instantiate(textGenerate, new Vector3(36, 150 - (i * 30), 0), new Quaternion(0, 0, 0, 0)) as GameObject;
            scoreObj.name = "scoreObj" + i;
            scoreObj.transform.SetParent(parent.transform, false);
            if (i <= count && myList.Count > (index - 1))
            {
                scoreObj.GetComponent<UnityEngine.UI.Text>().text = "" + myList[index - 1].score;
                index += 1;
            }
            else
            {
                scoreObj.GetComponent<UnityEngine.UI.Text>().text = "";
            }

            scoreObj.GetComponent<UnityEngine.UI.Text>().alignment = TextAnchor.MiddleRight;

        }
    }

    //  Get total scores count  
    private int playersCount(string allScores)
    {
        char charToCount = ';';
        foreach (char c in allScores)
        {
            if (c == charToCount)
            {
                count++;
                //Teste
                if(count > scorerLimit)
                {
                    count = 1;
                }
                //Teste
            }
        }
        return count;
    }
}
