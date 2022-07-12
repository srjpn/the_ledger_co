# Commands

## LOAN 
### Params

* BANK_NAME
* BORROWER_NAME
* PRINCIPAL
* NO_OF_YEARS
* RATE_OF_INTEREST

## PAYMENT
### Params

* BANK_NAME
* BORROWER_NAME
* LUMP_SUM_AMOUNT
* EMI_NO 


# Queries

## BALANCE
### Params
* BANK_NAME
* BORROWER_NAME
* EMI_NO



# Storage

* https://stackoverflow.com/questions/40484205/how-do-you-store-user-app-data-in-net-core-console-app

``` c#

var userDataPath = Path.Combine(AppContext.BaseDirectory, "userdata.json");

```

# Modals

Loan

``` c#
 {
   BankName: string,
   BorrowerName: string,
   Principal: int,
   NoOfYears: int,
   InterestRate: int
 }

 ```

Payment

``` c#
 {
   BankName: string,
   BorrowerName: string,
   Amount: int,
   emi: int
 }

 ```

 Balance 
 
 ``` c#
 {
   BankName: string,
   BorrowerName: string,
   emi: int
 }
 ```



 ROI of the loan changes every 6 months by the command
INTEREST_CHANGE IDIDI Dale 8

When this happens, the EMI needs to be adjusted so that the tenure is not affected. However BALANCE command should return the actual balance based on the ROI which was valid at that time of the EMI no
BALANCE IDIDI Dale 4 should give the balance based on the ROI for first 6 months

BALANCE IDIDI Dale 15 should give the balance based on the ROI after 12 months


120 -> 12 -> 10
6 -> 12


7 -> 10 for 6 + 12 


month 5 -> p * 10

month 7 -> p * 12
        6 * 10  => already paid
        remaining amount 