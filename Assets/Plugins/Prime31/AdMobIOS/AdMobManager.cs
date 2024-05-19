using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using Prime31;



namespace Prime31
{
	public class AdMobManager : AbstractManager
	{
#if UNITY_IOS
		// Fired when the ad view receives an ad
		public static event Action receivedAdEvent;
		
		// Fired when the ad view fails to receive an ad
		public static event Action<string> failedToReceiveAdEvent;
		
		// Fired when an interstitial is ready to show
		public static event Action interstitialReceivedAdEvent;
		
		// Fired when the interstitial download fails
		public static event Action<string> interstitialFailedToReceiveAdEvent;

		// Fired when an interstitial is presented
		public static event Action interstitialPresentingScreenEvent;

		// Fired when an interstitial is dismissed
		public static event Action interstitialDismissingScreenEvent;

		// Fired when a user action on an interstitial causes them to leave your game
		public static event Action interstitialLeavingApplicationEvent;

		// Fired when an reward based ad is ready to show
		public static event Action rewardBasedAdReceivedEvent;
		
		// Fired when the reward based ad download fails
		public static event Action<string> rewardBasedAdFailedEvent;

		// Fired when a reward based ad is complete and a reward was received. Includes the type (string) and amount (float)
		public static event Action<string,float> rewardBasedAdRewardedUserEvent;

	
		static AdMobManager()
		{
			AbstractManager.initialize( typeof( AdMobManager ) );
		}
	
	
		void adViewDidReceiveAd( string empty )
		{
			if( receivedAdEvent != null )
				receivedAdEvent();
		}
	
	
		void adViewFailedToReceiveAd( string error )
		{
			if( failedToReceiveAdEvent != null )
				failedToReceiveAdEvent( error );
		}
	
	
		void interstitialDidReceiveAd( string empty )
		{
			if( interstitialReceivedAdEvent != null )
				interstitialReceivedAdEvent();
		}
	
	
		void interstitialFailedToReceiveAd( string error )
		{
			if( interstitialFailedToReceiveAdEvent != null )
				interstitialFailedToReceiveAdEvent( error );
		}


		void interstitialWillPresentScreen( string empty )
		{
			interstitialPresentingScreenEvent.fire();
		}


		void interstitialDidDismissScreen( string empty )
		{
			interstitialDismissingScreenEvent.fire();
		}


		void interstitialWillLeaveApplication( string empty )
		{
			interstitialLeavingApplicationEvent.fire();
		}


		void rewardBasedAdDidReceiveAd( string empty )
		{
			if( rewardBasedAdReceivedEvent != null )
				rewardBasedAdReceivedEvent();
		}


		void rewardBasedAdFailedToReceiveAd( string error )
		{
			if( rewardBasedAdFailedEvent != null )
				rewardBasedAdFailedEvent( error );
		}


		void rewardBasedAdRewardedUser( string data )
		{
			if( rewardBasedAdRewardedUserEvent != null )
			{
				var parts = data.Split( new char[] { '|' } );
				if( parts.Length == 2 )
					rewardBasedAdRewardedUserEvent( parts[0], float.Parse( parts[1] ) );
				else
					Debug.LogError( "invalid data from reward received: " + data );
			}
		}
		
#endif
	}

}
	
