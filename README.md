# Pierre's Bakery

#### Console app that allows user to input items and quantities to determine order price.

#### By Vanessa Su

## Description

This is a C# console application for determining the price of a bakery order. A welcome message and menu is initially displayed and the user is asked to type in an item they'd like to add to their order and the quantity they would like. If the inputs are valid the item and quantity are display and added to the order. Then the user is prompted to press N if they are done ordering, otherwise they can press any key to continue. If the user chooses to end their order the total cost is displayed along with a "Thank You" message.

## User Story

* See the menu of items available and their prices
* Enter in an item name to add
* Enter in the quantity of that item
* Enter Y to add a free item to order if prompted
* Enter any other key to decline adding the item
* Enter N to end order when prompted
* Enter any other key to add another item
* See the line items and order price total

## Technologies Used

* C#
* .NET 5.0
* MSTest
* VS Code

## Setup/Installation Requirements

### Prerequisites
* [.NET 5.0](https://dotnet.microsoft.com/)
* A text editor like [VS Code](https://code.visualstudio.com/)

### Installation
1. Clone the repository: `$ git clone https://github.com/vnessa-su/PierresBakery.Solution.git`
2. Navigate to the `PierresBakery.Solution` directory
3. Open with your preferred text editor to view the code base
* #### Run the Program
1. Navigate to the `PierresBakery.Solution/PierresBakery` directory
2. Run `$ dotnet restore`
3. Run `$ dotnet build`
4. Start the program with `$ dotnet run`
* #### Run the Tests
1. Navigate to the `PierresBakery.Solution/PierresBakery.Tests` directory
2. Run `$ dotnet restore`
4. Start the tests with `$ dotnet test`

## Known Bugs

_No known bugs_

## Contact Information

For any questions or comments, please reach out through GitHub.

## License

[MIT License](license)

Copyright (c) 2021 Vanessa Su