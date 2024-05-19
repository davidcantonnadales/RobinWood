using UnityEngine;
using System.Collections;
using System.Collections.Generic;



namespace Prime31
{
	public class StoreKitEventListener : MonoBehaviour
	{
#if UNITY_IOS || UNITY_TVOS
		void OnEnable()
		{
			// Listens to all the StoreKit events. All event listeners MUST be removed before this object is disposed!
			StoreKitManager.refreshReceiptSucceededEvent += refreshReceiptSucceededEvent;
			StoreKitManager.refreshReceiptFailedEvent += refreshReceiptFailedEvent;
			StoreKitManager.transactionUpdatedEvent += transactionUpdatedEvent;
			StoreKitManager.productPurchaseAwaitingConfirmationEvent += productPurchaseAwaitingConfirmationEvent;
			StoreKitManager.purchaseSuccessfulEvent += purchaseSuccessfulEvent;
			StoreKitManager.purchaseCancelledEvent += purchaseCancelledEvent;
			StoreKitManager.purchaseFailedEvent += purchaseFailedEvent;
			StoreKitManager.productListReceivedEvent += productListReceivedEvent;
			StoreKitManager.productListRequestFailedEvent += productListRequestFailedEvent;
			StoreKitManager.restoreTransactionsFailedEvent += restoreTransactionsFailedEvent;
			StoreKitManager.restoreTransactionsFinishedEvent += restoreTransactionsFinishedEvent;
			StoreKitManager.paymentQueueUpdatedDownloadsEvent += paymentQueueUpdatedDownloadsEvent;
		}


		void OnDisable()
		{
			// Remove all the event handlers
			StoreKitManager.refreshReceiptSucceededEvent -= refreshReceiptSucceededEvent;
			StoreKitManager.refreshReceiptFailedEvent -= refreshReceiptFailedEvent;
			StoreKitManager.transactionUpdatedEvent -= transactionUpdatedEvent;
			StoreKitManager.productPurchaseAwaitingConfirmationEvent -= productPurchaseAwaitingConfirmationEvent;
			StoreKitManager.purchaseSuccessfulEvent -= purchaseSuccessfulEvent;
			StoreKitManager.purchaseCancelledEvent -= purchaseCancelledEvent;
			StoreKitManager.purchaseFailedEvent -= purchaseFailedEvent;
			StoreKitManager.productListReceivedEvent -= productListReceivedEvent;
			StoreKitManager.productListRequestFailedEvent -= productListRequestFailedEvent;
			StoreKitManager.restoreTransactionsFailedEvent -= restoreTransactionsFailedEvent;
			StoreKitManager.restoreTransactionsFinishedEvent -= restoreTransactionsFinishedEvent;
			StoreKitManager.paymentQueueUpdatedDownloadsEvent -= paymentQueueUpdatedDownloadsEvent;
		}



		void refreshReceiptSucceededEvent()
		{
			Debug.Log( "refreshReceiptSucceededEvent" );
		}


		void refreshReceiptFailedEvent( string error )
		{
			Debug.Log( "refreshReceiptFailedEvent: " + error );
		}


		void transactionUpdatedEvent( StoreKitTransaction transaction )
		{
			Debug.Log( "transactionUpdatedEvent: " + transaction );
		}


		void productListReceivedEvent( List<StoreKitProduct> productList )
		{
			Debug.Log( "productListReceivedEvent. total products received: " + productList.Count );

			// print the products to the console
			foreach( StoreKitProduct product in productList )
				Debug.Log( product.ToString() + "\n" );
		}


		void productListRequestFailedEvent( string error )
		{
			Debug.Log( "productListRequestFailedEvent: " + error );
		}


		void purchaseFailedEvent( string error )
		{
			Debug.Log( "purchaseFailedEvent: " + error );
		}


		void purchaseCancelledEvent( string error )
		{
			Debug.Log( "purchaseCancelledEvent: " + error );
		}


		void productPurchaseAwaitingConfirmationEvent( StoreKitTransaction transaction )
		{
			Debug.Log( "productPurchaseAwaitingConfirmationEvent: " + transaction );
		}


		void purchaseSuccessfulEvent( StoreKitTransaction transaction )
		{
			Debug.Log( "purchaseSuccessfulEvent: " + transaction );
		}


		void restoreTransactionsFailedEvent( string error )
		{
			Debug.Log( "restoreTransactionsFailedEvent: " + error );
		}


		void restoreTransactionsFinishedEvent()
		{
			Debug.Log( "restoreTransactionsFinished" );
		}


		void paymentQueueUpdatedDownloadsEvent( List<StoreKitDownload> downloads )
		{
			Debug.Log( "paymentQueueUpdatedDownloadsEvent: " );
			foreach( var dl in downloads )
				Debug.Log( dl );
		}

#endif
	}

}

