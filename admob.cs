using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

using GoogleMobileAds.Api;

public class admob : MonoBehaviour
{
    private BannerView bannerView;
    void Start()
    {
        MobileAds.Initialize(initStatus => { });





        this.RequestBanner();
     
    }
        public void RequestBanner()
        {
#if UNITY_ANDROID
            string adUnitId = "ca-app-pub-5156621827786668/7065859858";
#elif UNITY_IPHONE
            string adUnitId = "ca-app-pub-3940256099942544/2934735716";
#else
            string adUnitId = "unexpected_platform";
#endif


         
            this.bannerView = new BannerView(adUnitId, AdSize.Banner, AdPosition.Top);

   
            AdRequest request = new AdRequest.Builder().Build();

            this.bannerView.LoadAd(request);

        }
    }

   


