using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScratchCard : MonoBehaviour {

    [SerializeField]
    Image maskImage;

    [SerializeField]
    Sprite[] non_rewardSprites;
    [SerializeField]
    Sprite[] rewardSprites;

    [SerializeField]
    Image[] itemImages;

    int prizeValue = 0;

    bool rewardCollected = false;

    // Start is called before the first frame update
    void Start() {
        RandomizeItems();

        maskImage.sprite = ScratchManager._instance.foregrounds[Random.Range(0, ScratchManager._instance.foregrounds.Length)];
    }

    void RandomizeItems() {
        for (int i = 0; i < itemImages.Length; i++) {
            int r = Random.Range(0, rewardSprites.Length + non_rewardSprites.Length);

            if (r < non_rewardSprites.Length) {
                itemImages[i].sprite = non_rewardSprites[r];
            } else {
                itemImages[i].sprite = rewardSprites[r - non_rewardSprites.Length];
                prizeValue++;
            }
        }
    } 

    public void ShowRewards() {
        if (rewardCollected) return;

        rewardCollected = true;

        maskImage.enabled = false;
        ScratchManager._instance.winPanel.SetActive(true);

        CurrencyManager._instance.AddCoins(Mathf.Pow(10, 2 + prizeValue));
        ScratchManager._instance.priceText.text = "+" + CurrencyManager.GetSuffix((long)Mathf.Pow(10, 2 + prizeValue));
    }
}
