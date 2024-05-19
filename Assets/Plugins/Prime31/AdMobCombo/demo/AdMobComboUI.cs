using UnityEngine;
using System.Collections;
using Prime31;



namespace Prime31
{
	public class AdMobComboUI : MonoBehaviourGUI
	{
		bool _isBannerHidden;

#if UNITY_ANDROID || UNITY_IOS
		void OnGUI()
		{
			beginColumn();


			if( GUILayout.Button( "Set Test Devices" ) )
			{
				// replace with your device info!
				AdMob.setTestDevices( new string[] { "6D13FA054BC989C5AC41900EE14B0C1B", "8E2F04DC5B964AFD3BC2D90396A9DA6E", "3BAB93112BBB08713B6D6D0A09EDABA1", "079adeed23ef3e9a9ddf0f10c92b8e18", "E2236E5E84CD318D4AD96B62B6E0EE2B", "149c34313ce10e43812233aad0b9aa4d", "d1eb708cec2ca65c9f95458b22fbdc95", "1908bb1db3ae636e14cd6cc08cd5cb7a", "46a9f94837ce1fe8d8a6a8852c940875", "8476cbceede3ec3b4d5bddc0465b0c20" } );
			}


			if( GUILayout.Button( "Create Smart Banner" ) )
			{
				// place it on the top
				AdMob.createBanner( "ca-app-pub-8386987260001674/2631573141", "ca-app-pub-8386987260001674/8398905145", AdMobBanner.SmartBanner, AdMobLocation.BottomCenter );
			}


			if( GUILayout.Button( "Create 320x50 banner" ) )
			{
				// place it on the top
				AdMob.createBanner( "ca-app-pub-8386987260001674/2631573141", "ca-app-pub-8386987260001674/8398905145", AdMobBanner.Phone_320x50, AdMobLocation.TopCenter );
			}


			if( GUILayout.Button( "Create 300x250 banner" ) )
			{
				// center it on the top
				AdMob.createBanner( "ca-app-pub-8386987260001674/2631573141", "ca-app-pub-8386987260001674/8398905145", AdMobBanner.Tablet_300x250, AdMobLocation.BottomCenter );
			}


			if( GUILayout.Button( "Toggle Banner Visibility" ) )
			{
				_isBannerHidden = !_isBannerHidden;
				AdMob.hideBanner( _isBannerHidden );
			}


			if( GUILayout.Button( "Destroy Banner" ) )
			{
				AdMob.destroyBanner();
			}


			endColumn( true );

			GUILayout.Label( "Interstitials" );
			if( GUILayout.Button( "Request Interstitial" ) )
			{
				AdMob.requestInterstitial( "ca-app-pub-8386987260001674/9875638345", "ca-app-pub-8386987260001674/7061772743" );
			}


			if( GUILayout.Button( "Is Interstitial Ready?" ) )
			{
				var isReady = AdMob.isInterstitialReady();
				Debug.Log( "is interstitial ready? " + isReady );
			}


			if( GUILayout.Button( "Display Interstitial" ) )
			{
				AdMob.displayInterstitial();
			}


			GUILayout.Label( "Reward Based Ads" );
			if( GUILayout.Button( "Request Reward Based Ad" ) )
				AdMob.requestRewardBasedAd( "ca-app-pub-8386987260001674/1214221949", "ca-app-pub-8386987260001674/8737488741" );


			if( GUILayout.Button( "Show Reward Based Ad" ) )
				AdMob.showRewardBasedAd();

			endColumn();
		}



		#region Optional: Example of Subscribing to All Events

		void OnEnable()
		{
			AdMob.receivedAdEvent += receivedAdEvent;
			AdMob.failedToReceiveAdEvent += failedToReceiveAdEvent;
			AdMob.interstitialReceivedAdEvent += interstitialReceivedAdEvent;
			AdMob.interstitialFailedToReceiveAdEvent += interstitialFailedToReceiveAdEvent;
			AdMob.interstitialPresentingScreenEvent += interstitialPresentingScreenEvent;
			AdMob.interstitialDismissingScreenEvent += interstitialDismissingScreenEvent;
			AdMob.interstitialLeavingApplicationEvent += interstitialLeavingApplicationEvent;
			AdMob.rewardBasedAdReceivedEvent += rewardBasedAdReceivedEvent;
			AdMob.rewardBasedAdFailedEvent += rewardBasedAdFailedEvent;
			AdMob.rewardBasedAdRewardedUserEvent += rewardBasedAdRewardedUserEvent;
		}

		void OnDisable()
		{
			AdMob.receivedAdEvent -= receivedAdEvent;
			AdMob.failedToReceiveAdEvent -= failedToReceiveAdEvent;
			AdMob.interstitialReceivedAdEvent -= interstitialReceivedAdEvent;
			AdMob.interstitialFailedToReceiveAdEvent -= interstitialFailedToReceiveAdEvent;
			AdMob.interstitialPresentingScreenEvent -= interstitialPresentingScreenEvent;
			AdMob.interstitialDismissingScreenEvent -= interstitialDismissingScreenEvent;
			AdMob.interstitialLeavingApplicationEvent -= interstitialLeavingApplicationEvent;
			AdMob.rewardBasedAdReceivedEvent -= rewardBasedAdReceivedEvent;
			AdMob.rewardBasedAdFailedEvent -= rewardBasedAdFailedEvent;
			AdMob.rewardBasedAdRewardedUserEvent -= rewardBasedAdRewardedUserEvent;
		}


		void receivedAdEvent()
		{
			Debug.Log( "receivedAdEvent" );
		}


		void failedToReceiveAdEvent( string error )
		{
			Debug.Log( "failedToReceiveAdEvent: " + error );
		}


		void interstitialReceivedAdEvent()
		{
			Debug.Log( "interstitialReceivedAdEvent" );
		}


		void interstitialFailedToReceiveAdEvent( string error )
		{
			Debug.Log( "interstitialFailedToReceiveAdEvent: " + error );
		}


		void interstitialPresentingScreenEvent()
		{
			Debug.Log( "interstitialPresentingScreenEvent" );
		}


		void interstitialDismissingScreenEvent()
		{
			Debug.Log( "interstitialDismissingScreenEvent" );
		}


		void interstitialLeavingApplicationEvent()
		{
			Debug.Log( "interstitialLeavingApplicationEvent" );
		}


		void rewardBasedAdReceivedEvent()
		{
			Debug.Log( "rewardBasedAdReceivedEvent" );
		}


		void rewardBasedAdFailedEvent( string error )
		{
			Debug.Log( "rewardBasedAdFailedEvent: " + error );
		}


		void rewardBasedAdRewardedUserEvent( string type, float amount )
		{
			Debug.Log( "rewardBasedAdRewardedUserEvent. type: " + type + ", amount: " + amount );
		}

		#endregion

#endif
	}

}
