using UnityEngine;
using System.Collections.Generic;
using Prime31;



namespace Prime31
{
	public class AdMobGUIManager : MonoBehaviourGUI
	{
#if UNITY_IOS

		void OnGUI()
		{
			beginColumn();


			if( GUILayout.Button( "Set Test Devices" ) )
			{
				// replace with your device info!
				AdMobBinding.setTestDevices( new string[] { "6D13FA054BC989C5AC41900EE14B0C1B", "8E2F04DC5B964AFD3BC2D90396A9DA6E", "3BAB93112BBB08713B6D6D0A09EDABA1", "079adeed23ef3e9a9ddf0f10c92b8e18", "E2236E5E84CD318D4AD96B62B6E0EE2B", "149c34313ce10e43812233aad0b9aa4d", "d1eb708cec2ca65c9f95458b22fbdc95", "1908bb1db3ae636e14cd6cc08cd5cb7a", "46a9f94837ce1fe8d8a6a8852c940875", "8476cbceede3ec3b4d5bddc0465b0c20" } );
			}


			if( GUILayout.Button( "Portrait Smart Banner (top right)" ) )
			{
				AdMobBinding.createBanner( "ca-app-pub-8386987260001674/2631573141", AdMobBannerType.SmartBannerPortrait, AdMobAdPosition.TopRight );
			}


			if( GUILayout.Button( "Landscape Smart Banner (bottom)" ) )
			{
				AdMobBinding.createBanner( "ca-app-pub-8386987260001674/2631573141", AdMobBannerType.SmartBannerLandscape, AdMobAdPosition.BottomCenter );
			}


			if( GUILayout.Button( "Custom Sized Banner (bottom)" ) )
			{
				AdMobBinding.createBanner( "ca-app-pub-8386987260001674/2631573141", 300, 200, AdMobAdPosition.BottomCenter );
			}


			GUILayout.Label( "iPhone Banners" );
			if( GUILayout.Button( "320x50 Banner (bottom right)" ) )
			{
				// replace the adUnitId with your own!
				AdMobBinding.createBanner( "ca-app-pub-8386987260001674/2631573141", AdMobBannerType.iPhone_320x50, AdMobAdPosition.BottomRight );
			}


			GUILayout.Label( "iPad Banners" );
			if( GUILayout.Button( "320x250 Banner (bottom)" ) )
			{
				// replace the adUnitId with your own!
				AdMobBinding.createBanner( "ca-app-pub-8386987260001674/2631573141", AdMobBannerType.iPad_320x250, AdMobAdPosition.BottomCenter );
			}


			if( GUILayout.Button( "468x60 Banner (top)" ) )
			{
				AdMobBinding.createBanner( "ca-app-pub-8386987260001674/2631573141", AdMobBannerType.iPad_468x60, AdMobAdPosition.TopCenter );
			}


			if( GUILayout.Button( "728x90 Banner (bottom)" ) )
			{
				AdMobBinding.createBanner( "ca-app-pub-8386987260001674/2631573141", AdMobBannerType.iPad_728x90, AdMobAdPosition.BottomCenter );
			}


			if( GUILayout.Button( "Destroy Banner" ) )
			{
				AdMobBinding.destroyBanner();
			}


			endColumn( true );


			GUILayout.Label( "Interstitials" );
			if( GUILayout.Button( "Request Interstitial" ) )
			{
				// replace the adUnitId with your own!
				AdMobBinding.requestInterstitial( "ca-app-pub-8386987260001674/7061772743" );
			}


			if( GUILayout.Button( "Is Interstial Loaded?" ) )
			{
				Debug.Log( "is interstitial loaded: " + AdMobBinding.isInterstitialAdReady() );
			}


			if( GUILayout.Button( "Show Interstitial" ) )
			{
				AdMobBinding.displayInterstitial();
			}


			GUILayout.Label( "Reward Based Ads" );
			if( GUILayout.Button( "Request Reward Based Ad" ) )
				AdMobBinding.requestRewardBasedAd( "ca-app-pub-8386987260001674/1214221949" );


			if( GUILayout.Button( "Show Reward Based Ad" ) )
				AdMobBinding.showRewardBasedAd();

			endColumn();
		}
#endif
	}

}
