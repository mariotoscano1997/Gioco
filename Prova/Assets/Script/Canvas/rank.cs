using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public  class rank : MonoBehaviour
{
    public Transform container;
    public Transform entryTemp;
    public Button closeButton;
    private List<Transform> listTransform;
    //private Transform;
    // Start is called before the first frame update
    
    public void OnEnable(){
        print("mi risveglio");
        foreach (Transform child in container) {
            if(child.name=="entry(Clone)")
                GameObject.Destroy(child.gameObject);
        }
        updateTable();
    }
    public void OnDisable(){
        print("sono dentro al metodo");
       /* foreach (Transform child in container) {
            if(child.name=="entry(Clone)")
                GameObject.Destroy(child.gameObject);
        }*/
    
    }
    public void Start(){
        print("emh?");
        foreach (Transform child in container) {
            if(child.name=="entry(Clone)")
                GameObject.Destroy(child.gameObject);
        }
        updateTable();
    }
    private void close(){
        GameManager.getInstance().setShowRank(false);
        this.transform.parent.GetComponent<Canvas>().enabled=false;
    }
    public  void Show(){
        this.transform.parent.GetComponent<Canvas>().enabled=true;
    }
    private static void createJsonTableforFistTime(){
        HighScoreEntry[] entry= new HighScoreEntry[10];   
        entry[9]=new HighScoreEntry { score=200 ,name="AAA" };
        entry[8]=new HighScoreEntry { score=300 ,name="BBB" };
        entry[7]=new HighScoreEntry { score=400 ,name="CCC" };
        entry[6]=new HighScoreEntry { score=500 ,name="DDD" };
        entry[5]=new HighScoreEntry { score=600 ,name="EEE" };
        entry[4]=new HighScoreEntry { score=700 ,name="FFF" };
        entry[3]=new HighScoreEntry { score=800 ,name="GGG" };
        entry[2]=new HighScoreEntry { score=900 ,name="HHH" };
        entry[1]=new HighScoreEntry { score=1000 ,name="III" };
        entry[0]=new HighScoreEntry { score=1100 ,name="JJJ" };
        SortAndCancel(entry,10);
        string json = JsonHelper.ToJson<HighScoreEntry>(entry);
        PlayerPrefs.SetString("highScoreTable", json);
    }
    public void updateTable(){
        foreach (Transform child in container) {
            if(child.name=="entry(Clone)")
                GameObject.Destroy(child.gameObject);
        }
        entryTemp.gameObject.SetActive(false);
        string table= PlayerPrefs.GetString("highScoreTable","");
        HighScoreEntry[] entry;
        if(table==""){
            createJsonTableforFistTime(); 
            table=PlayerPrefs.GetString("highScoreTable","");           
        }
        entry=JsonHelper.FromJson<HighScoreEntry>(table);        
        listTransform= new List<Transform>();
        foreach(HighScoreEntry e in entry){
            createList(e, container,listTransform);
        }
        
        //HighScores highScores= new HighScores(){list=listScore};
        string json=JsonHelper.ToJson<HighScoreEntry>(entry);
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
    public static void addEntry(int score, string name){
        string json = PlayerPrefs.GetString("highScoreTable","");
        HighScoreEntry[] entry=new HighScoreEntry[11];
        HighScoreEntry[] saved_entry;
        if(json==""){
            createJsonTableforFistTime();
            json = PlayerPrefs.GetString("highScoreTable","");
        }
        saved_entry=JsonHelper.FromJson<HighScoreEntry>(json);
        for(int i =0; i<10; i++)
            entry[i]=saved_entry[i];
        entry[10]=new HighScoreEntry(){ name=name, score=score};
        SortAndCancel(entry,11);
        json= JsonHelper.ToJson<HighScoreEntry>(entry,10);
        PlayerPrefs.SetString("highScoreTable", json);

    }
    private static void SortAndCancel(HighScoreEntry[] entry, int dim){
            for(int i=0; i<dim-1; i++){
                for(int j=i+1; j<dim; j++){
                    if(entry[i].score<entry[j].score){
                        HighScoreEntry tmp=entry[i];
                        entry[i]=entry[j];
                        entry[j]=tmp;
                    }
                }
            }
            
    }

    [System.Serializable]
    private class HighScoreEntry{
        public int score;
        public string name;
    }
}
