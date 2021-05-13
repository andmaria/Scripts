using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Column : MonoBehaviour {
    public float delayTwoSpawn = 0.06f;
    float offsetX = 0.75f;

    public bool isReady;
    public SlotItem currentItem;

    [SerializeField]
    int id;

    int itemNum;

    // Start is called before the first frame update
    void Start() {
        var item = Instantiate(SlotMachine._instance.GenerateRandomSlotItem().gameObject, transform);
        item.transform.position = new Vector3(transform.position.x, offsetX, 0);
    }

    // Update is called once per frame
    void Update() {

    }

    public void Spin() {
       
        transform.position += Vector3.down * transform.position.y;

        foreach (SlotItem s in GetComponentsInChildren<SlotItem>())
            Destroy(s.gameObject);

        StartCoroutine(GenerateItems());

        StartCoroutine(SpinAnim());
    }

    IEnumerator GenerateItems() {
        itemNum = Random.Range(17, 20) + id * 3;

        while (itemNum > 1) {
            itemNum--;
            var item = Instantiate(SlotMachine._instance.GenerateRandomSlotItem().gameObject, transform);
            item.transform.position = new Vector3(transform.position.x, 1.5f + offsetX, 0);

            yield return new WaitForSeconds(delayTwoSpawn);
        }

        yield return new WaitForSeconds(delayTwoSpawn * 1.5f);

        var g = Instantiate(currentItem.gameObject, transform);
        g.transform.position = new Vector3(transform.position.x, 1.5f + offsetX, 0);

        currentItem = g.GetComponent<SlotItem>();
    }

    IEnumerator SpinAnim() {
        float t = 0;
        int n = itemNum + 3;

        while (t < n * delayTwoSpawn) {
            t += Time.deltaTime;
            transform.position = Vector3.Lerp(new Vector3(transform.position.x, 0, 0), new Vector3(transform.position.x, -1.9f * n, 0), t / (n * delayTwoSpawn));
            yield return null;
        }
        t = 0;
        while (t < .3f) {
            t += Time.deltaTime;
            currentItem.transform.position = Vector3.Lerp(new Vector3(transform.position.x, 1.8f, 0), new Vector3(transform.position.x, offsetX, 0), t / .3f);
            yield return null;
        }
        if (id == 2) {
            SlotMachine._instance.CheckResult();
        }
    }
}
