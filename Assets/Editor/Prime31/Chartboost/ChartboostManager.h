//
//  ChartBoostManager.h
//  CB
//
//  Created by Mike DeSaro on 12/20/11.
//


#import <Foundation/Foundation.h>
#include <Chartboost/Chartboost.h>



@interface ChartboostManager : NSObject <ChartboostDelegate>

+ (ChartboostManager*)sharedManager;

@end
