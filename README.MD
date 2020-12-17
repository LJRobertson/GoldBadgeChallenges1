# GoldBadgeChallenges

The objective in the Gold Badge Challenges for Eleven Fifty Academy was to make three separate applications for the fictional Komodo Insurance Company. 

## Installation
To install, please clone or download the repository from  [GitHub](https://https://github.com/LJRobertson/GoldBadgeChallenges).


## Usage

Open the repository in Visual Studio Community. 

### Challenge One – Café Console App

Set 01_Challenge1CafeConsoleApp as the startup project and run the program. Upon running the application, a menu containing four options will be presented. The options are: View All Menu Items, Add New Menu Item, Delete a Menu Item, Exit Application. Enter the corresponding number on the menu to access the displayed option. 

View All Menu Items will display the current menu items. Each item includes a meal number, name, description, ingredient list, and price. Add New Menu Item will add a new item to the menu. Follow the prompts to assign the meal number, name, description, ingredient list, and price. A comma must separate each ingredient. The price needs to be entered in a 0.00 format. The application will add the currency symbol for you. Delete a Menu Item will bring up an abbreviated list of items currently on the menu. Enter the meal number for the menu item to be deleted. Exit Application will close out of the application.

### Challenge Two – Claims Console App

Set 02_Challenge2ClaimsConsoleApp as the startup project and run the program. Upon running the application, a menu will display with four options: View All Claims, Process Next Claim, Enter a New Claim, and Exit Application. Enter the corresponding number on the menu to access the displayed option.

View All Claims will display the claims currently in the queue. Each claim will display the claim ID number, the type of claim,  description, amount of the claim, date of the incident, date of the claim, and a true/false indicator for Komodo’s validity policy. If the date of the claim was more than 30 days from the date of incident, the application will mark the “IsValid” option as false. 

The Process Next Claim option allows the user to view the details of the first claim in the queue. The user will have the option to process the claim or not. If “Y” is entered to process the claim, the claim will be removed from the queue and will no longer show in the application. If “N” is entered, the claim will remain in the queue and the user will be returned to the main menu.

The Add a New Claim option will walk a user through entering all of the information needed for a new claim. The format for the claim amount is 0.00. The application will add the currency symbol. The format for the date of the incident is MM/DD/YYYY. 

The Exit Application will close out of the application.

### Challenge Three – Badge Door Access Console App

Set 03_Challenge3BadgesConsoleApp as the startup project and run the program. Upon running the application, a menu will display with four options: View All Badges and Door Access, Create a New Badge, Update Door Access on a Badge, and Exit Application. Enter the corresponding number on the menu to access the displayed option.

View All Badges and Door Access will display each badge’s ID number and the corresponding doors that the badge may access. Create a New Badge will prompt for an ID number for the new badge, then ask for the doors the badge will need access to. Each door must be separated by a comma.

Update Door Access on a Badge will bring up a new menu with two options: Assign Doors to a Badge and Remove Doors from a Badge. Enter the corresponding number to access the displayed option. Assigning Doors to a Badge will bring up the option to Assign All New Doors to a Badge or Add a New Door to a Badge. Each door entered here must be separated by a comma. Assign All New Doors to a Badge will assign only the doors entered her to the selected badge. Add a new Door to a Badge will allow additional doors to be added to a badge while retaining access to all doors currently on the badge. When prompted for the doors to add, each door must be separated by a comma.

Remove Doors from a Badge will bring up a menu with two options: Remove All Doors from a Badge and Remove Selected Doors from a Badge. Remove All Doors from a Badge will delete all doors from the entered badge number. Remove Selected Doors from a Badge will prompt for the Badge ID number to be edited and will then display a list of doors the badge currently has access to. Enter a door number to remove it from the badge. Multiple doors must be separated by a comma.

The Exit Application on the main menu will close out of the application.


## Contributing
Sole author Lindsey Robertson

## License
[MIT](https://github.com/LJRobertson/GoldBadgeChallenges/blob/main/license.MD)