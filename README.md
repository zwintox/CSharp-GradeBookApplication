# C Sharp Grade Book Application

The C Sharp Grade Book Application is a designed to allow instructors to create gradebooks, add students to those grade books, add grades to those students, and calculate statics such as GPA.

-- Gif of working Application

# Setup the Application

## If you want to use Visual Studio
If you want to use Visual Studio (highly recommend for Windows users) follow the following steps:
-	If you already have Visual Studio installed make sure you have .Net Core installed by running the "Visual Studio Installer" and making sure ".NET Core cross-platform development" is checked
-	If you need to install visual studio download it at https://www.microsoft.com/net/core#windowsvs2017 On the workloads screen make sure ".NET Core cross-platform development" is checked
-	To run the application simply press the Start Debug button (green arrow) or press F5
-	To run the tests go to "Test" and select "Run All Tests" (you might need to goto "Test" > "Windows" > "Test Explorer" to display the results if you closed the test explorer.)

## If you don't plan to use Visual studio
If you would rather use something other than Visual Studio (or are on OSX or Linux)
-	Install the .Net Core SDK from https://www.microsoft.com/net/download/core once that installation completes you're ready to roll!
-	To run the application go into the project folder and type `dotnet run`
-	To run the tests go into the project folder and type `dotnet test`

# Features you will impliment

- Add support for Ranked Grading

## Tasks necessary to complete implimentation:

__Note:__ this isn't the only way to accomplish this, however; this is what the project's tests are expecting. Implimenting this in a different way will likely result in being marked as incomplete / incorrect.

- [ ] Add support for Ranked Grading
	- [ ] Create an Enum `GradeBookType` containing the types of Gradebooks to be supported (Standard, Ranked, ESNU, OneToFour, SixPoint)
		- [ ] Create a new Enum `GradeBookType` containing the types Standard, Ranked, ENSU, OneToFour, and SixPoint.
		- [ ] Add a property `Type` to the `StandardGradeBook` of type `GradeBookType`.

	- [ ] Create a new abstract class `BaseGradeBook` to contain the common Gradebook functionality.
		- [ ] Create the abstract class `BaseGradeBook`
		- [ ] Copy all Properties from `StandardGradeBook` to the `BaseGradeBook`
		- [ ] Copy all methods from `StandardGradeBook` to the `BaseGradeBook`
		- [ ] Change the method `GetLetterGrade` to be an abstract method (don't forget to remove the implimentation of the abstract methods)
		- [ ] Change `GetGPA`, `CalculateStatistics`, and `CalculateStudentStatistics` to be a virtual methods.

	- [ ] Refactor the `StandardGradeBook` class to utilize our new `BaseGradeBook` class.
		- [ ] Setup the `StandardGradeBook` to inherit the `BaseGradeBook` class.
		- [ ] Remove all properties from `StandardGradeBook`
		- [ ] Remove all methods except `GetLetterGrade`
		- [ ] Change `GetLetterGrade` to be an override method
		- [ ] Change the constructor to set the `Type` property to `Standard` in the `StandardGradeBook` class

	- [ ] Create a new `RankedGradeBook` class utilizing our new `BaseGradeBook` class.
		- [ ] Create a new class `RankedGradeBook` that inherits the `BaseGradeBook` class.
		- [ ] Create a constructor that sets the `Type` property to `Ranked`
		- [ ] Impliment `GetLetterGrade`, in ranked grading students aren't scored based on their own individual performance, instead they are graded based on how they performed compared to the rest of their class.
			- [ ] To get an A a student must have an average score that is in the top 20% of their class.
			- [ ] To get a B a student must have an average score between the top 20 and 40% of their class.
			- [ ] To get a C a student must have an average score between the top 40 and 60% of their class.
			- [ ] To get a D a student must have an average score between the top 60 and 80% of their class.
			- [ ] If a student's average score is below the top 80% of their class they get an F.

		- [ ] Impliment an override of the `CalculateStatistics` method.
			- [ ] This override will perform a check to make sure there are at least 5 students with grades
				- [ ] If there are not 5 students with grades display the message "Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade." then escape the method using `return`.
				- [ ] If there are 5 students with grades call the `CalculateStatistics` method using `base.CalculateStatistics`

		- [ ] Impliment an override of the `CalculateStudentStatistics` method.
			- [ ] This override will perform a check to make sure there are at least 5 students with grades
				- [ ] If there are not 5 students with grades display the message "Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade." then escape the method using `return'.
				- [ ] If there are 5 students with grades call the base `CalculateStudentStatistics` method using `base.CalculateStudentStatistics`

- [ ] Add simple error handling to prevent problems with unexpected user input
	- [ ] Ensure proper number of strings are present in Add Command.
	- [ ] If the string doesn't match an existing type provide feedback and restart loop.