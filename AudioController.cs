using UnityEngine;

public class AudioController : MonoBehaviour
{
	public Sprite on;
	public Sprite off;
	private SpriteRenderer spMis;
	
	void Awake ()
	{
        spMis = GetComponent<SpriteRenderer>();
		
		if (PlayerPrefs.GetInt("Mute",0) == 1)
		{
			AudioListener.volume = 0;
            spMis.sprite = off;
		}
		else
		{
			AudioListener.volume = 1;
            spMis.sprite = on;
		}
	}
	
	void OnMouseDown()
	{
		transform.localScale = new Vector3(0.6f,0.6f,1);
	}
	
	void OnMouseUp()
	{
		transform.localScale = new Vector3(0.9f,0.9f,1);
		
		if (PlayerPrefs.GetInt("Mute",0) == 0)
		{
			AudioListener.volume = 0;
			PlayerPrefs.SetInt("Mute",1);
            spMis.sprite = off;
		}
		else
		{
			AudioListener.volume = 1;
			PlayerPrefs.SetInt("Mute",0);
            spMis.sprite = on;
		}
		
		PlayerPrefs.Save();
	}
}
