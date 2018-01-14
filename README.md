# BankScraper
Program web suite to parse financial transactions from brazilian bank and benefit accounts.


# C# Bankscraper 

Program web suite to parse financial transactions from brazilian bank and benefit accounts, including support (when applicable) for interest fees and overdraft limits, besides account metadata and account holder information, when available

**WARNING:** Using this tool without care may lead to your bank account being blocked. Use at your own risk!

## Current Supported Banks

The banks below were added in the order they are listed


| Name                                                                                                                                                                                          | Balance | Transaction Backlog in Days           | Additional Info                                                                                       | Method                               | Status |
| ---                                                                                                                                                                                           | ---     | ---                                   | ---                                                                                                   | ---                                  | ---    |
| Nubank  | Yes     | 7, 15, 30, 60, 90                     | Account Segment, Account Type, Owner Name, Owner Document, Owner          | OK     |




## Add new banks

To add new banks you need to add in the change the list of banks in the BankScraper.cs class and create a new bank class. 
Check out the Template.cs class with example of how to use the software abstraction layer templates.

