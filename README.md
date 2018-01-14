# BankScraper
Program web suite to parse financial transactions from brazilian bank and benefit accounts.


# C# Banckscraper
This program is a web page built in C #, Razor, Mono and Nuget.


**WARNING:** Using this tool without care may lead to your bank account being blocked. Use at your own risk!

## Current Supported Banks


| Name                                                                                                                                                                                          | Account informations | Customer informations          | Additional Info                                                                                       |           Method                     | Status |
| ---                                                                                                                                                                                           | ---     | ---                                   | ---                                                                                                   | ---                                  | ---    |
| [![Nubank](https://raw.githubusercontent.com/kamushadenes/bankscraper/master/bankscraper/logo/icon-nubank.png)](https://github.com/kamushadenes/bankscraper/blob/master/nubank.py)                    | yes      | yes                                     | Purchases, Bills Summamry, events                                                                       |    Web Scraping                                  | OK    |



## Add new banks

To add new banks you need to add in the change the list of banks in the BankScraper.cs class and create a new bank class. 
Check out template folser with example of how to use the software abstraction layer templates.


## Special Thanks

Based on the Python project from https://github.com/AndreCGusmao/bankscraper 
