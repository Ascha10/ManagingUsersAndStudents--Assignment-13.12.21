using ManagingUsersAndStudents;

List<User> usersList = new List<User>();



void MenuOptions()
{
    Console.WriteLine("Please Select The Options");
    Console.WriteLine("1. Add User");
    Console.WriteLine("2. Edit User");
    Console.WriteLine("3. Delete User");
    Console.WriteLine("4. Display Specific User");
    try
    {
        int selectedOption = int.Parse(Console.ReadLine());

        switch (selectedOption)
        {
            case 1:
                AddUser();
                break;
            case 2:
                Console.WriteLine("Please Enter File Name");
                EditUser(Console.ReadLine());
                break;
            case 3:
                Console.WriteLine("Please Enter File Name");
                DeleteUser(Console.ReadLine());
                break;
            case 4:
                Console.WriteLine("Please Enter File Name");
                GetDataFromUserFile(Console.ReadLine());
                break;

            default:
                MenuOptions();
                break;
        }
    }
    catch (FormatException )
    {
        Console.WriteLine("Please Enter A Valid Input");
        MenuOptions();
    }
    catch (Exception err)
    {
        Console.WriteLine(err.Message);
    }
}

MenuOptions();

void CreateUseres()
{
    int count = 0;
    while (count < 3)
    {
        Console.WriteLine("Please Enter firstName,lastName,yearOfBirth,eamil");
        usersList.Add(new User(Console.ReadLine(), Console.ReadLine(), int.Parse(Console.ReadLine()), Console.ReadLine()));
        usersList.Sort();
        foreach (User user in usersList)
        {
            Console.WriteLine($"{user.FirstName} {user.LastName} {user.YearOfBirth} {user.Email}");
        }

        count++;
    }
}

//CreateUseres();

void GetDataAndWriteToFile(List<User> userList)
{
    FileStream fileStreamObject = new FileStream(@"C:\test\Users\users.txt", FileMode.Append);
    using (StreamWriter writeToUserFile = new StreamWriter(fileStreamObject))
    {    
        foreach (User user in usersList)
        {
            writeToUserFile.Write($"{user.FirstName} {user.LastName} {user.YearOfBirth} {user.Email}\n");
        }
    }
}

//GetDataAndWriteToFile(usersList);

void GetDataAndPrintToConsole(string filePath)
{
    FileStream fileStreamObject = new FileStream($@"C:\test\Users\{filePath}.txt", FileMode.Open);
    using (StreamReader readFromUserFile = new StreamReader(fileStreamObject))
    {
        for (int i = 0; i < readFromUserFile.Peek(); i++)
        {
            Console.WriteLine(readFromUserFile.ReadLine()); 
        }
    }
}
//GetDataAndPrintToConsole("users");


void GetDataAndWriteToSeperateFile(List<User> userList)
{
    foreach (User user in userList)
    {
       FileStream fileStreamObject = new FileStream($@"C:\test\Users\{user.FirstName} {user.LastName}.txt", FileMode.Append);
       using (StreamWriter writeToUserFile = new StreamWriter(fileStreamObject))
       {
         writeToUserFile.Write($"{user.FirstName} {user.LastName} {user.YearOfBirth} {user.Email}\n");

       }
    }   
}

//GetDataAndWriteToSeperateFile(usersList);

void GetDataFromUserFile(string fileName)
{
    try
    {
        FileStream fileStreamObject = new FileStream($@"C:\test\Users\{fileName}.txt", FileMode.Open);
        using (StreamReader readFromUserFile = new StreamReader(fileStreamObject))
        {
            for (int i = 0; i < readFromUserFile.Peek(); i++)
            {
                Console.WriteLine(readFromUserFile.ReadLine());
            }
        }
    }catch(FileNotFoundException)
    {
        Console.WriteLine("Please Enter The Correct File Name");
        GetDataFromUserFile(fileName);
    }
    catch (Exception err)
    {
        Console.WriteLine(err.Message);
    }
}

//GetDataFromUserFile("bob kali");



void AddUser()
{
    try
    {
        Console.WriteLine("Please Enter firstName,lastName,yearOfBirth,eamil");
        usersList.Add(new User(Console.ReadLine(), Console.ReadLine(), int.Parse(Console.ReadLine()), Console.ReadLine()));
    }catch (FormatException)
    {
        Console.WriteLine("Please Enter A Valid Input");
        AddUser();
    }
   foreach (User user in usersList)
   {
       Console.WriteLine($"{user.FirstName} {user.LastName} {user.YearOfBirth} {user.Email}");
   }
}

void DeleteUser(string fileName)
{
    try
    {
        File.Delete(fileName);
    }
    catch (FileNotFoundException)
    {
        Console.WriteLine("Please Enter The Correct File Name");
    }
}


void EditUser(string userName)
{
    try
    {
        string[] arrayOfStrings;

        FileStream fileStreamObject = new FileStream($@"C:\test\Users\{userName}.txt", FileMode.Open);
        using (StreamReader readFromUserFile = new StreamReader(fileStreamObject))
        {
            arrayOfStrings = readFromUserFile.ReadLine().Split(" ");
        }

        FileStream userFile = new FileStream($@"C:\test\Users\{userName}.txt", FileMode.Create);
        using (StreamWriter writeToUserFile = new StreamWriter(userFile))
        {
          Console.WriteLine("Please Select The Options");
          Console.WriteLine("1. Edit firstName");
          Console.WriteLine("2. Edit lastName");
          Console.WriteLine("3. Edit yearOfBirth");
          Console.WriteLine("4. Edit email");
          int selectedOption = int.Parse(Console.ReadLine());
            switch (selectedOption)
            {
                case 1:
                    Console.WriteLine("Enter firstName");
                    Update(0, writeToUserFile, arrayOfStrings);
                    break;
                case 2:
                    Console.WriteLine("Enter lastName");
                    Update(1, writeToUserFile, arrayOfStrings);
                    break;
                case 3:
                    Console.WriteLine("Enter yearOfBirth");
                    Update(2, writeToUserFile, arrayOfStrings);
                    break;
                case 4:
                    Console.WriteLine("Enter Email");
                    Update(3, writeToUserFile, arrayOfStrings);
                    break;
                default:
                    EditUser(userName);
                    break;
            }
        }
    }
    catch (FileNotFoundException)
    {
        Console.WriteLine("Please Enter The Correct File Name");
    }
    catch(Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
}

void Update(int number, StreamWriter writeToFile, string[] array)
{
    switch (number)
    {
        case 0:
            EditAndSaveTheChanges(array, 0, writeToFile);
            break;
        case 1:
            EditAndSaveTheChanges(array, 1, writeToFile);
            break;
        case 2:
            EditAndSaveTheChanges(array, 2, writeToFile);
            break;
        case 3:
            EditAndSaveTheChanges(array, 3, writeToFile);
            break;
        default:
            Update(number,writeToFile,array);
            break;
    }
}


void EditAndSaveTheChanges(string[] array,int indexInTheArray,StreamWriter writeToFile)
{
    for (int i = 0; i < array.Length; i++)
    {
        if (i == indexInTheArray) writeToFile.Write($"{array[indexInTheArray] = Console.ReadLine()} ");
        else writeToFile.Write($"{array[i]} ");

    }
}
