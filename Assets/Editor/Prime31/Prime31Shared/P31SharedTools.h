//
//  P31SharedTools.h
//  P31SharedTools
//
//  Created by Mike Desaro on 8/10/13.
//  Copyright (c) 2013 prime31. All rights reserved.
//


#if TARGET_OS_IPHONE || TARGET_OS_TV
#import <UIKit/UIKit.h>
#endif


@interface P31 : NSObject

+ (BOOL)isValidJsonObject:(NSObject*)object;

+ (NSString*)jsonStringFromObject:(NSObject*)object;

+ (NSObject*)objectFromJsonString:(NSString*)json;

+ (const char *)jsonFromError:(NSError*)error;

+ (void)unityPause:(BOOL)shouldPause;

#if TARGET_OS_IPHONE || TARGET_OS_TV
+ (UIViewController*)unityViewController;
#endif

@end
