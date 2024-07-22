//
//  ViewController.h
//  DemoNative
//
//  Created by John O'Sullivan on 10/18/13.
//  Copyright (c) 2013 John O'Sullivan. All rights reserved.
//
// begin-vc-interface
#import <UIKit/UIKit.h>

@interface ViewController : UIViewController <UITableViewDataSource,UITableViewDelegate> {
    
    IBOutlet UITableView *tableviewMe;
    
    IBOutlet UITextField *btnClickMe;
    
    NSArray *groupone;
    NSArray *grouptwo;
    NSArray *groupthree;

}
-(IBAction)actnButtonClick:(id)sender;
-(IBAction)actnButtonClick2:(id)sender;
-(IBAction)dismissKeyBoard:(id)sender;
-(IBAction)presentView:(id)sender;


@end
// end-vc-interface
