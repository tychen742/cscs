//
//  ViewController.m
//  DemoNative
//
//  Created by John O'Sullivan on 10/18/13.
//  Copyright (c) 2013 John O'Sullivan. All rights reserved.
//

#import "ViewController.h"
// begin-vc-header
#import "LoginController.h"
// end-vc-header
@interface ViewController ()

@end

@implementation ViewController

// begin-vc-viewDidLoad
- (void)viewDidLoad
{
    [super viewDidLoad];
	// Do any additional setup after loading the view, typically from a nib.
    
    groupone = [[NSArray alloc] initWithObjects:@"Row 0",@"Row 1",@"Row 2", nil];
    grouptwo = [[NSArray alloc] initWithObjects:@"Row 0",@"Row 1",@"Row 2", nil];
    groupthree = [[NSArray alloc] initWithObjects:@"Row 0",@"Row 1",@"Row 2", nil];
    
    [tableviewMe reloadData];
    
}
// end-vc-viewDidLoad

- (void)didReceiveMemoryWarning
{
    [super didReceiveMemoryWarning];
    // Dispose of any resources that can be recreated.
}
// begin-actnButtonClick-viewDidLoad
-(IBAction)actnButtonClick:(id)sender {
    // begin-action-viewDidLoad
    UIAlertView *alert = [[UIAlertView alloc] initWithTitle:@"alert title" message:@"Hello World!" delegate:self cancelButtonTitle:@"OK" otherButtonTitles:nil];
    [alert show];
    // end-action-viewDidLoad
    
}
// end-actnButtonClick-viewDidLoad

-(IBAction)actnButtonClick2:(id)sender {
    // begin-actnButtonClick2-viewDidLoad
    //Splits the data in the text field
    NSArray *lines = [btnClickMe.text componentsSeparatedByString:@" "];
    //Get the count and check homw many parts there are
    if (lines.count == 1) {
        
        UIAlertView *alert = [[UIAlertView alloc] initWithTitle:@"alert title" message:btnClickMe.text delegate:self cancelButtonTitle:@"OK" otherButtonTitles:nil];
        [alert show];
  
    } else {
       
        
        NSString *data = [NSString stringWithFormat:@"%@, %@",[lines objectAtIndex:1],[lines objectAtIndex:0]];
        
        UIAlertView *alert = [[UIAlertView alloc] initWithTitle:@"alert title" message:data delegate:self cancelButtonTitle:@"OK" otherButtonTitles:nil];
        [alert show];

    }
    // end-actnButtonClick2-viewDidLoad

}

// begin-dismissKeyBoard-viewDidLoad
-(IBAction)dismissKeyBoard:(id)sender {
    [btnClickMe resignFirstResponder];
    
}
// end-dismissKeyBoard-viewDidLoad

// begin-presentView-viewDidLoad
-(IBAction)presentView:(id)sender {
    
    LoginController *login = [[LoginController alloc] initWithNibName:@"LoginController" bundle:nil];
    [self presentViewController:login animated:YES completion:nil];
    
}
// end-presentView-viewDidLoad

// begin-numberOfSectionsInTableView-viewDidLoad
#pragma mark Table view methods

- (NSInteger)numberOfSectionsInTableView:(UITableView *)tableView {
    
	return 3;
}
// end-numberOfSectionsInTableView-viewDidLoad

// begin-numberOfRowsInSection-viewDidLoad
// Customize the number of rows in the table view.
- (NSInteger)tableView:(UITableView *)tableView numberOfRowsInSection:(NSInteger)section {
	
	switch (section) {
            //Attribute Section
        case 0:
            return [groupone count];
            break;
        case 1:
            return [groupone count];
            break;
        case 2:
            return [groupone count];
            break;
        default:
            break;
    }
    return 0;
    
}
// end-numberOfRowsInSection-viewDidLoad

// begin-titleForHeaderInSection-viewDidLoad
- (NSString *)tableView:(UITableView *)tableView titleForHeaderInSection:(NSInteger)section {
	
	switch (section) {
            //Attribute Section
        case 0:
            return @"Section 0 Header";
            break;
        case 1:
            return @"Section 1 Header";
            break;
        case 2:
            return @"Section 2 Header";
            break;
        default:
            break;
    }
    return 0;
}
// end-titleForHeaderInSection-viewDidLoad

// begin-titleForFooterInSection-viewDidLoad
- (NSString *)tableView:(UITableView *)tableView titleForFooterInSection:(NSInteger)section {
    switch (section) {
            //Attribute Section
        case 0:
            return @"Section 0 Footer";
            break;
        case 1:
            return @"Section 1 Footer";
            break;
        case 2:
            return @"Section 2 Footer";
            break;
        default:
            break;
    }
    return 0;
    
}
// end-titleForFooterInSection-viewDidLoad

// begin-cellForRowAtIndexPath-viewDidLoad
// Customize the appearance of table view cells.
- (UITableViewCell *)tableView:(UITableView *)tableView cellForRowAtIndexPath:(NSIndexPath *)indexPath {
    
    static NSString *CellIdentifier = @"TableCell";
    
    UITableViewCell *cell = [tableView dequeueReusableCellWithIdentifier:CellIdentifier];
    if (cell == nil) {
        cell = [[UITableViewCell alloc] initWithFrame:CGRectZero];
    }
    
    // Set up the cell...
	switch (indexPath.section) {
            //Attribute Section
        case 0:
            cell.textLabel.text = [groupone objectAtIndex:indexPath.row];
            break;
        case 1:
            cell.textLabel.text = [grouptwo objectAtIndex:indexPath.row];
            break;
        case 2:
            cell.textLabel.text = [groupthree objectAtIndex:indexPath.row];
            break;
        default:
            break;
    }
	
    return cell;
}
// end-cellForRowAtIndexPath-viewDidLoad

// begin-didSelectRowAtIndexPath-viewDidLoad
- (void)tableView:(UITableView *)tableView didSelectRowAtIndexPath:(NSIndexPath *)indexPath {
    UIAlertView *alert = [[UIAlertView alloc] initWithTitle:@"Row Selected" message:[NSString stringWithFormat:@"Row %i",indexPath.row] delegate:self cancelButtonTitle:@"OK" otherButtonTitles:nil];
    [alert show];
	
}
// end-didSelectRowAtIndexPath-viewDidLoad


-(void)viewWillAppear:(BOOL)animated {
    
}
-(void)viewWillDisappear:(BOOL)animated{
    
    
}
-(void)viewDidAppear:(BOOL)animated {
    

}
-(void)viewDidDisappear:(BOOL)animated{
    
    
}

@end
