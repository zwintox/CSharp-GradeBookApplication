# C Sharp Grade Book Application

The C Sharp Grade Book Application is a designed to allow instructors to create gradebooks, add students to those grade books, add grades to those students, and calculate statics such as GPA.

-- Gif of working Application

## Accepted Commands

### Commands when no gradebooks are open
- "Create `Name of Gradebook` `Is this Gradebook Weighted (true/false)`" : Creates a new gradebook with the provided name
- "Help" : gives you a list of all valid commands within the given context
- "Load `Name of GradeBook`"
- "Quit" : Closes the application

### Commands when a gradebook is open
- "Add `Name of Student` `Type of Student` `Type of Enrollment`" : Adds a new student to the open gradebook
- "Remove `Name of Student`" : Removes a student with the provided name from the gradebook. (if a student with that name exists in the gradebook)
- "List" : Lists all students in the open gradebook
- "AddGrade `Name of Student` `Score`" : Adds to the given value to provided student's grades.
- "RemoveGrade `Name of Student` `Score`" : Removes the given value from the provided student's grade. (if that value exists in the stundent's grades)
- "Statistics all" : Provides statistical output for all students in the open gradebook
- "Statistics `Name of Student`" : Provides statistical out put for the provided student. (if that student exists)
- "Help" : Gives you a list of all valid commands within the given context
- "Save" : Saves the currently open gradebook
- "Close" : Closes the gradebook

# Setup the Application

## If you want to use Visual Studio
If you want to use Visual Studio (highly recommended for Windows users) follow the following steps:
-	If you already have Visual Studio installed make sure you have .Net Core installed by running the "Visual Studio Installer" and making sure ".NET Core cross-platform development" is checked
-	If you need to install visual studio download it at https://www.microsoft.com/net/core#windowsvs2017 On the workloads screen make sure ".NET Core cross-platform development" is checked
-	To run the application simply press the Start Debug button (green arrow) or press F5
-	To run the tests go to "Test" and select "Run All Tests" (you might need to goto "Test" > "Windows" > "Test Explorer" to display the results if you closed the test explorer.)

## If you don't plan to use Visual studio
If you would rather use something other than Visual Studio
-	Install the .Net Core SDK from https://www.microsoft.com/net/download/core once that installation completes you're ready to roll!
-	To run the application go into the GradeBook project folder and type `dotnet run`
-	To run the tests go into the GradeBookTests project folder and type `dotnet test /verbosity:quiet` (for OSX users use `dotnet test --verbosity:quiet` instead)

# Features you will impliment

- Add support for Ranked Grading
- Add support for Weighted GPAs

## Tasks necessary to complete implimentation:

__Note:__ this isn't the only way to accomplish this, however; this is what the project's tests are expecting. Implimenting this in a different way will likely result in being marked as incomplete / incorrect.

