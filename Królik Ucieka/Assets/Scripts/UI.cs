using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class UI : MonoBehaviour
{
    GameObject player;
    float startPos;
    float lastPos;
    float distPerPkt = 10f;
    [SerializeField] TextMeshProUGUI textPkt = null;
    int maxPkt = 100;
    MainMenu mainMenu;
    public Button quicOptions;
    public GameObject[] live;
    public GameObject[] lightLive;

    private void Start()
    {
        player = FindObjectOfType<GameMenager>().player;
        startPos = gameObject.transform.position.x;
        lastPos = startPos;
        mainMenu = FindObjectOfType<MainMenu>();
        quicOptions.onClick.AddListener(mainMenu.QuickOptions);
    }

    private void Update()
    {
        ToPkt();
    }

    void ToPkt()
    {
        if(player.transform.position.x-lastPos >= distPerPkt)
        {
            int pkt = (int)((player.transform.position.x - startPos) / distPerPkt);

            if (pkt < 10) textPkt.text = "00" + pkt.ToString() + " : " + maxPkt.ToString();
            if (pkt >= 10 && pkt < 100) textPkt.text = "0" + pkt.ToString() + " : " + maxPkt.ToString();
            if (pkt >= 100) textPkt.text = pkt + " : " + maxPkt.ToString();
            lastPos = player.transform.position.x;

            if (pkt >= maxPkt)
                FindObjectOfType<GameMenager>().Win();
        }
    }
    public void SetLiveUI(int l)
    {
        if(l == 3)
        {
            live[0].SetActive(true);
            live[1].SetActive(true);
            live[2].SetActive(true);
            lightLive[0].SetActive(true);
            lightLive[1].SetActive(true);
            lightLive[2].SetActive(true);
        }
        else if (l == 2)
        {
            live[0].SetActive(true);
            live[1].SetActive(true);
            live[2].SetActive(false);
            lightLive[0].SetActive(true);
            lightLive[1].SetActive(true);
            lightLive[2].SetActive(false);
        }
        else if (l == 1)
        {
            live[0].SetActive(true);
            live[1].SetActive(false);
            live[2].SetActive(false);
            lightLive[0].SetActive(true);
            lightLive[1].SetActive(false);
            lightLive[2].SetActive(false);
        }
        else
        {
            live[0].SetActive(false);
            live[1].SetActive(false);
            live[2].SetActive(false);
            lightLive[0].SetActive(false);
            lightLive[1].SetActive(false);
            lightLive[2].SetActive(false);
        }
    }
}
