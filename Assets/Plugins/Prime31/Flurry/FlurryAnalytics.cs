using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Prime31;




#if UNITY_IOS
namespace Prime31
{
	public class FlurryAnalytics
	{
		[DllImport("__Internal")]
		private static extern void _flurryStartSession( string apiKey, bool enableCrashReporting );

		// Starts up your Flurry analytics session. Call at application startup and you can optionally enable crash reporting here.
		public static void startSession( string apiKey, bool enableCrashReporting = false )
		{
			if( Application.platform == RuntimePlatform.IPhonePlayer )
				_flurryStartSession( apiKey, enableCrashReporting );
		}


		[DllImport("__Internal")]
		private static extern void _flurrySetDebugLogEnabled( bool shouldEnable );

		// Enables or disables Flurry SDK debug logs
		public static void setDebugLogEnabled( bool shouldEnable )
		{
			if( Application.platform == RuntimePlatform.IPhonePlayer )
				_flurrySetDebugLogEnabled( shouldEnable );
		}


		[DllImport("__Internal")]
		private static extern void _flurrySetAppVersion( string appVersion );

		// Sets the app version for this build overriding the CFBundleVersion
		public static void setAppVersion( string appVersion )
		{
			if( Application.platform == RuntimePlatform.IPhonePlayer )
				_flurrySetAppVersion( appVersion );
		}


		[DllImport("__Internal")]
		private static extern void _flurryLogEvent( string eventName, bool isTimed );

		// Logs an event to Flurry. If isTimed is true, this will be a timed event and it should be paired with a call to endTimedEvent
		public static void logEvent( string eventName, bool isTimed )
		{
			if( Application.platform == RuntimePlatform.IPhonePlayer )
				_flurryLogEvent( eventName, isTimed );
		}
		
		
	    // Logs an event with optional key/value pairs that is optionally timed
	    public static void logEvent( string eventName, Dictionary<string,string> parameters )
	    {
	        logEventWithParameters( eventName, parameters, false );
	    }


		[DllImport("__Internal")]
		private static extern void _flurryLogEventWithParameters( string eventName, string parameters, bool isTimed );

		// Logs an event with optional key/value pairs
		public static void logEventWithParameters( string eventName, Dictionary<string,string> parameters, bool isTimed )
		{
			if( parameters == null )
				parameters = new Dictionary<string, string>();

			if( Application.platform == RuntimePlatform.IPhonePlayer )
				_flurryLogEventWithParameters( eventName, parameters.toJson(), isTimed );
		}


		[DllImport("__Internal")]
		private static extern void _flurryEndTimedEvent( string eventName, string parameters );

		// Ends a timed event that was previously started
		public static void endTimedEvent( string eventName )
		{
			endTimedEvent( eventName, new Dictionary<string,string>() );
		}

		public static void endTimedEvent( string eventName, Dictionary<string,string> parameters )
		{
			if( parameters == null )
				parameters = new Dictionary<string, string>();

			if( Application.platform == RuntimePlatform.IPhonePlayer )
				_flurryEndTimedEvent( eventName, parameters.toJson() );
		}


		[DllImport("__Internal")]
		private static extern void _flurrySetAge( int age );

		// Sets the users age
		public static void setAge( int age )
		{
			if( Application.platform == RuntimePlatform.IPhonePlayer )
				_flurrySetAge( age );
		}


		[DllImport("__Internal")]
		private static extern void _flurrySetGender( string gender );

		// Sets the users gender
		public static void setGender( string gender )
		{
			if( Application.platform == RuntimePlatform.IPhonePlayer )
				_flurrySetGender( gender );
		}


		[DllImport("__Internal")]
		private static extern void _flurrySetUserId( string userId );

		// Sets the users unique id
		public static void setUserId( string userId )
		{
			if( Application.platform == RuntimePlatform.IPhonePlayer )
				_flurrySetUserId( userId );
		}


		[DllImport("__Internal")]
		private static extern void _flurrySetSessionReportsOnCloseEnabled( bool sendSessionReportsOnClose );

		// Sets whether Flurry should upload session reports when your app closes
		public static void setSessionReportsOnCloseEnabled( bool sendSessionReportsOnClose )

		{
			if( Application.platform == RuntimePlatform.IPhonePlayer )
				_flurrySetSessionReportsOnCloseEnabled( sendSessionReportsOnClose );
		}


		[DllImport("__Internal")]
		private static extern void _flurrySetSessionReportsOnPauseEnabled( bool setSessionReportsOnPauseEnabled );

		// Sets whether Flurry should upload session reports when your app is paused
		public static void setSessionReportsOnPauseEnabled( bool setSessionReportsOnPauseEnabled )
		{
			if( Application.platform == RuntimePlatform.IPhonePlayer )
				_flurrySetSessionReportsOnPauseEnabled( setSessionReportsOnPauseEnabled );
		}
	}

}
#endif
