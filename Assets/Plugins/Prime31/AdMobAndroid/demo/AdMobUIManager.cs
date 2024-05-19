using UnityEngine;
using System.Collections.Generic;
using Prime31;



namespace Prime31
{
	public class AdMobUIManager : MonoBehaviourGUI
	{
#if UNITY_ANDROID
		void OnGUI()
		{
			beginColumn();
	
	
			if( GUILayout.Button( "Set Test Devices" ) )
			{
				// replace with your test devices!
				AdMobAndroid.setTestDevices( new string[] { "6D13FA054BC989C5AC41900EE14B0C1B", "8E2F04DC5B964AFD3BC2D90396A9DA6E", "3BAB93112BBB08713B6D6D0A09EDABA1", "8476cbceede3ec3b4d5bddc0465b0c20" } );
			}
	
	
			if( GUILayout.Button( "Create Smart Banner" ) )
			{
				// place it on the top
				AdMobAndroid.createBanner( "ca-app-pub-8386987260001674/8398905145", AdMobAndroidAd.smartBanner, AdMobAdPlacement.BottomCenter );
			}
	
	
			if( GUILayout.Button( "Create 320x50 banner" ) )
			{
				// replace with your ad unit ID!
				AdMobAndroid.createBanner( "ca-app-pub-8386987260001674/8398905145", AdMobAndroidAd.phone320x50, AdMobAdPlacement.TopCenter );
			}
	
	
			if( GUILayout.Button( "Create 300x250 banner" ) )
			{
				// center it on the top
				AdMobAndroid.createBanner( "ca-app-pub-8386987260001674/8398905145", AdMobAndroidAd.tablet300x250, AdMobAdPlacement.BottomCenter );
			}
	
	
			if( GUILayout.Button( "Destroy Banner" ) )
			{
				AdMobAndroid.destroyBanner();
			}
	
	
			endColumn( true );
	
	
			if( GUILayout.Button( "Refresh Ad" ) )
			{
				AdMobAndroid.refreshAd();
			}
	
	
			if( GUILayout.Button( "Request Interstitial" ) )
			{
				// replace with your adUnitId!
				AdMobAndroid.requestInterstitial( "ca-app-pub-8386987260001674/9875638345" );
			}
	
	
			if( GUILayout.Button( "Is Interstitial Ready?" ) )
			{
				var isReady = AdMobAndroid.isInterstitialReady();
				Debug.Log( "is interstitial ready? " + isReady );
			}
	
	
			if( GUILayout.Button( "Display Interstitial" ) )
			{
				AdMobAndroid.displayInterstitial();
			}
	
	
			if( GUILayout.Button( "Hide Banner" ) )
			{
				AdMobAndroid.hideBanner( true );
			}
	
	
			if( GUILayout.Button( "Show Banner" ) )
			{
				AdMobAndroid.hideBanner( false );
			}


			GUILayout.Label( "Reward Based Ads" );
			if( GUILayout.Button( "Request Reward Based Ad" ) )
				AdMobAndroid.requestRewardBasedAd( "ca-app-pub-8386987260001674/8737488741" );


			if( GUILayout.Button( "Show Reward Based Ad" ) )
				AdMobAndroid.showRewardBasedAd();
	
			endColumn();
		}
#endif
	}

}
