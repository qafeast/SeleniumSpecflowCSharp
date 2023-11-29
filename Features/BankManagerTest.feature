Feature: BankManager

  @addcustomer
  Scenario: 1 - Adding new customer to the bank
    Given Login to bank manager account
    Then Navigate to add customer section
    Then Enter firstname as "<firstName>" lastname as "<lastName>" and postal code as "<postalCode>"
    When Click add customer button
    Then Customer "<firstName>" "<lastName>" should be added to the customer list

    Examples: 
      | firstName | lastName | postalCode |
      | Mick      | Tyson    |     111111 |
      | Peter     | Parker   |     222222 |
      | Steve     | Roger    |     333333 |

  @openacc
  Scenario: 2 - Opening a Account for new customer
    Given Login to bank manager account
    When Navigate to the open account section
    Then Select a customer name as "<firstName>" "<lastName>"
    And Select a currency "<currency>"
    When Click the process button
    Then The account should be added for the customer "<firstName>" "<lastName>"

    Examples: 
      | firstName | lastName | currency |
      | Mick      | Tyson    | Dollar   |
      | Peter     | Parker   | Pound    |
      | Steve     | Roger    | Rupee    |

  Scenario: 3 - Delete the newly added customers
    Given Login to bank manager account
    And Navigate to the customers section
    When Click the delete button of the user "<firstName>" "<lastName>"
    Then The user "<firstName>" "<lastName>" account should be deleted

    Examples: 
      | firstName | lastName | currency |
      | Mick      | Tyson    | Dollar   |
      | Peter     | Parker   | Pound    |
      | Steve     | Roger    | Rupee    |
