using UnityEngine;
//using System.Collecstrong texttions;
using System.Xml;
using System;
using System.Collections;
using UnityEngine.UI;


public class WeatherScript : MonoBehaviour
{
	public GameObject nighttime;
	public GameObject daytime;
	public GameObject CloudLayerA;
	public GameObject CloudLayerB;
	public GameObject snow1;
    public GameObject rain1;
	public GameObject DarkCloudA;
	public GameObject DarkCloudB;
	public GameObject sun;
	//public Text tttt;

	private String city;
	private float temperature;
	private int humidity;
	private int cloud;
	private String precipitation;
	private int weather;

	private LocationInfo currentGPSPosition;
    
	IEnumerator Start()
	{
		if (!Input.location.isEnabledByUser)
			//tttt.text = "Unable1";

		Input.location.Start();
      
         int maxWait = 60;
        while (Input.location.status == LocationServiceStatus.Initializing )
        {
			//tttt.text = "Initializing...";
            yield return new WaitForSeconds(1);
            maxWait--;
           
        }
		if (maxWait < 1)
		{
			//tttt.text = "Timed out";
			//yield break;
		}

        if (Input.location.status == LocationServiceStatus.Failed)
        {
            //tttt.text = "Unable2";
            yield break;
        }
        else
        {
            //tttt.text = "hi";
            currentGPSPosition = Input.location.lastData;


            string url = "http://api.openweathermap.org/data/2.5/weather?APPID=af59d783a7612b58822e8b41d9af6314&lat=" + currentGPSPosition.latitude + "&lon=" + currentGPSPosition.longitude + "&mode=xml&units=metric&cnt=15";
			WWW www = new WWW(url);
            yield return www;
            if (www.error == null)
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(www.text); //www.data

                city = xmlDoc.SelectSingleNode("current/city/@name").InnerText;
                temperature = float.Parse(xmlDoc.SelectSingleNode("current/temperature/@value").InnerText);
                humidity = int.Parse(xmlDoc.SelectSingleNode("current/humidity /@value").InnerText);
                cloud = int.Parse(xmlDoc.SelectSingleNode("current/clouds/@value").InnerText);
				precipitation = xmlDoc.SelectSingleNode("current/precipitation/@mode").InnerText;
                weather = int.Parse(xmlDoc.SelectSingleNode("current/weather/@number").InnerText);
            }
        }
	}

	void Update()
	{
        
		setBackground();
		setCloud();
        setRain();
		setSnow();
	}

	void setBackground()
	{
		if(DateTime.Now.Hour.CompareTo(18)>=0 || DateTime.Now.Hour.CompareTo(5) < 0)
		{
			daytime.SetActive(false);
			nighttime.SetActive(true);
		} else {
			daytime.SetActive(true);
			nighttime.SetActive(false);

			if (weather == 800) {
				sun.SetActive(true);
			} else{
				sun.SetActive(false);
			}
		}
	}

	void setCloud()
	{
		if (cloud >= 20 && cloud < 50)
		{
			if (precipitation.Equals("no")) 
			{
				CloudLayerA.SetActive(false);
				CloudLayerB.SetActive(true);
				DarkCloudA.SetActive(false);
				DarkCloudB.SetActive(false);
			} else {
				CloudLayerA.SetActive(false);
				CloudLayerB.SetActive(false);
				DarkCloudA.SetActive(false);
				DarkCloudB.SetActive(true);
			}
		} else if (cloud >= 50)
		{
			if (precipitation.Equals("no")) {
				CloudLayerA.SetActive(true);
				CloudLayerB.SetActive(true);
				DarkCloudA.SetActive(false);
				DarkCloudB.SetActive(false);
			} else {
				CloudLayerA.SetActive(false);
				CloudLayerB.SetActive(false);
				DarkCloudA.SetActive(true);
				DarkCloudB.SetActive(true);
			}
		 } else{
			CloudLayerA.SetActive(false);
			CloudLayerB.SetActive(false);
			DarkCloudA.SetActive(false);
			DarkCloudB.SetActive(false);
		}					
	}

	void setRain()
	{
		if(precipitation.Equals("no"))
			rain1.SetActive (false);
		else
			rain1.SetActive (true);	
	}

	void setSnow()
	{
		if(weather==600||weather==601 || weather ==602 || weather ==611 
			|| weather ==612 || weather ==615 || weather ==616 || weather ==620 
			|| weather ==621 || weather == 622)
			snow1.SetActive(true);
		else
			snow1.SetActive(false);
	}
}