using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

using GoogleMobileAds.Api;

public class Intertistial : MonoBehaviour
{
    private InterstitialAd interstitial;
 

    public void RequestInterstitial()

    {

#if UNITY_ANDROID
        string adUnitId = "ca-app-pub-5156621827786668/9871168350";




#elif UNITY_IPHONE
        string adUnitId = "ca-app-pub-3940256099942544/4411468910";
#else
        string adUnitId = "unexpected_platform";
#endif
        // Clean up interstitial ad before creating a new one.
        if (this.interstitial != null)
        {
            this.interstitial.Destroy();
            Debug.Log("destruyendo Intertistial");
        }

        // Initialize an InterstitialAd.
        this.interstitial = new InterstitialAd(adUnitId);







        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();
        // Load the interstitial with the request.
        this.interstitial.LoadAd(request);
        this.interstitial.OnAdLoaded += Interstitial_OnAdLoaded;



    }

    private void Interstitial_OnAdLoaded(object sender, EventArgs e)
    {

        this.interstitial.Show();
        Debug.Log("Cargando Intertistial");


    }
}
