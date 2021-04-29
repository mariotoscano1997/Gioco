using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class rank : MonoBehaviour
{
    public Transform container;
    public Transform entryTemp;
    public Button closeButton;
    private List<HighScoreEntry> listScore;
    private List<Transform> listTransform;
    //private Transform;
    // Start is called before the first frame update
    public void Start(){
        this.transform.parent.GetComponent<Canvas>().enabled=false;
        closeButton.GetComponent<Button>().onClick.AddListener(close);
        print("si è spento?");
    }
    private void close(){
        GameManager.getInstance().setShowRank(false);
        this.transform.parent.GetComponent<Canvas>().enabled=false;
    }
    public  void Show(){
        this.transform.parent.GetComponent<Canvas>().enabled=true;
    }
    public void Update(){
        if(GameManager.getInstance().getShowRank()) Show();
    }
    private void Awake()
    {   
        entryTemp.gameObject.SetActive(false);
        /*
        listScore= new List<HighScoreEntry>(){
            new HighScoreEntry { score=200 ,name="AAA" },
            new HighScoreEntry { score=300 ,name="BBB" },
            new HighScoreEntry { score=400 ,name="CCC" },
            new HighScoreEntry { score=500 ,name="DDD" },
            new HighScoreEntry { score=600 ,name="EEE" },
            new HighScoreEntry { score=700 ,name="FFF" },
            new HighScoreEntry { score=800 ,name="GGG" },
            new HighScoreEntry { score=900 ,name="HHH" },
            new HighScoreEntry { score=1000 ,name="III" },
            new HighScoreEntry { score=1100 ,name="JJJ" },
        };*/
        //addEntry(654,"Filippo");
        string table= PlayerPrefs.GetString("highScoreTable");
        HighScores highScores= JsonUtility.FromJson<HighScores>(table);
        highScores.SortAndCancel();
        listTransform= new List<Transform>();
        foreach(HighScoreEntry entry in highScores.list){
            createList(entry, container,listTransform);
        }
        
        //HighScores highScores= new HighScores(){list=listScore};
        string json=JsonUtility.ToJson(highScores);
        PlayerPrefs.SetString("highScoreTable", json);
    }
    private void createList(HighScoreEntry entry, Transform container, List<Transform> transformList){
        Transform entryTransform= Instantiate(entryTemp, container);
        RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
        float templateHeight=50f;
        entryRectTransform.anchoredPosition= new Vector2(0, -templateHeight*transformList.Count);
        entryTransform.gameObject.SetActive(true);
        entryTransform.Find("score").GetComponent<Text>().text=entry.score.ToString();
        entryTransform.Find("name").GetComponent<Text>().text=entry.name.ToString();
        int pos= transformList.Count+1;
        string posLabelText;
        switch(pos){
            case 1: posLabelText="1st"; break;
            case 2: posLabelText="2nd"; break;
            case 3: posLabelText="3rd"; break;
            default: posLabelText=pos+"th"; break;
        }
        entryTransform.Find("pos").GetComponent<Text>().text=posLabelText;
        transformList.Add(entryTransform);                
    }
    private void addEntry(int score, string name){
        HighScoreEntry entry = new HighScoreEntry(){ name=name, score=score};
        string json = PlayerPrefs.GetString("highScoreTable");
        HighScores highScores= JsonUtility.FromJson<HighScores>(json);

        highScores.list.Add(entry);
        highScores.SortAndCancel();

        json=JsonUtility.ToJson(highScores);
        PlayerPrefs.SetString("highScoreTable", json);

    }
    private class HighScores{
        public List<HighScoreEntry> list;
        public void SortAndCancel(){
            for(int i=0; i<list.Count-1; i++){
                for(int j=i+1; j<list.Count; j++){
                    if(list[i].score<list[j].score){
                        HighScoreEntry tmp=list[i];
                        list[i]=list[j];
                        list[j]=tmp;
                    }
                }
            }
            if(list.Count==11)
                list.RemoveAt(10);
        }
    }
    [System.Serializable]
    private class HighScoreEntry{
        public int score;
        public string name;
    }
}
