using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PrizeManager : MonoBehaviour
{
    public GameObject StartPanel, StorePanel, ScratchPanel, SpecialPanel,Panel,sur;
    public Text CoinText;
    public Text Timem;
    public int WinCoinText = 250, score;
    public bool Pres = false;
    int r, k,winp,j,h,or;
    public string p,m;
    public float timeLeft;
    public  DateTime RewardedDT;
    public int ff, currentDate;
    void Start()
    {
        CoinText.text = "1000";
        CoinText.text = PlayerPrefs.GetInt("k").ToString();
        
        Debug.Log(winp);
        InvokeRepeating("OpenedStartPanel", 2, 0.3F);
        StartPanel.SetActive(true);
        StorePanel.SetActive(false);
        ScratchPanel.SetActive(false);
        SpecialPanel.SetActive(false);
        //    int unixTime = (int)(DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalSeconds;
        //    TimeSpan interval = TimeSpan.FromMilliseconds(unixTime);
        //    string time = "h=" + interval.Hours.ToString() + " " + "m=" + interval.Minutes.ToString() + " " + "s=" + interval.Seconds.ToString() + " " + "ms=" + interval.Milliseconds.ToString();
        Pres = (PlayerPrefs.GetInt("Name") != 0);
        //Debug.Log(time + "unixTime");
        //PlayerPrefs.DeleteAll();
    }
  
    void OnMouseDown()
    {
        Debug.Log("sdddsssssssssss");
        ScratchPanel.SetActive(false);
        SpecialPanel.SetActive(false);
        StorePanel.SetActive(false);
    }
        public void OpenedStartPanel()
    {
        StartPanel.SetActive(false);
    }
    public void OpenedStorePanel()
    {
        StorePanel.SetActive(true);
        ScratchPanel.SetActive(false);
        SpecialPanel.SetActive(false);
    }
    public void OpenedSpecialPanel()
    {
        SpecialPanel.SetActive(true);
        ScratchPanel.SetActive(false);
        StorePanel.SetActive(false);
    }
    public void OpenedScratchPanel()
    {
        ScratchPanel.SetActive(true);
        SpecialPanel.SetActive(false);
        StorePanel.SetActive(false);
    }
    public void OpenedWeb()
    {
        Application.OpenURL("http://unity3d.com/");
    }
  
    public void DateSave()
    {
        DateTime RewardedDT = DateTime.Now.AddDays(1);

        PlayerPrefs.SetInt("RewardedYear", RewardedDT.Year);
        PlayerPrefs.SetInt("RewardedMonth", RewardedDT.Month);
        PlayerPrefs.SetInt("RewardedDay", RewardedDT.Day);
        PlayerPrefs.SetInt("RewardedHour", RewardedDT.Hour);
        PlayerPrefs.SetInt("RewardedMinute", RewardedDT.Minute);
        PlayerPrefs.SetInt("RewardedSecond", RewardedDT.Second);

    }
    public void lof()
    {
    }
    void Update()
    {
        if (Pres == true)
        {
            DateTime RewardedDT = new DateTime(PlayerPrefs.GetInt("RewardedYear", DateTime.Now.Year), PlayerPrefs.GetInt("RewardedMonth", DateTime.Now.Month), PlayerPrefs.GetInt("RewardedDay", DateTime.Now.Day),
            PlayerPrefs.GetInt("RewardedHour", DateTime.Now.Hour), PlayerPrefs.GetInt("RewardedMinute", DateTime.Now.Minute), PlayerPrefs.GetInt("RewardedSecond", DateTime.Now.Second));

            p = (RewardedDT - DateTime.Now).Hours.ToString()+":"+ (RewardedDT - DateTime.Now).Minutes.ToString() + ":" + (RewardedDT - DateTime.Now).Seconds.ToString();
            Timem.text = p;
            sur.SetActive(false);
            PlayerPrefs.SetInt("Name", (Pres ? 1 : 0));
        }
        if (p == "0:0:0")
        {
            sur.SetActive(true);
        }
    }
    public void WinCoin()
    {
        DateTime RewardedDT = new DateTime(PlayerPrefs.GetInt("RewardedYear", DateTime.Now.Year), PlayerPrefs.GetInt("RewardedMonth", DateTime.Now.Month), PlayerPrefs.GetInt("RewardedDay", DateTime.Now.Day),
        PlayerPrefs.GetInt("RewardedHour", DateTime.Now.Hour), PlayerPrefs.GetInt("RewardedMinute", DateTime.Now.Minute), PlayerPrefs.GetInt("RewardedSecond", DateTime.Now.Second));
        sur.SetActive(false);
        Pres= true;
        if (RewardedDT <= DateTime.Now && (DateTime.Now - RewardedDT).Days == 0)
            {
                    r = int.Parse(CoinText.text);
                    k = r + 250;
                    Debug.Log(k + "r");
                    CoinText.text = k.ToString();
                    PlayerPrefs.SetInt("k", k);
                    winp = 1;
            }
        else
            {
                Debug.Log("Nextday");
            }
        
    }
    public void CloseScratchPanel()
    {
        ScratchPanel.SetActive(false);
    }
    public void CloseSpecialPanel()
    {
        SpecialPanel.SetActive(false);
    }
    public void CloseStorePanel()
    {
        StorePanel.SetActive(false);
    }

}