- [ ] Add support for Ranked Grading
	- [ ] Creating The `GradeBookType` Enum
		- [ ] Create a new Enum `GradeBookType`.
			- This should be located in the `Enums` directory.
			- This should use the `GradeBooks.Enums` namespace.
			- This should use the `public` access modifier.
			- This should contain the values `Standard`, `Ranked`, `ESNU`, `OneToFour`, and `SixPoint`.

	- [ ] Add `Type` property
		- [ ] Add a new property `Type` to `BaseGradeBook`
			- This should use the name `Type`.
			- This should be of type `GradeBookType`.
			- This should use the `public` access modifier.

	- [ ] Creating the `StandardGradeBook` class
		- [ ] Create a class `StandardGradeBook` _(Once this change is made code will not compile until completion of the next task)_
			- This should be located in the `GradeBooks` directory.
			- This should use the `GradeBook.GradeBooks` namespace.
			- This should inherit the `BaseGradeBook` class.
		- [ ] Create a constructor for `StandardGradeBook`
			- This should accept a parameter `name` of type `string`.
			- This should set `Type` to `GradeBookType.Standard`.
			- This should call the `BaseGradeBook` constructor by putting ` : base(name)` after the constructor declaration (this was not covered in the course, it calls the constructor of the inheritted class.)_

	- [ ] Creating the `RankedGradeBook` class
		-  [ ] Create a class `RankedGradeBook` _(Once this change is made code will not compile until completion of the next task)
			- This should be located in the `GradeBooks` directory.
			- This should use the `GradeBook.GradeBooks` namespace.
			- This should inherit the `BaseGradeBook` class.
		-  [ ] Create a constructor for `RankedGradeBook`
			- This should accept a parameter `name` of type `string`.
			- This should set `Type` to `GradeBookType.Ranked`.
			- This should call the `BaseGradeBook` constructor by putting ` : base(name)` after the constructor declaration _(this was not covered in the course, it calls the constructor of the inheritted class.)_

	- [ ] Add Multiple GradeBookType support to `BaseGradeBook`
		- [ ] Update `BaseGradeBook`'s `Load` method
			_(All code for this take will be written in place of the `Load` method's return statement)_
			- This should get the GradeBookType using `Enum.Parse(typeof(GradeBookType), jobject.GetValue("Type").ToString(), true);` _(this was not covered in the course, it will take the saved file and attempt to get the type of the gradebook from it)_
			- If the GradeBookType is `GradeBookType.Standard` create the gradebook using `JsonConvert.DeserializeObject<StandardGradeBook>(json);` _(this was also not covered in the course, it will take the saved file and create a `StandardGradeBook` object based on that file)_
			- If the GradeBookType is `GradeBookType.Ranked` create the gradebook using `JsonConvert.DeserializeObject<RankedGradeBook>(json);` _(this was also not covered in the course, it will take the saved file and create a RankedGradeBook object based on that file)_
			- If the GradeBookType is not yet handled throw an `InvalidOperationException` with message of "The gradebook you've attempted to load is not in a supported type of gradebook.";
			- return the created gradebook.

	- [ ] Override `RankedGradeBook`'s `GetLetterGrade` method
		- [ ] Provide the appropriate grades based on where input grade compares to other students.
			_(One way to solve this is to figure out how many students make up 20%, then loop through all the grades and check how many were more than the input average, every N students where N is that 20% value drop a letter grade.)_
			- If there are less than 5 students throw an `InvalidOperationException`.
			- return A if the input grade is in the top 20% of the class.
			- return B if the input grade is between the top 20 and 40% of the class.
			- return C if the input grade is between the top 40 and 60% of the class.
			- return D if the input grade is between the top 60 and 80% of the class.
			- return F if the grade is below the top 80% of the class.

	- [ ] Impliment an override of the  `RankedGradeBook`'s `CalculateStatistics` method.
		- [ ] This override will perform a check to make sure there are at least 5 students with grades
			- [ ] If there are not 5 students with grades display the message "Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade." then escape the method.
			- [ ] If there are 5 students with grades call the `CalculateStatistics` method using `base.CalculateStatistics`

	- [ ] Impliment an override of the  `RankedGradeBook`'s `CalculateStudentStatistics` method.
		- [ ] This override will perform a check to make sure there are at least 5 students with grades
			- [ ] If there are not 5 students with grades display the message "Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade." then escape the method.
			- [ ] If there are 5 students with grades call the base `CalculateStudentStatistics` method using `base.CalculateStudentStatistics`

	- [ ] In the `UserInterfaces` directory, Update the `StartingUserInterface` class to work with multiple types of grade books
		- [ ] Update the `CreateCommand` method to support multiple types.
			- [ ] Update the condition to check if the `parts.Length` is not 3.
			- [ ] Update the message written to console by this condition to say "Command not valid, Create requires a name and type of gradebook.".
			- [ ] Change where `gradeBook` is set to `BaseGradeBook` so it's of type `BaseGradeBook`, but don't instantiate it.
			- [ ] Create a new variable to store a string representing the gradebook type, this will be set using the second substring of the parts array.
				- [ ] When the value is "standard" set `gradeBook` to a newly instantiated `StandardGradeBook`.
				- [ ] When the value is "rank" set `gradeBook` to a newly instantiated `RankedGradeBook`.
				- [ ] When the value doesn't match any of the above write to `Console` what they entered " is not a supported type of gradebook, please try again", then escape the method.

	- [ ] Change where the "help" command outlines the "create" command to say "Create 'Name' 'Type' - Creates a new gradebook where 'Name' is the name of the gradebook and 'Type' is what type of grading it should use.".

	- [ ] In the GradeBooks directory, change `BaseGradeBook` into an abstract class
		- [ ] Add the `abstract` keyword to the `BaseGradeBook` declarition

- [ ] Add support for weighted GPAs *Note: Code will stop compiling once the constructor is updated until after changes are made in `Program.Main` are complete*
	- [ ] Add a property named 'IsWeighted' of type `bool` to `BaseGradeBook` located in the `GradeBooks` directory.
		- [ ] Create a new public property `IsWeighted` of type `bool` in `BaseGradeBook`
		- [ ] Change the `BaseGradeBook` constructor to accept a `bool` for the second parameter.
		- [ ] Set the `IsWeighted` property using the `bool` parameter.
		- [ ] Update the `RankedGradeBook` and `StandardGradeBook` constructors to also have the same `bool` parameter. (Don't forget to add the bool to base constructor call after the constructor declaration!)
		- [ ] Update the `BaseGradeBook.GetGPA` method to add 1 point to GPAs of `Honors` and `DuelEnrolled` students when `IsWeighted` is true.

	- [ ] Update `StartingUserInterface`, located in the `UserInterfaces` directory, to support `IsWeighted`
		- [ ] Update `CreateCommand` to accept a third value of `true` or `false` to set `IsWeighted` via the gradebook constructors.
		- [ ] Update the condition that checks the number of parts to check if the number of parts is not equal to 4.
		- [ ] Update the error message to also mention that is weighted is required as well.
		- [ ] Create a new variable to containing if or if not the gradebook should be weighted set by the last part of the command. *Hint: you should convert the provided `string` into a `bool`
		- [ ] Update both Gradebook Instantiations to use our new command value to set `IsWeighted`.

	- [ ] Change where the `HelpCommand` outlines the "create" command to say "Create 'Name' 'Type' 'Weighted' - Creates a new gradebook where 'Name' is the name of the gradebook, 'Type' is what type of grading it should use, and 'Weighted' is whether or not grades should be weighted (true or false).".

## What Now?

You've compeleted the tasks of this project, if you want to continue working on this project some next steps would be to add support for some of the other grading formats, set Save to run with Add/Removing students and grades, etc.

Otherwise now is a good time to continue on the C# path to expand your understanding of the C# programming language or start looking into the User Interface options of C# whether that's ASP.NET (web), XAML (applications), DirectX (Graphically intense applications), etc