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
-	To run the application go into the GradeBook project folder and type `dotnet run`
-	To run the tests go into the GradeBookTests project folder and type `dotnet test`

# Features you will impliment

- Add support for Ranked Grading

## Tasks necessary to complete implimentation:

__Note:__ this isn't the only way to accomplish this, however; this is what the project's tests are expecting. Implimenting this in a different way will likely result in being marked as incomplete / incorrect.

- [ ] Add support for Ranked Grading
	- [ ] In the Enums directory, create a new Enum `GradeBookType` containing the types of Gradebooks to be supported (`Standard`, `Ranked`, `ESNU`, `OneToFour`, `SixPoint`)
		- [ ] Create a new Enum `GradeBookType` containing the types `Standard`, `Ranked`, `ENSU`, `OneToFour`, and `SixPoint`.
			- This should be located in the `Enums` directory.
			- This should use the `GradeBook.Enums` namespace.
		- [ ] Add a property named `Type` to `BaseGradeBook` of type `GradeBookType`.

	- [ ] In the GradeBooks directory, change `BaseGradeBook` into an abstract class
		- [ ] Add the `abstract` keyword to the `BaseGradeBook` declarition
		- [ ] Change `GetGPA`, `CalculateStatistics`, and `CalculateStudentStatistics` to be a virtual methods.

	- [ ] Create a new class `StandardGradeBook` to contain the Standard Gradebook functionality.
		- [ ] Create a class `StandardGradeBook` that inherits the `BaseGradeBook` class.
			- This should be located in the `GradeBooks` directory.
			- This should use the `GradeBook.GradeBooks` namespace.
		- [ ] Change the constructor to set the `Type` property to `Standard` in the `StandardGradeBook` class.

	- [ ] Create a new `RankedGradeBook` to contain the Ranked Gradebook functionality.
		- [ ] Create a new class `RankedGradeBook` that inherits the `BaseGradeBook` class.
			- This should be located in the `GradeBooks` directory.
			- This should use the `GradeBook.GradeBooks` namespace.
		- [ ] Create a constructor that sets the `Type` property to `Ranked`

	- [ ] Update the `BaseGradeBook` class's `Load` method to handle multiple types of Gradebooks
		- [ ] Create a variable inside the `Load` method to contain the gradebook.
		- [ ] Set a variable using `Enum.Parse(typeof(GradeBookType), jobject.GetValue("Type").ToString(), true);` to get the type of GradeBook being loaded _(this was not covered in the course, it will take the saved file, and attempt to get the type of the gradebook from it)_
		- [ ] When type is `GradeBookType.Standard` set the gradebook variable using `JsonConvert.DeserializeObject<StandardGradeBook>(json);` _(this was also not covered in the course, it will take the saved file and create a StandardGradeBook object based on that file)_
		- [ ] When type is `GradeBookType.Ranked` set the gradebook variable using `JsonConvert.DeserializeObject<RankedGradeBook>(json);` _(this was also not covered in the course, it will take the saved file and create a RankedGradeBook object based on that file)_
		- [ ] Change the return statement to return `gradebook`.

	- [ ] Impliment an override for the `RankedGradeBook`'s `GetLetterGrade` method, in ranked grading students aren't scored based on their own individual performance, instead they are graded based on how they performed compared to the rest of their class.
		- [ ] To get an A a student must have an average score that is in the top 20% of their class.
		- [ ] To get a B a student must have an average score between the top 20 and 40% of their class.
		- [ ] To get a C a student must have an average score between the top 40 and 60% of their class.
		- [ ] To get a D a student must have an average score between the top 60 and 80% of their class.
		- [ ] If a student's average score is below the top 80% of their class they get an F.

	- [ ] Impliment an override of the  `RankedGradeBook`'s `CalculateStatistics` method.
		- [ ] This override will perform a check to make sure there are at least 5 students with grades
			- [ ] If there are not 5 students with grades display the message "Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade." then escape the method.
			- [ ] If there are 5 students with grades call the `CalculateStatistics` method using `base.CalculateStatistics`

	- [ ] Impliment an override of the  `RankedGradeBook`'s `CalculateStudentStatistics` method.
		- [ ] This override will perform a check to make sure there are at least 5 students with grades
			- [ ] If there are not 5 students with grades display the message "Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade." then escape the method.
			- [ ] If there are 5 students with grades call the base `CalculateStudentStatistics` method using `base.CalculateStudentStatistics`

	- [ ] In the GradeBook project's root directory, Update the `Program` class to work with multiple types of grade books
		- [ ] Inside the `Main` method update the code within the `if` condution that checks to see if `command` starts with "create".
			- [ ] Update the validation to check the `parts.Length` is not 4.
			- [ ] Update the message written to console by this condition to say "Command not valid, Create requires a name, type, is it weighted.".
			- [ ] Remove where `gradeBook` is set to `BaseGradeBook`.
			- [ ] Create a new variable to store a string representing the gradebook type, this will be set using the second substring of the parts array.
			- [ ] Create a new switch / case block that checks the gradebook type variable
				- [ ] When the value is "standard" set `gradeBook` to a newly instantiated `StandardGradeBook`.
				- [ ] When the value is "rank" set `gradeBook` to a newly instantiated `RankedGradeBook`.
			- [ ] Change where the "help" command outlines the "create" command to say "Create 'Name' 'Type' 'Weighted' - Creates a new gradebook where 'Name' is the name of the gradebook, 'Type' is what type of grading it should use, and 'Weighted' is whether or not grades should be weighted (true or false).".