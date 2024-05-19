using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;



namespace Prime31
{
	public class AdMobAndroidEventListener : MonoBehaviour
	{
#if UNITY_ANDROID
		void OnEnable()
		{
			// Listen to all events for illustration purposes
			AdMobAndroidManager.dismissingScreenEvent += dismissingScreenEvent;
			AdMobAndroidManager.failedToReceiveAdEvent += failedToReceiveAdEvent;
			AdMobAndroidManager.leavingApplicationEvent += leavingApplicationEvent;
			AdMobAndroidManager.presentingScreenEvent += presentingScreenEvent;
			AdMobAndroidManager.receivedAdEvent += receivedAdEvent;
			AdMobAndroidManager.interstitialDismissingScreenEvent += interstitialDismissingScreenEvent;
			AdMobAndroidManager.interstitialFailedToReceiveAdEvent += interstitialFailedToReceiveAdEvent;
			AdMobAndroidManager.interstitialLeavingApplicationEvent += interstitialLeavingApplicationEvent;
			AdMobAndroidManager.interstitialPresentingScreenEvent += interstitialPresentingScreenEvent;
			AdMobAndroidManager.interstitialReceivedAdEvent += interstitialReceivedAdEvent;
			AdMobAndroidManager.rewardBasedAdReceivedEvent += rewardBasedAdReceivedEvent;
			AdMobAndroidManager.rewardBasedAdFailedEvent += rewardBasedAdFailedEvent;
			AdMobAndroidManager.rewardBasedAdRewardedUserEvent += rewardBasedAdRewardedUserEvent;
		}
	
	
		void OnDisable()
		{
			// Remove all event handlers
			AdMobAndroidManager.dismissingScreenEvent -= dismissingScreenEvent;
			AdMobAndroidManager.failedToReceiveAdEvent -= failedToReceiveAdEvent;
			AdMobAndroidManager.leavingApplicationEvent -= leavingApplicationEvent;
			AdMobAndroidManager.presentingScreenEvent -= presentingScreenEvent;
			AdMobAndroidManager.receivedAdEvent -= receivedAdEvent;
			AdMobAndroidManager.interstitialDismissingScreenEvent -= interstitialDismissingScreenEvent;
			AdMobAndroidManager.interstitialFailedToReceiveAdEvent -= interstitialFailedToReceiveAdEvent;
			AdMobAndroidManager.interstitialLeavingApplicationEvent -= interstitialLeavingApplicationEvent;
			AdMobAndroidManager.interstitialPresentingScreenEvent -= interstitialPresentingScreenEvent;
			AdMobAndroidManager.interstitialReceivedAdEvent -= interstitialReceivedAdEvent;
			AdMobAndroidManager.rewardBasedAdReceivedEvent -= rewardBasedAdReceivedEvent;
			AdMobAndroidManager.rewardBasedAdReceivedEvent -= rewardBasedAdReceivedEvent;
			AdMobAndroidManager.rewardBasedAdRewardedUserEvent -= rewardBasedAdRewardedUserEvent;
		}
	
	
	
		void dismissingScreenEvent()
		{
			Debug.Log( "dismissingScreenEvent" );
		}
	
	
		void failedToReceiveAdEvent( string error )
		{
			Debug.Log( "failedToReceiveAdEvent: " + error );
		}
	
	
		void leavingApplicationEvent()
		{
			Debug.Log( "leavingApplicationEvent" );
		}
	
	
		void presentingScreenEvent()
		{
			Debug.Log( "presentingScreenEvent" );
		}
	
	
		void receivedAdEvent()
		{
			Debug.Log( "receivedAdEvent" );
		}
	
	
		void interstitialDismissingScreenEvent()
		{
			Debug.Log( "interstitialDismissingScreenEvent" );
		}
	
	
		void interstitialFailedToReceiveAdEvent( string error )
		{
			Debug.Log( "interstitialFailedToReceiveAdEvent: " + error );
		}
	
	
		void interstitialLeavingApplicationEvent()
		{
			Debug.Log( "interstitialLeavingApplicationEvent" );
		}
	
	
		void interstitialPresentingScreenEvent()
		{
			Debug.Log( "interstitialPresentingScreenEvent" );
		}
	
	
		void interstitialReceivedAdEvent()
		{
			Debug.Log( "interstitialReceivedAdEvent" );
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
#endif
	}

}
	
	
