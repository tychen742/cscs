//
//  LoginController.m
//  DemoNative
//
//  Created by John O'Sullivan on 10/18/13.
//  Copyright (c) 2013 John O'Sullivan. All rights reserved.
//
// begin-login-import
#import "LoginController.h"
// end-login-import


// begin-login-LoginController
@interface LoginController ()

@end
// end-login-LoginController

// begin-login-implementation
@implementation LoginController

- (id)initWithNibName:(NSString *)nibNameOrNil bundle:(NSBundle *)nibBundleOrNil
{
    self = [super initWithNibName:nibNameOrNil bundle:nibBundleOrNil];
    if (self) {
        // Custom initialization
    }
    return self;
}
// end-login-implementation

// begin-login-viewDidLoad
- (void)viewDidLoad
{
    [super viewDidLoad];
    // Do any additional setup after loading the view from its nib.
}
// end-login-viewDidLoad

// begin-login-dismiss
-(IBAction)dismiss:(id)sender {
    
    [self dismissViewControllerAnimated:YES completion:nil];
}
// end-login-import

// begin-login-didReceiveMemoryWarning
- (void)didReceiveMemoryWarning
{
    [super didReceiveMemoryWarning];
    // Dispose of any resources that can be recreated.
}

@end
// end-login-didReceiveMemoryWarning
